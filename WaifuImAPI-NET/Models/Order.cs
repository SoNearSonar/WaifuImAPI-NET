using System.Runtime.Serialization;

namespace WaifuImAPI_NET.Models
{
    /// <summary>
    /// The order to sort images in a search by
    /// </summary>
    public enum Order
    {
        /// <summary>
        /// Sort by number of favorites
        /// </summary>
        [EnumMember(Value = "FAVORITES")] Favorites,

        /// <summary>
        /// Sort by time an image was uploaded at
        /// </summary>
        [EnumMember(Value = "UPLOADED_AT")] UploadedAt,

        /// <summary>
        /// Sort randomly
        /// </summary>
        [EnumMember(Value = "RANDOM")] Random,

        /// <summary>
        /// Sort by the time the user liked the image
        /// </summary>
        [EnumMember(Value = "LIKED_AT")] LikedAt
    }
}
