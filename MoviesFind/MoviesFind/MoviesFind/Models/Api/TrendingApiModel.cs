using MoviesFind.Models.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoviesFind.Models.Api
{
    public class TrendingApiModel
    {
        [JsonProperty("page")]
        public int Page { get; set; }

        [JsonProperty("results")]
        public MovieItemApiModel[] Results { get; set; }

        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }

        [JsonProperty("total_results")]
        public int TotalResults { get; set; }


    }

}
