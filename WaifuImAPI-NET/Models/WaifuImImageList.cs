using Newtonsoft.Json;

namespace WaifuImAPI_NET.Models
{
    /// <summary>
    ///   An object holding a list of images
    /// </summary>
    public class WaifuImImageList
    {
        /// <summary>
        /// The list of images returned from the search
        /// </summary>
        [JsonProperty(PropertyName = "images")]
        public List<WaifuImImage>? Images { get; set; } = default!;
    }
}
