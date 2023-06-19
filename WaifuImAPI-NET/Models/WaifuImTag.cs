using System.Text.Json.Serialization;

namespace WaifuImAPI_NET.Models
{
    /// <summary>
    /// An object holding information a tag
    /// </summary>
    public class WaifuImTag
    {
        /// <summary>
        ///   An ID for the tag
        /// </summary>
        [JsonPropertyName("tag_id")]
        public uint TagId { get; set; } = default!;

        /// <summary>
        ///   A name for the tag
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; } = default!;

        /// <summary>
        ///   A description for the tag
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; } = default!;

        /// <summary>
        ///   A value representing if the tag is considered not safe for work
        /// </summary>
        [JsonPropertyName("is_nsfw")]
        public bool IsNsfw { get; set; } = default!;
    }
}
