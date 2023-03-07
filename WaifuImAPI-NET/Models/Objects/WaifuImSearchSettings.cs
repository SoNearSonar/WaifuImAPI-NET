using Refit;
using WaifuImAPI_NET.Models.Enums;

namespace WaifuImAPI_NET.Models.Objects
{
    /// <summary>
    ///   An object holding search filters for image searches
    /// </summary>
    public class WaifuImSearchSettings
    {
        /// <summary>
        ///   The user ID to be used when searching
        /// </summary>
        [AliasAs("user_id")]
        public uint? UserId { get; set; } = null;

        /// <summary>
        ///   The tags to be included with image searches
        /// </summary>
        /// <value><see cref="Tags"/> array</value>
        [Query(CollectionFormat = CollectionFormat.Multi)]
        [AliasAs("included_tags")]
        public Tags[]? IncludedTags { get; set; } = null;

        /// <summary>
        ///   The tags to be excluded with image searches
        /// </summary>
        /// <value><see cref="Tags"/> array</value>
        [Query(CollectionFormat = CollectionFormat.Multi)]
        [AliasAs("excluded_tags")]
        public Tags[]? ExcludedTags { get; set; } = null;

        /// <summary>
        ///   If image searches should have not safe for work content
        /// </summary>
        [AliasAs("is_nsfw")]
        public bool? IsNsfw { get; set; } = false;

        /// <summary>
        ///   If image searches should return .GIF files only
        /// </summary>
        [AliasAs("gif")]
        public bool? OnlyGif { get; set; } = null;

        /// <summary>
        ///   The order of images meeting the search criteria should be in
        /// </summary>
        /// <value><see cref="Order"/></value>
        [AliasAs("order_by")]
        public Order? OrderBy { get; set; } = null;

        /// <summary>
        ///   The orientation of images meeting the search criteria should be in
        /// </summary>
        /// <value><see cref="Enums.Orientation"/></value>
        [AliasAs("orientation")]
        public Orientation? Orientation { get; set; } = null;

        /// <summary>
        ///   If the image search should return at most 30 images meeting the search criteria
        /// </summary>
        [AliasAs("many")]
        public bool? ManyFiles { get; set; } = null;

        /// <summary>
        ///   If the image search should return every result meeting the search criteria (> 30 images).
        ///   NOTE: For admins only
        /// </summary>
        [AliasAs("full")]
        public bool? FullResult { get; set; } = false;

        /// <summary>
        ///   The image url's or signatures to be included with image searches
        /// </summary>
        /// <value><see cref="string[]"/> array</value>
        [Query(CollectionFormat = CollectionFormat.Multi)]
        [AliasAs("included_files")]
        public string[]? IncludedFiles { get; set; } = null;

        /// <summary>
        ///   The image url's or signatures to be excluded with image searches
        /// </summary>
        /// <value><see cref="string[]"/> array</value>
        [Query(CollectionFormat = CollectionFormat.Multi)]
        [AliasAs("excluded_files")]
        public string[]? ExcludedFiles { get; set; } = null;
    }
}
