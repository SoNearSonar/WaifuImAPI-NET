using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Refit;
using WaifuImAPI_NET.Models;

namespace WaifuImAPI_NET
{
    public sealed class WaifuImClient : IWaifuImClient
    {
        public static RefitSettings Settings = new RefitSettings()
        {
            ContentSerializer = new NewtonsoftJsonContentSerializer(new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver()
                {
                    NamingStrategy = new SnakeCaseNamingStrategy()
                }
            })
        };

        private readonly IWaifuImClient _client;

        public WaifuImClient()
        {
            _client = RestService.For<IWaifuImClient>("https://api.waifu.im", Settings);
        }

        public async Task<WaifuImImageList> GetImagesAsync(WaifuImSearchSettings settings = null)
        {
            return await _client.GetImagesAsync(settings);
        }

        public async Task<WaifuImTagList> GetTagsAsync()
        {
            return await _client.GetTagsAsync();
        }

        public async Task<WaifuImFullTagList> GetFullTagsAsync()
        {
            return await _client.GetFullTagsAsync();
        }

        public async Task<WaifuImImageList> GetFavoritesAsync(string token, WaifuImSearchSettings settings = null)
        {
            return await _client.GetFavoritesAsync(token, settings);
        }

        public async Task<WaifuImFavorite> InsertFavoriteAsync([Authorize("Bearer")] string token, WaifuImFavoriteSettings settings)
        {
            return await _client.InsertFavoriteAsync(token, settings);
        }

        public async Task<WaifuImFavorite> DeleteFavoriteAsync([Authorize("Bearer")] string token, WaifuImFavoriteSettings settings)
        {
            return await _client.DeleteFavoriteAsync(token, settings);
        }

        public async Task<WaifuImFavorite> ToggleFavoriteAsync([Authorize("Bearer")] string token, WaifuImFavoriteSettings settings)
        {
            return await _client.ToggleFavoriteAsync(token, settings);
        }
    }
}
