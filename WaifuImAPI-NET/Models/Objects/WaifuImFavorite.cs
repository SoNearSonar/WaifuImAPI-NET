using Newtonsoft.Json;
using WaifuImAPI_NET.Models.Enums;

namespace WaifuImAPI_NET.Models.Objects
{
    public class WaifuImFavorite
    {
        [JsonProperty(PropertyName = "state")]
        public FavoriteStatus FavoriteStatus { get; set; }
    }
}
