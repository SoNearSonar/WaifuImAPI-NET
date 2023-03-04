using Newtonsoft.Json;
using WaifuImAPI_NET.Models.Objects;
using WaifuImAPI_NET.Utilities;

namespace WaifuImAPI_NET
{
    public class WaifuImManager
    {
        private readonly string _uri = "https://api.waifu.im";
        HttpUtility _httpUtility = new HttpUtility();

        public async Task<WaifuImImageList> GetImages(WaifuImSettings settings = null)
        {
            return await MakeAPICall<WaifuImImageList>(_httpUtility.CreateAPICall(_uri + "/search", settings));
        }

        private async Task<T?> MakeAPICall<T>(string apiCall)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("Accept-Version", "v4");
            client.DefaultRequestHeaders.Add("User-Agent", "WaifuImAPI-NET/1.0");
            HttpResponseMessage message = await client.GetAsync(apiCall);
            
            if (message.IsSuccessStatusCode)
            {
                string response = await message.Content.ReadAsStringAsync();
                return DeserializeData<T>(response);
            }

            return default;
        }

        private T DeserializeData<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}