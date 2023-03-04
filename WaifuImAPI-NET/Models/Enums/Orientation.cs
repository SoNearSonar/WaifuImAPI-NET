using System.Runtime.Serialization;

namespace WaifuImAPI_NET.Models.Enums
{
    public enum Orientation
    {
        [EnumMember(Value = "LANDSCAPE")] Landscape,
        [EnumMember(Value = "PORTRAIT")] Portrait
    }
}
