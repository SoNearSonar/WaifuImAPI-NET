using System.Runtime.Serialization;

namespace WaifuImAPI_NET.Models
{
    /// <summary>
    /// The preferred rotation to look for when searching for images
    /// </summary>
    public enum Orientation
    {
        /// <summary>
        /// Either landscape or portrait
        /// </summary>
        [EnumMember(Value = "RANDOM")] Random,

        /// <summary>
        /// Landscape mode (width is greater than height)
        /// </summary>
        [EnumMember(Value = "LANDSCAPE")] Landscape,

        /// <summary>
        /// Portrait mode (height is greater than width)
        /// </summary>
        [EnumMember(Value = "PORTRAIT")] Portrait
    }
}
