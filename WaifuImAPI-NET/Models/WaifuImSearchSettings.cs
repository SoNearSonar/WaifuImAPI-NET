﻿namespace WaifuImAPI_NET.Models
{
    /// <summary>
    ///   An object holding search filters for image searches
    /// </summary>
    public class WaifuImSearchSettings
    {
        /// <summary>
        ///   The tags to be included with image searches
        /// </summary>
        /// <value><see cref="Tags"/> array</value>
        public Tags[]? IncludedTags { get; set; } = null;

        /// <summary>
        ///   The tags to be excluded with image searches
        /// </summary>
        /// <value><see cref="Tags"/> array</value>
        public Tags[]? ExcludedTags { get; set; } = null;

        /// <summary>
        ///   If image searches should have not safe for work content
        /// </summary>
        public bool? IsNsfw { get; set; } = false;

        /// <summary>
        ///   If image searches should return .GIF files only
        /// </summary>
        public bool? OnlyGif { get; set; } = null;

        /// <summary>
        ///   The order of images meeting the search criteria should be in
        /// </summary>
        /// <value><see cref="Order"/></value>
        public Order? OrderBy { get; set; } = null;

        /// <summary>
        ///   The orientation of images meeting the search criteria should be in
        /// </summary>
        /// <value><see cref="Enums.Orientation"/></value>
        public Orientation? Orientation { get; set; } = null;

        /// <summary>
        ///   The preferred height for an image
        /// </summary>
        public string? Height { get; set; } = null;

        /// <summary>
        ///   The preferred width for an image
        /// </summary>
        public string? Width { get; set; } = null;

        /// <summary>
        ///   The size in bytes for an image
        /// </summary>
        public string? ByteSize { get; set; } = null;

        /// <summary>
        ///   If the image search should return at most 30 images meeting the search criteria
        /// </summary>
        public bool? ManyFiles { get; set; } = null;

        /// <summary>
        ///   If the image search should return every result meeting the search criteria (> 30 images).
        ///   NOTE: For admins only
        /// </summary>
        public bool? FullResult { get; set; } = false;

        /// <summary>
        ///   The image url's or signatures to be included with image searches
        /// </summary>
        /// <value><see cref="string[]"/> array</value>
        public string[]? IncludedFiles { get; set; } = null;

        /// <summary>
        ///   The image url's or signatures to be excluded with image searches
        /// </summary>
        /// <value><see cref="string[]"/> array</value>
        public string[]? ExcludedFiles { get; set; } = null;
    }
}
