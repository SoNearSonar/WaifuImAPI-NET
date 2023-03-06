using Refit;
using WaifuImAPI_NET.Models.Enums;

namespace WaifuImAPI_NET.Models.Objects
{
    public class WaifuImSearchSettings
    {
        [AliasAs("user_id")]
        public uint? UserId { get; set; } = null;

        [Query(CollectionFormat = CollectionFormat.Multi)]
        [AliasAs("included_tags")]
        public Tags[]? IncludedTags { get; set; } = null;

        [Query(CollectionFormat = CollectionFormat.Multi)]
        [AliasAs("excluded_tags")]
        public Tags[]? ExcludedTags { get; set; } = null;

        [AliasAs("is_nsfw")]
        public bool? IsNsfw { get; set; } = false;

        [AliasAs("gif")]
        public bool? OnlyGif { get; set; } = null;

        [AliasAs("order_by")]
        public Order? OrderBy { get; set; } = null;

        [AliasAs("orientation")]
        public Orientation? Orientation { get; set; } = null;

        [AliasAs("many")]
        public bool? ManyFiles { get; set; } = null;

        [AliasAs("full")]
        public bool? FullResult { get; set; } = false;

        [Query(CollectionFormat = CollectionFormat.Multi)]
        [AliasAs("included_files")]
        public string[]? IncludedFiles { get; set; } = null;

        [Query(CollectionFormat = CollectionFormat.Multi)]
        [AliasAs("excluded_files")]
        public string[]? ExcludedFiles { get; set; } = null;
    }
}
