using Refit;
using WaifuImAPI_NET.Models;

namespace WaifuImAPI_NET
{
    /// <summary>
    ///   A client that has hndpoints for retrieving and modifying information from waifu.im
    /// </summary>
    /// <remarks> Documentation: <see href="https://www.waifu.im/docs/"/> </remarks>
    [Headers("Accept-Version: v5", "User-Agent: WaifuImAPI-NET/1.0", "Accept: application/json")]
    public interface IWaifuImClient
    {
        /// <summary>
        ///   Get a list of images with the option to add search filters
        /// </summary>
        /// <param name="settings">The settings object containing search filters</param>
        /// <remarks> Information: <see href="https://www.waifu.im/docs/#search-images"/> </remarks>
        /// <exception cref="ApiException">Thrown if the user id does not exist or if the OrderBy property is set to Order.LikedAt</exception>
        [Get("/search")]
        Task<WaifuImImageList> GetImagesAsync(WaifuImSearchSettings settings = null);

        /// <summary>
        ///   Get a list of tag names
        /// </summary>
        /// <remarks> Information: <see href="https://www.waifu.im/docs/#tags"/> </remarks>
        [Get("/tags")]
        Task<WaifuImTagList> GetTagsAsync();

        /// <summary>
        ///   Get a list of complete tag information
        /// </summary>
        /// <remarks> Information: <see href="https://www.waifu.im/docs/#tags-query-strings"/> </remarks>
        [Get("/tags?full=true")]
        Task<WaifuImFullTagList> GetFullTagsAsync();

        /// <summary>
        ///   Get a list of favorited images
        /// </summary>
        /// <param name="token">The generated token from the users account</param>
        /// <param name="settings">The search object containing properties representing filters</param>
        /// <remarks> Information: <see href="https://www.waifu.im/docs/#favorites"/> </remarks>
        /// <exception cref="ApiException">Thrown if the user token is not valid or if there are no favorites</exception>
        [Get("/fav")]
        Task<WaifuImImageList> GetFavoritesAsync([Authorize("Bearer")] string token, WaifuImSearchSettings settings = null);

        /// <summary>
        ///   Add a new image to the user's favorites
        /// </summary>
        /// <param name="token">The generated token from the users account</param>
        /// <param name="settings">The search object containing a user ID (if authorized) and an image ID (required)</param>
        /// <remarks> Information: <see href="https://www.waifu.im/docs/#edit-favorites"/> </remarks>
        /// <exception cref="ApiException">Thrown if the user token is not valid or if the favorite already exists</exception>
        [Post("/fav/insert")]
        Task<WaifuImFavorite> InsertFavoriteAsync([Authorize("Bearer")] string token, [Body] WaifuImFavoriteSettings settings);

        /// <summary>
        ///   Removes an existing image from the user's favorites
        /// </summary>
        /// <param name="token">The generated token from the users account</param>
        /// <param name="settings">The search object containing a user ID (if authorized) and an image ID (required)</param>
        /// <remarks> Information: <see href="https://www.waifu.im/docs/#edit-favorites"/> </remarks>
        /// <exception cref="ApiException">Thrown if the user token is not valid or if the favorite does not exist</exception>
        [Delete("/fav/delete")]
        Task<WaifuImFavorite> DeleteFavoriteAsync([Authorize("Bearer")] string token, [Body] WaifuImFavoriteSettings settings);

        /// <summary>
        ///   Either adds or removes a new image to the user's favorites
        /// </summary>
        /// <param name="token">The generated token from the users account</param>
        /// <param name="settings">The search object containing a user ID (if authorized) and an image ID (required)</param>
        /// <remarks> Information: <see href="https://www.waifu.im/docs/#edit-favorites"/> </remarks>
        /// <exception cref="ApiException">Thrown if the user token is not valid</exception>
        [Post("/fav/toggle")]
        Task<WaifuImFavorite> ToggleFavoriteAsync([Authorize("Bearer")] string token, [Body] WaifuImFavoriteSettings settingsl);
    }
}
