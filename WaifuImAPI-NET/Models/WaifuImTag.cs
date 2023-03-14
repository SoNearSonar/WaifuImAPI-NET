using Newtonsoft.Json;

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
        [JsonProperty(PropertyName = "tag_id")]
        public uint TagId { get; set; } = default!;

        /// <summary>
        ///   A name for the tag
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; } = default!;

        /// <summary>
        ///   A description for the tag
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; } = default!;

        /// <summary>
        ///   A value representing if the tag is considered not safe for work
        /// </summary>
        [JsonProperty(PropertyName = "is_nsfw")]
        public bool IsNsfw { get; set; } = default!;
    }
}
