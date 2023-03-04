using Newtonsoft.Json;

namespace WaifuImAPI_NET.Models.Objects
{
    public class WaifuImImage
    {
        [JsonProperty(PropertyName = "signature")]
        public string? Signature { get; set; }

        [JsonProperty(PropertyName = "extension")]
        public string? Extension { get; set; }

        [JsonProperty(PropertyName = "image_id")]
        public uint? ImageId { get; set; }

        [JsonProperty(PropertyName = "favourites")]
        public uint? Favourites { get; set; }

        [JsonProperty(PropertyName = "dominant_color")]
        public string? DominantColor { get; set; }

        [JsonProperty(PropertyName = "source")]
        public string? Source { get; set; }

        [JsonProperty(PropertyName = "uploaded_at")]
        public string? UploadedAt { get; set; }

        [JsonProperty(PropertyName = "liked_at")]
        public string? LikedAt { get; set; }

        [JsonProperty(PropertyName = "is_nsfw")]
        public bool? IsNsfw { get; set; }

        [JsonProperty(PropertyName = "width")]
        public uint? Width { get; set; }

        [JsonProperty(PropertyName = "height")]
        public uint? Height { get; set; }

        [JsonProperty(PropertyName = "url")]
        public string? Url { get; set; }

        [JsonProperty(PropertyName = "preview_url")]
        public string? PreviewUrl { get; set; }

        [JsonProperty(PropertyName = "tags")]
        public WaifuImTag[]? Tags { get; set; }
    }
}
