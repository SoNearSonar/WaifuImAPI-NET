using System.Text.Json.Serialization;

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
        [JsonPropertyName("signature")]
        public string Signature { get; set; } = default!;

        /// <summary>
        ///   The image file extension of the image
        /// </summary>
        [JsonPropertyName("extension")]
        public string Extension { get; set; } = default!;

        /// <summary>
        ///   The image ID of the image
        /// </summary>
        [JsonPropertyName("image_id")]
        public uint ImageId { get; set; } = default!;

        /// <summary>
        ///   The number of users that favorited the image
        /// </summary>
        [JsonPropertyName("favourites")]
        public uint Favourites { get; set; } = default!;

        /// <summary>
        ///   The main color on the image
        /// </summary>
        [JsonPropertyName("dominant_color")]
        public string DominantColor { get; set; } = default!;

        /// <summary>
        ///   The source url for the image
        /// </summary>
        [JsonPropertyName("source")]
        public string Source { get; set; } = default!;

        /// <summary>
        ///   The time the image was uploaded at
        /// </summary>
        [JsonPropertyName("uploaded_at")]
        public string UploadedAt { get; set; } = default!;

        /// <summary>
        ///   The time the image was liked at
        /// </summary>
        [JsonPropertyName("liked_at")]
        public string LikedAt { get; set; } = default!;

        /// <summary>
        ///   If the image is not safe for work
        /// </summary>
        [JsonPropertyName("is_nsfw")]
        public bool IsNsfw { get; set; } = default!;

        /// <summary>
        ///   The width of an image
        /// </summary>
        [JsonPropertyName("width")]
        public uint Width { get; set; } = default!;

        /// <summary>
        ///   The size in bytes for an image
        /// </summary>
        [JsonPropertyName("byte_size")]
        public ulong ByteSize { get; set; } = default!;

        /// <summary>
        ///   The height of an image
        /// </summary>
        [JsonPropertyName("height")]
        public uint Height { get; set; } = default!;

        /// <summary>
        ///   The url of an image
        /// </summary>
        [JsonPropertyName("url")]
        public string Url { get; set; } = default!;

        /// <summary>
        ///   The preview url of an image
        /// </summary>
        [JsonPropertyName("preview_url")]
        public string PreviewUrl { get; set; } = default!;

        /// <summary>
        ///   The list of full tags that are on the image
        /// </summary>
        [JsonPropertyName("tags")]
        public WaifuImTag[] Tags { get; set; } = default!;

        /// <summary>
        ///   The artist who created the image
        /// </summary>
        [JsonPropertyName("artist")]
        public WaifuImArtist Artist { get; set; } = default!;
    }
}
