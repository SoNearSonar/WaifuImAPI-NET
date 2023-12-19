using System.Text.Json.Serialization;

namespace WaifuImAPI_NET.Models
{
    /// <summary>
    ///   An object holding the response from reporting an image on Waifu.IM
    /// </summary>
    public class WaifuImReportSettings
    {
        /// <summary>
        ///   The ID of the image that is being reported
        /// </summary>
        [JsonPropertyName("image_id")]
        public uint ImageId { get; set; } = 0;

        /// <summary>
        ///   The reason for why a given image should be reported
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;
    }
}
