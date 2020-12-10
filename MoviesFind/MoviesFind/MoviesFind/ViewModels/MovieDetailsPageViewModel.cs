using MoviesFind.Helpers;
using MoviesFind.Models.Views;
using Prism.Mvvm;
using Prism.Navigation;

namespace MoviesFind.ViewModels
{
    public class MovieDetailsPageViewModel : BindableBase, IInitialize
    {
        private MovieItemModel _movie;

        public MovieItemModel Movie
        {
            get { return _movie; }
            set { SetProperty(ref _movie, value); }
        }

        public void Initialize(INavigationParameters parameters)
        {
            if (parameters.ContainsKey(ConstantHelper.NavigateToMovieDetailsPage))
            {
                Movie = (MovieItemModel)parameters[ConstantHelper.NavigateToMovieDetailsPage];
            }
        }
    }
}
