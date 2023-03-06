using Refit;

namespace WaifuImAPI_NET.Models.Objects
{
    public class WaifuImFavoriteSettings
    {
        [AliasAs("user_id")]
        public uint? UserId { get; set; } = null;

        [AliasAs("image_id")]
        public uint ImageId { get; set; }
    }
}
