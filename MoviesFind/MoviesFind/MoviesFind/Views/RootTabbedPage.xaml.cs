using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoviesFind.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RootTabbedPage : TabbedPage
    {
        public RootTabbedPage()
        {
            InitializeComponent();
        }
    }
}