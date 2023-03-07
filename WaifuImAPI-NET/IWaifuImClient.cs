using Refit;
using WaifuImAPI_NET.Models.Objects;
using WaifuImAPI_NET.Models.Objects.Lists;

namespace WaifuImAPI_NET
{
    [Headers("Accept-Version: v5", "User-Agent: WaifuImAPI-NET/1.0", "Accept: application/json")]
    public interface IWaifuImClient
    {
        [Get("/search")]
        Task<WaifuImImageList> GetImagesAsync(WaifuImSearchSettings settings = null);

        [Get("/tags")]
        Task<WaifuImTagList> GetTagsAsync();

        [Get("/tags?full=true")]
        Task<WaifuImFullTagList> GetFullTagsAsync();

        [Get("/fav")]
        Task<WaifuImImageList> GetFavoritesAsync([Authorize("Bearer")] string token, WaifuImSearchSettings settings = null);

        [Post("/fav/insert")]
        Task<WaifuImFavorite> InsertFavoriteAsync([Authorize("Bearer")] string token, [Body] WaifuImFavoriteSettings settings);

        [Delete("/fav/delete")]
        Task<WaifuImFavorite> DeleteFavoriteAsync([Authorize("Bearer")] string token, [Body] WaifuImFavoriteSettings settings);

        [Post("/fav/toggle")]
        Task<WaifuImFavorite> ToggleFavoriteAsync([Authorize("Bearer")] string token, [Body] WaifuImFavoriteSettings settingsl);
    }
}
