using MoviesFind.Models.Api;
using MoviesFind.Services.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoviesFind.Contracts
{
    public interface IApiService
    {
        Task<HttpResponse<TrendingApiModel>> GetTrendingMoviesList();


    }
}
