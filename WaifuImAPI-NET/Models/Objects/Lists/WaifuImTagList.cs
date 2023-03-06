using Newtonsoft.Json;
using WaifuImAPI_NET.Models.Enums;

namespace WaifuImAPI_NET.Models.Objects.Lists
{
    public class WaifuImTagList
    {
        [JsonProperty(PropertyName = "versatile")]
        public Tags[]? VersatileTags { get; set; }

        [JsonProperty(PropertyName = "nsfw")]
        public Tags[]? NsfwTags { get; set; }
    }
}
