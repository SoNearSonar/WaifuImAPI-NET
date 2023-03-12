using System.Runtime.Serialization;

namespace WaifuImAPI_NET.Models
{
    /// <summary>
    /// A status to represent the result of a API call
    /// </summary>
    public enum FavoriteStatus
    {
        /// <summary>
        /// Favorite was removed
        /// </summary>
        [EnumMember(Value = "DELETED")] Deleted,

        /// <summary>
        /// Favorite was added
        /// </summary>
        [EnumMember(Value = "INSERTED")] Inserted
    }
}
