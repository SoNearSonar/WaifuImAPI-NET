using Newtonsoft.Json;

namespace WaifuImAPI_NET.Models
{
    /// <summary>
    ///   An object holding information of an image
    /// </summary>
    public class WaifuImImage
    {
        /// <summary>
        ///   The signature of the image
        /// </summary>
        [JsonProperty(PropertyName = "signature")]
        public string Signature { get; set; } = default!;

        /// <summary>
        ///   The image file extension of the image
        /// </summary>
        [JsonProperty(PropertyName = "extension")]
        public string Extension { get; set; } = default!;

        /// <summary>
        ///   The image ID of the image
        /// </summary>
        [JsonProperty(PropertyName = "image_id")]
        public uint ImageId { get; set; } = default!;

        /// <summary>
        ///   The number of users that favorited the image
        /// </summary>
        [JsonProperty(PropertyName = "favourites")]
        public uint Favourites { get; set; } = default!;

        /// <summary>
        ///   The main color on the image
        /// </summary>
        [JsonProperty(PropertyName = "dominant_color")]
        public string DominantColor { get; set; } = default!;

        /// <summary>
        ///   The source url for the image
        /// </summary>
        [JsonProperty(PropertyName = "source")]
        public string Source { get; set; } = default!;

        /// <summary>
        ///   The time the image was uploaded at
        /// </summary>
        [JsonProperty(PropertyName = "uploaded_at")]
        public string UploadedAt { get; set; } = default!;

        /// <summary>
        ///   The time the image was liked at
        /// </summary>
        [JsonProperty(PropertyName = "liked_at")]
        public string LikedAt { get; set; } = default!;

        /// <summary>
        ///   If the image is not safe for work
        /// </summary>
        [JsonProperty(PropertyName = "is_nsfw")]
        public bool IsNsfw { get; set; } = default!;

        /// <summary>
        ///   The width of an image
        /// </summary>
        [JsonProperty(PropertyName = "width")]
        public uint Width { get; set; } = default!;

        /// <summary>
        ///   The height of an image
        /// </summary>
        [JsonProperty(PropertyName = "height")]
        public uint Height { get; set; } = default!;

        /// <summary>
        ///   The url of an image
        /// </summary>
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; } = default!;

        /// <summary>
        ///   The preview url of an image
        /// </summary>
        [JsonProperty(PropertyName = "preview_url")]
        public string PreviewUrl { get; set; } = default!;

        /// <summary>
        ///   The list of full tags that are on the image
        /// </summary>
        [JsonProperty(PropertyName = "tags")]
        public WaifuImTag[] Tags { get; set; } = default!;
    }
}
