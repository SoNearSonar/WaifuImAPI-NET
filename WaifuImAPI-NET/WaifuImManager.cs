using Newtonsoft.Json;
using WaifuImAPI_NET.Models.Objects;
using WaifuImAPI_NET.Utilities;

namespace WaifuImAPI_NET
{
    public class WaifuImManager
    {
        private readonly string _uri = "https://api.waifu.im";
        private readonly HttpUtility _httpUtility = new HttpUtility();
        private string _token;

        public WaifuImManager() { }

        public WaifuImManager(string token)
        {
            _token = token;
        }

        public async Task<WaifuImImageList> GetImages(WaifuImImageSettings? settings = null)
        {
            string apiCall = _httpUtility.CreateImageAPICall(_uri + "/search", settings);
            return await MakeAPICall<WaifuImImageList>(apiCall);
        }

        public async Task<WaifuImTagList> GetTags()
        {
            return await MakeAPICall<WaifuImTagList>(_uri + "/tags");
        }

        public async Task<WaifuImFullTagList> GetFullTags()
        {
            return await MakeAPICall<WaifuImFullTagList>(_uri + "/tags/?full=true");
        }

        public async Task<WaifuImImageList> GetFavourites(WaifuImImageSettings? settings = null)
        {
            string apiCall = _httpUtility.CreateImageAPICall(_uri + "/fav", settings);
            if (!string.IsNullOrWhiteSpace(_token))
            {
                return await MakeAPICall<WaifuImImageList>(apiCall, _token);
            }
            else
            {
                throw new HttpRequestException("GetFavourites() requires a token to use");
            }
        }

        private async Task<T?> MakeAPICall<T>(string apiCall, string token = null)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("Accept-Version", "v4");
            client.DefaultRequestHeaders.Add("User-Agent", "WaifuImAPI-NET/1.0");
            if (token != null)
            {
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
            }

            HttpResponseMessage message = await client.GetAsync(apiCall);
            message.EnsureSuccessStatusCode();

            string response = await message.Content.ReadAsStringAsync();
            return DeserializeData<T>(response);
        }

        private T DeserializeData<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}