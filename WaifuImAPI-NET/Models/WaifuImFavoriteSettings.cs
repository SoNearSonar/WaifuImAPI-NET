using System.Text.Json.Serialization;

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
        /// 
        [JsonPropertyName("user_id")]
        public ulong? UserId { get; set; } = null;

        /// <summary>
        ///   The image ID to modify favorites for a user
        /// </summary>
        /// 
        [JsonPropertyName("image_id")]
        public ulong ImageId { get; set; }
    }
}
