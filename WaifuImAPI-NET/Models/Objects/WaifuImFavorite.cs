using Newtonsoft.Json;
using WaifuImAPI_NET.Models.Enums;

namespace WaifuImAPI_NET.Models.Objects
{
    /// <summary>
    ///   An object holding the status of a favorite API call
    /// </summary>
    public class WaifuImFavorite
    {
        /// <summary>
        /// The result of the favorite API call
        /// </summary>
        /// <value><see cref="Enums.FavoriteStatus"/></value>
        [JsonProperty(PropertyName = "state")]
        public FavoriteStatus FavoriteStatus { get; set; }
    }
}
