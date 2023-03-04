using Newtonsoft.Json;
using WaifuImAPI_NET.Models.Enums;

namespace WaifuImAPI_NET.Models.Objects
{
    public class WaifuImFullTagList
    {
        [JsonProperty(PropertyName = "versatile")]
        public WaifuImTag[]? VersatileTags { get; set; }

        [JsonProperty(PropertyName = "nsfw")]
        public WaifuImTag[]? NsfwTags { get; set; }
    }
}
