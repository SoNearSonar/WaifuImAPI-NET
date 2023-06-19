using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using WaifuImAPI_NET.Models;
using WaifuImAPI_NET.Utilities;

namespace WaifuImAPI_NET
{
    /// <summary>
    ///   A client that has endpoints for retrieving and modifying information from waifu.im
    /// </summary>
    /// <remarks> Documentation: <see href="https://www.waifu.im/docs/"/> </remarks>
    public sealed class WaifuImClient
    {
        private readonly string _url = "https://api.waifu.im";
        private string _token = string.Empty;

        public WaifuImClient(string token)
        {
            _token = token;
        }

        public WaifuImClient() { }

        /// <summary>
        ///   Get a list of images with the option to add search filters
        /// </summary>
        /// <param name="settings">The settings object containing search filters</param>
        /// <remarks> Information: <see href="https://www.waifu.im/docs/#search-images"/> </remarks>
        /// <exception cref="HttpRequestException">Thrown if the user id does not exist or if the OrderBy property is set to Order.LikedAt</exception>
        public async Task<WaifuImImageList> GetImagesAsync(WaifuImSearchSettings settings = null)
        {
            return await MakeApiGetCall<WaifuImImageList>(_url + "/search", settings);
        }

        /// <summary>
        ///   Get a list of tag names
        /// </summary>
        /// <remarks> Information: <see href="https://www.waifu.im/docs/#tags"/> </remarks>
        public async Task<WaifuImTagList> GetTagsAsync()
        {
            return await MakeApiGetCall<WaifuImTagList>(_url + "/tags");
        }

        /// <summary>
        ///   Get a list of complete tag information
        /// </summary>
        /// <remarks> Information: <see href="https://www.waifu.im/docs/#tags-query-strings"/> </remarks>
        public async Task<WaifuImFullTagList> GetFullTagsAsync()
        {
            return await MakeApiGetCall<WaifuImFullTagList>(_url + "/tags?full=true");
        }

        /// <summary>
        ///   Get a list of favorited images
        /// </summary>
        /// <param name="settings">The search object containing properties representing filters</param>
        /// <remarks> Information: <see href="https://www.waifu.im/docs/#favorites"/> </remarks>
        /// <exception cref="HttpRequestException">Thrown if the user token is not valid or if there are no favorites</exception>
        public async Task<WaifuImImageList> GetFavoritesAsync(WaifuImSearchSettings settings = null)
        {
            return await MakeApiGetCallForFavorite<WaifuImImageList>(_url + "/fav", settings);
        }

        /// <summary>
        ///   Add a new image to the user's favorites
        /// </summary>
        /// <param name="settings">The search object containing a user ID (if authorized) and an image ID (required)</param>
        /// <remarks> Information: <see href="https://www.waifu.im/docs/#edit-favorites"/> </remarks>
        /// <exception cref="HttpRequestException">Thrown if the user token is not valid or if the favorite already exists</exception>
        public async Task<WaifuImFavorite> InsertFavoriteAsync(WaifuImFavoriteSettings settings)
        {
            return await MakeApiPostCallForFavorite<WaifuImFavorite>(_url + "/fav/insert", settings);
        }

        /// <summary>
        ///   Removes an existing image from the user's favorites
        /// </summary>
        /// <param name="settings">The search object containing a user ID (if authorized) and an image ID (required)</param>
        /// <remarks> Information: <see href="https://www.waifu.im/docs/#edit-favorites"/> </remarks>
        /// <exception cref="HttpRequestException">Thrown if the user token is not valid or if the favorite does not exist</exception>
        public async Task<WaifuImFavorite> DeleteFavoriteAsync(WaifuImFavoriteSettings settings)
        {
            return await MakeApiDeleteCallForFavorite<WaifuImFavorite>(_url + "/fav/delete", settings);
        }


        /// <summary>
        ///   Either adds or removes a new image to the user's favorites
        /// </summary>
        /// <param name="settings">The search object containing a user ID (if authorized) and an image ID (required)</param>
        /// <remarks> Information: <see href="https://www.waifu.im/docs/#edit-favorites"/> </remarks>
        /// <exception cref="HttpRequestException">Thrown if the user token is not valid</exception>
        public async Task<WaifuImFavorite> ToggleFavoriteAsync(WaifuImFavoriteSettings settings)
        {
            return await MakeApiPostCallForFavorite<WaifuImFavorite>(_url + "/fav/toggle", settings);
        }

        private async Task<T> MakeApiGetCall<T>(string url, WaifuImSearchSettings settings = null)
        {
            string query = string.Empty;
            if (settings != null)
            {
                query = QueryUtility.FormatQueryParams(settings);
            }

            HttpResponseMessage message = await CreateGetApiMessage(url + query);
            if (message.StatusCode == HttpStatusCode.OK)
            {
                string response = await message.Content.ReadAsStringAsync();
                return DeserializeObject<T>(response);
            }

            throw new HttpRequestException($"{message.StatusCode} code - Request was not successful");
        }

        private async Task<T> MakeApiGetCallForFavorite<T>(string url, WaifuImSearchSettings settings = null)
        {
            string query = string.Empty;
            if (settings != null)
            {
                query = QueryUtility.FormatQueryParams(settings);
            }

            HttpResponseMessage message = await CreateApiGetMessageForFavorite(url + query, _token);
            if (message.StatusCode == HttpStatusCode.OK)
            {
                string response = await message.Content.ReadAsStringAsync();
                return DeserializeObject<T>(response);
            }

            throw new HttpRequestException($"{message.StatusCode} code - Request was not successful");
        }

        private async Task<T> MakeApiPostCallForFavorite<T>(string url, WaifuImFavoriteSettings settings)
        {
            if (string.IsNullOrEmpty(_token))
            {
                throw new HttpRequestException("A token is required to use this endpoint");
            }
            else if (settings == null)
            {
                throw new HttpRequestException("You need to pass in an image ID within a settings object");
            }

            HttpResponseMessage message = await CreateApiPostMessageForFavorite(url, _token, settings);
            if (message.StatusCode == HttpStatusCode.OK)
            {
                string response = await message.Content.ReadAsStringAsync();
                return DeserializeObject<T>(response);
            }

            throw new HttpRequestException($"{message.StatusCode} code - Request was not successful");
        }

        private async Task<T> MakeApiDeleteCallForFavorite<T>(string url, WaifuImFavoriteSettings settings)
        {
            if (string.IsNullOrEmpty(_token))
            {
                throw new HttpRequestException("A token is required to use this endpoint");
            }
            else if (settings == null)
            {
                throw new HttpRequestException("You need to pass in an image ID within a settings object");
            }

            HttpResponseMessage message = await CreateApiDeleteMessageForFavorite(url, _token, settings);
            if (message.StatusCode == HttpStatusCode.OK)
            {
                string response = await message.Content.ReadAsStringAsync();
                return DeserializeObject<T>(response);
            }

            throw new HttpRequestException($"{message.StatusCode} code - Request was not successful");
        }

        private T DeserializeObject<T>(string contents)
        {
            JsonSerializerOptions options = new JsonSerializerOptions(JsonSerializerDefaults.Web);
            options.Converters.Add(new JsonStringEnumMemberConverter());
            return JsonSerializer.Deserialize<T>(contents, options);
        }

        private async Task<HttpResponseMessage> CreateGetApiMessage(string url)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("Accept-Version", "v5");
            client.DefaultRequestHeaders.Add("User-Agent", "WaifuImAPI-NET/2.0");
            return await client.GetAsync(url);
        }

        private async Task<HttpResponseMessage> CreateApiGetMessageForFavorite(string url, string token)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("Accept-Version", "v5");
            client.DefaultRequestHeaders.Add("User-Agent", "WaifuImAPI-NET/2.0");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            return await client.GetAsync(url);
        }

        private async Task<HttpResponseMessage> CreateApiPostMessageForFavorite(string url, string token, WaifuImFavoriteSettings settings)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("Accept-Version", "v5");
            client.DefaultRequestHeaders.Add("User-Agent", "WaifuImAPI-NET/2.0");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            return await client.PostAsJsonAsync(url, settings);
        }

        private async Task<HttpResponseMessage> CreateApiDeleteMessageForFavorite(string url, string token, WaifuImFavoriteSettings settings)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("Accept-Version", "v5");
            client.DefaultRequestHeaders.Add("User-Agent", "WaifuImAPI-NET/2.0");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            HttpRequestMessage message = new HttpRequestMessage()
            {
                Content = new StringContent(JsonSerializer.Serialize(settings), Encoding.UTF8, "application/json"),
                Method = HttpMethod.Delete,
                RequestUri = new Uri(url)
            };
            return await client.SendAsync(message);
        }
    }
}
