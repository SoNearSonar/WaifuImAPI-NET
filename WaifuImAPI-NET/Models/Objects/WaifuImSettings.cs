using WaifuImAPI_NET.Models.Enums;

namespace WaifuImAPI_NET.Models.Objects
{
    public class WaifuImSettings
    {
        public Tags[] IncludedTags { get; set; } = new Tags[0];
        public Tags[] ExcludedTags { get; set; } = new Tags[0];
        public bool? IsNsfw { get; set; } = null;
        public bool OnlyGif { get; set; } = false;
        public Order OrderBy { get; set; } = Order.Random;
        public Orientation Orientation { get; set; } = Orientation.Portrait;
        public bool ManyFiles { get; set; } = false;
        public bool FullResult { get; set; } = false;
        public string[] IncludedFiles { get; set; } = new string[0];
        public string[] ExcludedFiles { get; set; } = new string[0];
    }
}
