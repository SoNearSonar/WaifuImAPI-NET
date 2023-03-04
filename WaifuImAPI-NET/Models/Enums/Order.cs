using System.Runtime.Serialization;

namespace WaifuImAPI_NET.Models.Enums
{
    public enum Order
    {
        [EnumMember(Value = "FAVORURITE")] Favorite,
        [EnumMember(Value = "UPLOADED_AT")] UploadedAt,
        [EnumMember(Value = "RANDOM")] Random
    }
}
