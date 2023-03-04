using Newtonsoft.Json;

namespace WaifuImAPI_NET.Models.Objects
{
    public class WaifuImTag
    {
        [JsonProperty(PropertyName = "tag_id")]
        public uint? TagId { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string? Name { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string? Description { get; set; }

        [JsonProperty(PropertyName = "is_nsfw")]
        public bool? IsNsfw { get; set; }
    }
}
