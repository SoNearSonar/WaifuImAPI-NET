using Refit;

namespace WaifuImAPI_NET.Models
{
    /// <summary>
    ///   An object holding favorite information for favorites
    /// </summary>
    public class WaifuImFavoriteSettings
    {
        /// <summary>
        ///   The user ID to modify favorites for
        /// </summary>
        [AliasAs("user_id")]
        public uint UserId { get; set; }

        /// <summary>
        ///   The image ID to modify favorites for a user
        /// </summary>
        [AliasAs("image_id")]
        public uint ImageId { get; set; }
    }
}
