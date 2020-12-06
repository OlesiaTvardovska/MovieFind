using Acr.UserDialogs;
using MoviesFind.Contracts;
using MoviesFind.Models.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MoviesFind.ViewModels
{
    public class TrendingListPageViewModel : BindableBase, INavigationAware, IInitialize
    {
        private readonly IApiManager _apiManager;
        private readonly IUserDialogs _userDialogs;
        private ObservableCollection<MovieItemModel> _movies;
        private bool _isImageVisible;

        public ObservableCollection<MovieItemModel> Movies
        {
            get { return _movies; }
            set { SetProperty(ref _movies, value); }
        }
        public bool IsImageVisible
        {
            get { return _isImageVisible; }
            set { SetProperty(ref _isImageVisible, value); }
        }

        public ICommand TurnCardCommand { get; }

        public TrendingListPageViewModel(IApiManager apiManager,
            IUserDialogs userDialogs)
        {
            _apiManager = apiManager;
            _userDialogs = userDialogs;
            IsImageVisible = true;

            TurnCardCommand = new DelegateCommand(MovieClickedAction);
        }

        public async void Initialize(INavigationParameters parameters)
        {
            _userDialogs.ShowLoading();

            Movies = new ObservableCollection<MovieItemModel>(
                (await _apiManager.GetTrendingMoviesList())
                .TrendingMoviesList);

            _userDialogs.HideLoading();
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {

        }

        private void MovieClickedAction()
        {
            IsImageVisible = !IsImageVisible;
        }
    }
}