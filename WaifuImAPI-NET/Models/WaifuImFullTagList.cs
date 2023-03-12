using Newtonsoft.Json;

namespace WaifuImAPI_NET.Models
{
    /// <summary>
    ///   An object holding ia list of versatile and nsfw tags
    /// </summary>
    public class WaifuImFullTagList
    {
        /// <summary>
        /// The list of tags that are versatile and/or safe for work
        /// </summary>
        [JsonProperty(PropertyName = "versatile")]
        public WaifuImTag[]? VersatileTags { get; set; }

        /// <summary>
        /// The list of tags that are not safe for work
        /// </summary>
        [JsonProperty(PropertyName = "nsfw")]
        public WaifuImTag[]? NsfwTags { get; set; }
    }
}
