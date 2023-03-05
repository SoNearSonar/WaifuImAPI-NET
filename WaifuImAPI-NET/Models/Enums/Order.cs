using System.Runtime.Serialization;

namespace WaifuImAPI_NET.Models.Enums
{
    public enum Order
    {
        [EnumMember(Value = "FAVOURITES")] Favourites,
        [EnumMember(Value = "UPLOADED_AT")] UploadedAt,
        [EnumMember(Value = "RANDOM")] Random,
        [EnumMember(Value = "LIKED_AT")] Liked_At
    }
}
