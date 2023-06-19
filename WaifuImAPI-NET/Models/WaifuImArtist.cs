using System.Text.Json.Serialization;

namespace WaifuImAPI_NET.Models
{
    /// <summary>
    ///   An object holding the information for an artist for an image
    /// </summary>
    public class WaifuImArtist
    {
        /// <summary>
        ///   The numerical id of the artist
        /// </summary>
        [JsonPropertyName("artist_id")]
        public uint Id { get; set; } = default!;

        /// <summary>
        ///   The name of the artist
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; } = default!;

        /// <summary>
        ///   The artist's Patreon url
        /// </summary>
        [JsonPropertyName("patreon")]
        public string PatreonLink { get; set; } = default!;

        /// <summary>
        ///   The artist's Pixiv url
        /// </summary>
        [JsonPropertyName("pixiv")]
        public string PixivLink { get; set; } = default!;

        /// <summary>
        ///   The artist's Twitter url
        /// </summary>
        [JsonPropertyName("twitter")]
        public string TwitterLink { get; set; } = default!;

        /// <summary>
        ///   The artist's DeviantArt url
        /// </summary>
        [JsonPropertyName("deviant_art")]
        public string DeviantArtLink { get; set; } = default!;
    }
}
