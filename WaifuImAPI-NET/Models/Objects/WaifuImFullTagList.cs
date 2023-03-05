﻿using Newtonsoft.Json;

namespace WaifuImAPI_NET.Models.Objects
{
    public class WaifuImFullTagList
    {
        [JsonProperty(PropertyName = "versatile")]
        public WaifuImTag[]? VersatileTags { get; set; }

        [JsonProperty(PropertyName = "nsfw")]
        public WaifuImTag[]? NsfwTags { get; set; }
    }
}
