using System.Collections.ObjectModel;

namespace MoviesFind.Models.Views
{
    public class TrendingModel
    {
        public int TotalResults { get; set; }

        public ObservableCollection<MovieItemModel> TrendingMoviesList { get; set; }
    }
}
