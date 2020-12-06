using MoviesFind.Contracts;
using MoviesFind.Helpers;
using MoviesFind.Models.Api;
using MoviesFind.Services.Common;
using System;
using System.Threading.Tasks;

namespace MoviesFind.Services
{
    public class ApiService : HttpBaseService, IApiService
    {
        public async Task<HttpResponse<TrendingApiModel>> GetTrendingMoviesList()
        {
            return await GetAsync<TrendingApiModel>(
                new Uri($"{ConstantHelper.BaseUrl}{ConstantHelper.TrendingApi}?api_key={ConstantHelper.ApiKey}"));
        }
    }
}
