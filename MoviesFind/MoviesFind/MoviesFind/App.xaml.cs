using Acr.UserDialogs;
using MoviesFind.Contracts;
using MoviesFind.Extensions;
using MoviesFind.Managers;
using MoviesFind.Services;
using MoviesFind.ViewModels;
using MoviesFind.ViewModels.Common;
using MoviesFind.Views;
using MoviesFind.Views.Common;
using Prism;
using Prism.Ioc;
using Prism.Unity;

namespace MoviesFind
{
    public partial class App : PrismApplication
    {
        public App() : this(null)
        {

        }

        public App(IPlatformInitializer initializer) : base(initializer)
        {

        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.StartFromCurrentPage<BaseNavigationPageViewModel, RootTabbedPageViewModel>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterInstance(UserDialogs.Instance);

            containerRegistry.Register<IApiService, ApiService>();
            containerRegistry.Register<IApiManager, ApiManager>();

            containerRegistry.RegisterTypeForViewModelNavigation<BaseNavigationPage, BaseNavigationPageViewModel>();
            containerRegistry.RegisterTypeForViewModelNavigation<RootTabbedPage, RootTabbedPageViewModel>();
            containerRegistry.RegisterTypeForViewModelNavigation<TrendingListPage, TrendingListPageViewModel>();
        }
    }
}
