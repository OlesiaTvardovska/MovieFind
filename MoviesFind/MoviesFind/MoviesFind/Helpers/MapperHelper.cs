using AutoMapper;
using MoviesFind.Models.Api;
using MoviesFind.Models.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MoviesFind.Helpers
{
    public static class MapperHelper
    {
        private static IMapper _mapper;

        public static IMapper Mapper
        {
            get { return _mapper ?? (_mapper = SetupConfiguration()); }
        }

        private static IMapper SetupConfiguration()
        {
            var configuration = new MapperConfiguration(config => {

                config.CreateMap<MovieItemApiModel, MovieItemModel>().AfterMap((apiModel, viewModel) => {
                    viewModel.PosterPath = ConstantHelper.ImageUrl + apiModel.PosterPath;
                });
                config.CreateMap<TrendingApiModel, TrendingModel>().AfterMap((apiModel, viewModel) =>
                {
                    viewModel.TrendingMoviesList = Mapper.Map<ObservableCollection<MovieItemModel>>(apiModel.Results);
                });

            });

            return configuration.CreateMapper();
        }
    }
}
