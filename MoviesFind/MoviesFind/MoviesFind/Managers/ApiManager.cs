using Acr.UserDialogs;
using AutoMapper;
using MoviesFind.Contracts;
using MoviesFind.Helpers;
using MoviesFind.Models.Api;
using MoviesFind.Models.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoviesFind.Managers
{
    public class ApiManager : IApiManager
    {
        private readonly IApiService _apiService;
        private readonly IUserDialogs _userDialogs;
        private readonly IMapper _mapper;

        public ApiManager(IApiService apiService, IUserDialogs userDialogs)
        {
            _apiService = apiService;
            _userDialogs = userDialogs;
            _mapper = MapperHelper.Mapper;
        }

        public async Task<TrendingModel> GetTrendingMoviesList(bool showLoading = true)
        {
            if (showLoading)
            {
                _userDialogs.ShowLoading();
            }
            var response = await _apiService.GetTrendingMoviesList();
            if (showLoading)
            {
                _userDialogs.HideLoading();
            }

            if (response.IsSuccessful)
            {
                var aa=  _mapper.Map<TrendingModel>(response.Data);
                return aa;
            }

            await _userDialogs.AlertAsync(response.ErrorMessage);
            return new TrendingModel();
        }

        public async Task<TopMoviesListModel> GetTopMoviesList(bool showLoading = true)
        {
            if (showLoading)
            {
                _userDialogs.ShowLoading();
            }
            var response = await _apiService.GetTopMoviesList();
            if (showLoading)
            {
                _userDialogs.HideLoading();
            }

            if (response.IsSuccessful)
            {
                var aa = _mapper.Map<TopMoviesListModel>(response.Data);
                return aa;
            }

            await _userDialogs.AlertAsync(response.ErrorMessage);
            return new TopMoviesListModel();
        }
    }
}
