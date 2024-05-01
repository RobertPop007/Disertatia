﻿using Newtonsoft.Json;
using System.Collections.Generic;

namespace Disertatie_backend.Entities.Movies
{
    public class Similar
    {
        [JsonProperty("page")]
        public int Page { get; set; }

        [JsonProperty("results")]
        public List<Result> Results { get; set; }

        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }

        [JsonProperty("total_results")]
        public int TotalResults { get; set; }
    }
}
