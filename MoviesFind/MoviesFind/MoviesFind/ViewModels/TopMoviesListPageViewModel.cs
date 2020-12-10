using Acr.UserDialogs;
using MoviesFind.Contracts;
using MoviesFind.Helpers;
using MoviesFind.Models.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using MoviesFind.Extensions;

namespace MoviesFind.ViewModels
{
    public class TopMoviesListPageViewModel : BindableBase, IInitialize
    {
        private readonly IApiManager _apiManager;
        private readonly IUserDialogs _userDialogs;
        private readonly INavigationService _navigationService;
        private ObservableCollection<MovieItemModel> _movies;

        public ObservableCollection<MovieItemModel> Movies
        {
            get { return _movies; }
            set { SetProperty(ref _movies, value); }
        }

        public ICommand MovieSelectedCommand { get; }

        public TopMoviesListPageViewModel(IApiManager apiManager,
            IUserDialogs userDialogs, INavigationService navigationService)
        {
            _apiManager = apiManager;
            _userDialogs = userDialogs;
            _navigationService = navigationService;

            MovieSelectedCommand = new DelegateCommand<MovieItemModel>(MovieSelectedAction);
        }

        public async void Initialize(INavigationParameters parameters)
        {
            _userDialogs.ShowLoading();
            Movies = new ObservableCollection<MovieItemModel>((await _apiManager.GetTopMoviesList())
                .TopMoviesList);

            _userDialogs.HideLoading();
        }

        private async void MovieSelectedAction(MovieItemModel movieModel)
        {
            if (!String.IsNullOrEmpty(movieModel.Title))
            {
               await _navigationService.NavigateAsync<MovieDetailsPageViewModel>(new NavigationParameters() {
                        { ConstantHelper.NavigateToMovieDetailsPage, movieModel }
                    });
            }
        } 
    }
}
