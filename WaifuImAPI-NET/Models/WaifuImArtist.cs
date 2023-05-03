using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        [JsonProperty(PropertyName = "artist_id")]
        public uint Id { get; set; } = default!;

        /// <summary>
        ///   The name of the artist
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; } = default!;

        /// <summary>
        ///   The artist's Patreon url
        /// </summary>
        [JsonProperty(PropertyName = "patreon")]
        public string PatreonLink { get; set; } = default!;

        /// <summary>
        ///   The artist's Pixiv url
        /// </summary>
        [JsonProperty(PropertyName = "pixiv")]
        public string PixivLink { get; set; } = default!;

        /// <summary>
        ///   The artist's Twitter url
        /// </summary>
        [JsonProperty(PropertyName = "twitter")]
        public string TwitterLink { get; set; } = default!;

        /// <summary>
        ///   The artist's DeviantArt url
        /// </summary>
        [JsonProperty(PropertyName = "deviant_art")]
        public string DeviantArtLink { get; set; } = default!;
    }
}
