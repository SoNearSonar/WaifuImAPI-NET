using System.Text.Json.Serialization;

namespace WaifuImAPI_NET.Models
{
    /// <summary>
    ///   An object holding a list of versatile and nsfw tag names
    /// </summary>
    public class WaifuImTagList
    {
        /// <summary>
        /// The list of tag names that are versatile and/or safe for work
        /// </summary>
        [JsonPropertyName("versatile")] 
        public Tags[] VersatileTags { get; set; } = default!;

        /// <summary>
        /// The list of tag names that are not safe for work
        /// </summary>
        [JsonPropertyName("nsfw")] 
        public Tags[] NsfwTags { get; set; } = default!;
    }
}
