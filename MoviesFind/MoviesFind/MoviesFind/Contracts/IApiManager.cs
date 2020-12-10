using MoviesFind.Models.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoviesFind.Contracts
{
    public interface IApiManager
    {
        Task<TrendingModel> GetTrendingMoviesList(bool showLoading = true);

        Task<TopMoviesListModel> GetTopMoviesList(bool showLoading = true);
    }
}
