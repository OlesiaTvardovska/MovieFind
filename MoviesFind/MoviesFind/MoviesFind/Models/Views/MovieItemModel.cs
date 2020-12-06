using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace MoviesFind.Models.Views
{
    public class MovieItemModel : BindableBase
    {
        public static Action<MovieItemModel> MovieClickedAction;

        public bool Adult { get; set; }

        public int Id { get; set; }

        public string OriginalLanguage { get; set; }

        public string Overview { get; set; }

        public string PosterPath { get; set; }

        public string Title { get; set; }

        public string ReleaseDate { get; set; }
        public ICommand TurnCardCommand
        {
            get
            {
                return new DelegateCommand(() => {
                    MovieClickedAction?.Invoke(this);
                });
            }
        }
    }
}
