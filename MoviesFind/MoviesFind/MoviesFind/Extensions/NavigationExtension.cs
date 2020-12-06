using Prism.Ioc;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MoviesFind.Extensions
{
    public static class NavigationExtension
    {
        public static void RegisterTypeForViewModelNavigation<TView, TViewModel>(this IContainerRegistry container) where TView : Page where TViewModel : class
        {
            var viewType = typeof(TView);
            ViewModelLocationProvider.Register(viewType.ToString(), typeof(TViewModel));
            container.RegisterForNavigation(viewType, typeof(TViewModel).FullName);
        }

        public static Task NavigateAsync<TViewModel>(
            this INavigationService navigationService,
            NavigationParameters parameters = null,
            bool? useModalNavigation = null,
            bool animated = true)
        {
            return navigationService.NavigateAsync(typeof(TViewModel).FullName, parameters, useModalNavigation, animated);
        }

        public static Task ResetNavigation<TMenuViewModel, TNavigationViewModel1, TViewModel>(
            this INavigationService navigationService,
            NavigationParameters parameters = null,
            bool? useModalNavigation = null,
            bool animated = true,
            params string[] deepNavigation) where TViewModel : BindableBase
        {
            var resetNavigationString = $"app:///{typeof(TMenuViewModel).FullName}/{typeof(TNavigationViewModel1).FullName}/{typeof(TViewModel).FullName}";
            if (deepNavigation != null && deepNavigation.Length > 0)
            {
                var deepnavigationString = string.Empty;
                foreach (var page in deepNavigation)
                {
                    deepnavigationString = String.Concat(deepnavigationString, $"/{page}");
                }
                resetNavigationString = String.Concat(resetNavigationString, deepnavigationString);
            }

            return navigationService.NavigateAsync(
                new Uri(
                    resetNavigationString,
                    UriKind.Absolute),
                parameters,
                useModalNavigation,
                animated);
        }

        public static Task ResetNavigation<TViewModel>(
            this INavigationService navigationService,
            NavigationParameters parameters = null,
            bool? useModalNavigation = null,
            bool animated = true)
        {
            var resetNavigationString = $"app:///{typeof(TViewModel).FullName}";
            return navigationService.NavigateAsync(
                new Uri(
                    resetNavigationString,
                    UriKind.Absolute),
                parameters,
                useModalNavigation,
                animated);
        }

        public static Task LogOut<TViewModel>(
            this INavigationService navigationService,
            NavigationParameters parameters = null,
            bool? useModalNavigation = null,
            bool animated = true) where TViewModel : BindableBase
        {
            return navigationService.NavigateAsync($"app:///{typeof(TViewModel).FullName}", parameters, useModalNavigation, animated);

        }

        public static Task StartFromCurrentPage<TNavigationViewModel, TViewModel>(
                this INavigationService navigationService,
                NavigationParameters parameters = null,
                bool? useModalNavigation = null,
                bool animated = true) where TViewModel : BindableBase
        {
            return navigationService.NavigateAsync($"app:///{typeof(TNavigationViewModel).FullName}/{typeof(TViewModel).FullName}", parameters, useModalNavigation, animated);
        }

        public static Task NavigateFromMenuAsync<TNavigationViewModel, TViewModel>(
            this INavigationService navigationService,
            NavigationParameters parameters = null,
            bool? useModalNavigation = null,
            bool animated = true) where TViewModel : BindableBase
        {
            var resetNavigationString = $"{typeof(TNavigationViewModel).FullName}/{typeof(TViewModel).FullName}";
            return navigationService.NavigateAsync(new Uri(resetNavigationString, UriKind.Relative), parameters, useModalNavigation, animated);
        }

        public static Task InitMenu<TMenuViewModel, TNavigationViewModel1, TViewModel>(
            this INavigationService navigationService,
            NavigationParameters parameters = null,
            bool? useModalNavigation = null,
            bool animated = true) where TViewModel : BindableBase
        {

            var resetNavigationString = $"{typeof(TMenuViewModel).FullName}/{typeof(TNavigationViewModel1).FullName}/{typeof(TViewModel).FullName}";

            return navigationService.NavigateAsync(new Uri(resetNavigationString, UriKind.Relative),
                        parameters,
                        useModalNavigation,
                        animated);

        }
    }
}
