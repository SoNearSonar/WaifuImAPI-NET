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
    /// <remarks> Documentation: <see href="https://docs.waifu.im/"/> </remarks>
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
        /// <remarks> Information: <see href="https://docs.waifu.im/reference/api-reference/search"/> </remarks>
        /// <exception cref="HttpRequestException">Thrown if the user id does not exist or if the OrderBy property is set to Order.LikedAt</exception>
        public async Task<WaifuImImageList> GetImagesAsync(WaifuImSearchSettings settings = null)
        {
            return await MakeApiGetCall<WaifuImImageList>(_url + "/search", settings);
        }

        /// <summary>
        ///   Get a list of tag names
        /// </summary>
        /// <remarks> Information: <see href="https://docs.waifu.im/reference/api-reference/tags"/> </remarks>
        public async Task<WaifuImTagList> GetTagsAsync()
        {
            return await MakeApiGetCall<WaifuImTagList>(_url + "/tags");
        }

        /// <summary>
        ///   Get a list of complete tag information
        /// </summary>
        /// <remarks> Information: <see href="https://docs.waifu.im/reference/api-reference/tags"/> </remarks>
        public async Task<WaifuImFullTagList> GetFullTagsAsync()
        {
            return await MakeApiGetCall<WaifuImFullTagList>(_url + "/tags?full=true");
        }

        /// <summary>
        ///   Get a list of favorited images
        /// </summary>
        /// <param name="settings">The search object containing properties representing filters</param>
        /// <remarks> Information: <see href="https://docs.waifu.im/reference/api-reference/favorites#get-your-favorites"/> </remarks>
        /// <exception cref="HttpRequestException">Thrown if the user token is not valid or if there are no favorites</exception>
        public async Task<WaifuImImageList> GetFavoritesAsync(WaifuImSearchSettings settings = null)
        {
            return await MakeApiGetCallForFavorite<WaifuImImageList>(_url + "/fav", settings);
        }

        /// <summary>
        ///   Add a new image to the user's favorites
        /// </summary>
        /// <param name="settings">The search object containing a user ID (if authorized) and an image ID (required)</param>
        /// <remarks> Information: <see href="https://docs.waifu.im/reference/api-reference/favorites#manage-your-favorites"/> </remarks>
        /// <exception cref="HttpRequestException">Thrown if the user token is not valid or if the favorite already exists</exception>
        public async Task<WaifuImFavorite> InsertFavoriteAsync(WaifuImFavoriteSettings settings)
        {
            return await MakeApiPostCallForFavorite<WaifuImFavorite>(_url + "/fav/insert", settings);
        }

        /// <summary>
        ///   Removes an existing image from the user's favorites
        /// </summary>
        /// <param name="settings">The search object containing a user ID (if authorized) and an image ID (required)</param>
        /// <remarks> Information: <see href="https://docs.waifu.im/reference/api-reference/favorites#manage-your-favorites"/> </remarks>
        /// <exception cref="HttpRequestException">Thrown if the user token is not valid or if the favorite does not exist</exception>
        public async Task<WaifuImFavorite> DeleteFavoriteAsync(WaifuImFavoriteSettings settings)
        {
            return await MakeApiDeleteCallForFavorite<WaifuImFavorite>(_url + "/fav/delete", settings);
        }


        /// <summary>
        ///   Either adds or removes a new image to the user's favorites
        /// </summary>
        /// <param name="settings">The search object containing a user ID (if authorized) and an image ID (required)</param>
        /// <remarks> Information: <see href="https://docs.waifu.im/reference/api-reference/favorites#manage-your-favorites"/> </remarks>
        /// <exception cref="HttpRequestException">Thrown if the user token is not valid</exception>
        public async Task<WaifuImFavorite> ToggleFavoriteAsync(WaifuImFavoriteSettings settings)
        {
            return await MakeApiPostCallForFavorite<WaifuImFavorite>(_url + "/fav/toggle", settings);
        }

        /// <summary>
        ///   Reports an image for user-provided reasons (incorrect tags, wrong author, and so forth)
        /// </summary>
        /// <param name="settings">The search object containing a image ID (required) and a description (required)</param>
        /// <remarks> Information: <see href="https://docs.waifu.im/reference/api-reference/report"/> </remarks>
        /// <exception cref="HttpRequestException">Thrown if the user token is not valid</exception>
        public async Task<WaifuImReport> ReportImageAsync(WaifuImReportSettings settings)
        {
            return await MakeApiPostCallForReport<WaifuImReport>(_url + "/report", settings);
        }

        private async Task<T> MakeApiGetCall<T>(string url, WaifuImSearchSettings settings = null)
        {
            // Check if the provided settings are not empty, format them into a query string if so
            string query = string.Empty;
            if (settings != null)
            {
                // A utility method formats all the setting properties to a string
                // E.g.: (url)?height=1000&width=1000
                query = QueryUtility.FormatQueryParams(settings);
            }

            // Create a new response message to hit the endpoint that this call is targeting
            // This is for a GET request
            HttpResponseMessage message = await CreateGetApiMessage(url + query);
            if (message.StatusCode == HttpStatusCode.OK)
            {
                // Get the JSON from the response and make it into a C# object
                string response = await message.Content.ReadAsStringAsync();
                return DeserializeObject<T>(response);
            }

            // Throw an error if the request was not successful (Should be a 200 OK)
            throw new HttpRequestException($"{(int)message.StatusCode} {message.StatusCode} code - Request was not successful");
        }

        private async Task<T> MakeApiGetCallForFavorite<T>(string url, WaifuImSearchSettings settings = null)
        {
            // Check if the provided settings are not empty, format them into a query string if so
            string query = string.Empty;
            if (settings != null)
            {
                // A utility method formats all the setting properties to a string
                // E.g.: (url)?image_id=0001
                query = QueryUtility.FormatQueryParams(settings);
            }

            // Create a new response message to hit the endpoint that this call is targeting
            // This is for a GET request
            HttpResponseMessage message = await CreateApiGetMessageForFavorite(url + query, _token);
            if (message.StatusCode == HttpStatusCode.OK)
            {
                // Get the JSON from the response and make it into a C# object
                string response = await message.Content.ReadAsStringAsync();
                return DeserializeObject<T>(response);
            }

            // Throw an error if the request was not successful (Should be a 200 OK)
            throw new HttpRequestException($"{(int)message.StatusCode} {message.StatusCode} code - Request was not successful");
        }

        private async Task<T> MakeApiPostCallForFavorite<T>(string url, WaifuImFavoriteSettings settings)
        {
            if (string.IsNullOrWhiteSpace(_token))
            {
                throw new HttpRequestException("A token is required to use this endpoint");
            }
            else if (settings == null)
            {
                throw new HttpRequestException("You need to pass in a favorite settings object into this call");
            }

            // Create a new response message to hit the endpoint that this call is targeting
            // This is for a POST request
            HttpResponseMessage message = await CreateApiPostMessageForFavorite(url, _token, settings);
            if (message.StatusCode == HttpStatusCode.OK)
            {
                string response = await message.Content.ReadAsStringAsync();
                return DeserializeObject<T>(response);
            }

            // Throw an error if the request was not successful (Should be a 200 OK)
            throw new HttpRequestException($"{(int)message.StatusCode} {message.StatusCode} code - Request was not successful");
        }

        private async Task<T> MakeApiPostCallForReport<T>(string url, WaifuImReportSettings settings)
        {
            if (string.IsNullOrWhiteSpace(_token))
            {
                throw new HttpRequestException("A token is required to use this endpoint");
            }
            else if (settings == null)
            {
                throw new HttpRequestException("You need to pass in an image ID and reason within a settings object");
            }

            // Create a new response message to hit the endpoint that this call is targeting
            // This is for a POST request
            HttpResponseMessage message = await CreateApiPostMessageForReport(url, _token, settings);
            if (message.StatusCode == HttpStatusCode.OK)
            {
                string response = await message.Content.ReadAsStringAsync();
                return DeserializeObject<T>(response);
            }

            // Throw an error if the request was not successful (Should be a 200 OK)
            throw new HttpRequestException($"{(int)message.StatusCode} {message.StatusCode} code - Request was not successful");
        }

        private async Task<T> MakeApiDeleteCallForFavorite<T>(string url, WaifuImFavoriteSettings settings)
        {
            // If a token is not provided this API call will fail
            if (string.IsNullOrWhiteSpace(_token))
            {
                throw new HttpRequestException("A token is required to use this endpoint");
            }
            // If this request has no settings this API call will also fail
            else if (settings == null)
            {
                throw new HttpRequestException("You need to pass in an image ID within a settings object");
            }

            // Create a new response message to hit the endpoint that this call is targeting
            // This is for a POST request (Recent update made this DELETE call a POST)
            HttpResponseMessage message = await CreateApiDeleteMessageForFavorite(url, _token, settings);
            if (message.StatusCode == HttpStatusCode.OK)
            {
                string response = await message.Content.ReadAsStringAsync();
                return DeserializeObject<T>(response);
            }

            // Throw an error if the request was not successful (Should be a 200 OK)
            throw new HttpRequestException($"{(int)message.StatusCode} {message.StatusCode} code - Request was not successful");
        }

        private T DeserializeObject<T>(string contents)
        {
            // Creates a new object that will deserialize the information using a serializer defaults property
            JsonSerializerOptions options = new JsonSerializerOptions(JsonSerializerDefaults.Web);

            // Add a new converter that is able to read enums as strings (extension)
            options.Converters.Add(new JsonStringEnumMemberConverter());

            // Deserialize the contents with the provided options and return it to the calling method
            return JsonSerializer.Deserialize<T>(contents, options);
        }

        private async Task<HttpResponseMessage> CreateGetApiMessage(string url)
        {
            // Create a HttpClient object to handle the request with additional request headers
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("Accept-Version", "v5");
            client.DefaultRequestHeaders.Add("User-Agent", "WaifuImAPI-NET/2.1");
            return await client.GetAsync(url);
        }

        private async Task<HttpResponseMessage> CreateApiGetMessageForFavorite(string url, string token)
        {
            // Create a HttpClient object to handle the request with additional request headers
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("Accept-Version", "v5");
            client.DefaultRequestHeaders.Add("User-Agent", "WaifuImAPI-NET/2.1");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            return await client.GetAsync(url);
        }

        private async Task<HttpResponseMessage> CreateApiPostMessageForFavorite(string url, string token, WaifuImFavoriteSettings settings)
        {
            // Create a HttpClient object to handle the request with additional request headers
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("Accept-Version", "v5");
            client.DefaultRequestHeaders.Add("User-Agent", "WaifuImAPI-NET/2.1");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            return await client.PostAsJsonAsync(url, settings);
        }

        private async Task<HttpResponseMessage> CreateApiPostMessageForReport(string url, string token, WaifuImReportSettings settings)
        {
            // Create a HttpClient object to handle the request with additional request headers
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("Accept-Version", "v5");
            client.DefaultRequestHeaders.Add("User-Agent", "WaifuImAPI-NET/2.1");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            return await client.PostAsJsonAsync(url, settings);
        }

        private async Task<HttpResponseMessage> CreateApiDeleteMessageForFavorite(string url, string token, WaifuImFavoriteSettings settings)
        {
            // Create a HttpClient object to handle the request with additional request headers
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("Accept-Version", "v5");
            client.DefaultRequestHeaders.Add("User-Agent", "WaifuImAPI-NET/2.1");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            // Create a request message that holds our information that we want to pass
            // In this case we need to format the settings object specifically for this call
            HttpRequestMessage message = new HttpRequestMessage()
            {
                Content = new StringContent(JsonSerializer.Serialize(settings), Encoding.UTF8, "application/json"),
                Method = HttpMethod.Post,
                RequestUri = new Uri(url)
            };
            return await client.SendAsync(message);
        }
    }
}
