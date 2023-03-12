using Newtonsoft.Json;

namespace WaifuImAPI_NET.Models
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
