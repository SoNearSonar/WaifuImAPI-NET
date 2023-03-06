using System.Runtime.Serialization;

namespace WaifuImAPI_NET.Models.Enums
{
    public enum FavoriteStatus
    {
        [EnumMember(Value = "DELETED")] Deleted,
        [EnumMember(Value = "INSERTED")] Inserted
    }
}
