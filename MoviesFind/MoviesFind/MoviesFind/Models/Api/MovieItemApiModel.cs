using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoviesFind.Models.Api
{
    public class MovieItemApiModel
    {
        [JsonProperty("adult")]
        public bool Adult { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("original_language")]
        public string OriginalLanguage { get; set; }

        [JsonProperty("overview")]
        public string Overview { get; set; }

        [JsonProperty("poster_path")]
        public string PosterPath { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("release-date")]
        public string ReleaseDate { get; set; }

        [JsonProperty("vote_average")]
        public string VoteAvg { get; set; }
    }
}
