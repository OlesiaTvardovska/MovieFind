using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MoviesFind.Models.Views
{
    public class TopMoviesListModel
    {
        public int TotalResults { get; set; }

        public ObservableCollection<MovieItemModel> TopMoviesList { get; set; }
    }
}
