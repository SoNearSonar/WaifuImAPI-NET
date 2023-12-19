using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace WaifuImAPI_NET.Models
{
    /// <summary>
    /// An object holding report information for an image
    /// </summary>
    public class WaifuImReport
    {
        /// <summary>
        /// The ID of the image that was reported
        /// </summary>
        [JsonPropertyName("image_id")]
        public uint ImageId { get; set; } = default!;

        /// <summary>
        /// The ID of the person who reported the image
        /// </summary>
        [JsonPropertyName("author_id")]
        public ulong AuthorId { get; set; } = default!;

        /// <summary>
        /// The reason for the image being reported
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; } = default!;

        /// <summary>
        /// If the report was already created for the given image
        /// </summary>
        [JsonPropertyName("existed")]
        public bool Existed { get; set; } = default!;
    }
}
