using WaifuImAPI_NET.Models.Enums;

namespace WaifuImAPI_NET.Models.Objects
{
    public class WaifuImImageSettings
    {
        public int? UserId { get; set; } = null;
        public Tags[] IncludedTags { get; set; } = Array.Empty<Tags>();
        public Tags[] ExcludedTags { get; set; } = Array.Empty<Tags>();
        public bool? IsNsfw { get; set; } = false;
        public bool OnlyGif { get; set; } = false;
        public Order OrderBy { get; set; } = Order.Random;
        public Orientation Orientation { get; set; } = Orientation.Portrait;
        public bool ManyFiles { get; set; } = false;
        public bool FullResult { get; set; } = false;
        public string[] IncludedFiles { get; set; } = Array.Empty<string>();
        public string[] ExcludedFiles { get; set; } = Array.Empty<string>();
    }
}
