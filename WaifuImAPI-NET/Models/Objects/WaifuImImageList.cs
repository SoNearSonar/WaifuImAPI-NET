using Newtonsoft.Json;

namespace WaifuImAPI_NET.Models.Objects
{
    public class WaifuImImageList
    {
        [JsonProperty(PropertyName = "images")]
        public List<WaifuImImage>? Images { get; set; }
    }
}
