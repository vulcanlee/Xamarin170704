using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace XFDeepLink.ViewModels
{
    public class Page3PageViewModel : INotifyPropertyChanged, INavigationAware
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public string Title { get; set; }


        public DelegateCommand GoHomeCommand { get; set; }

        private readonly INavigationService _navigationService;
        public Page3PageViewModel(INavigationService navigationService)
        {

            _navigationService = navigationService;

            GoHomeCommand = new DelegateCommand(async () =>
            {
                await _navigationService.NavigateAsync("xf:///NavigationPage/MainPage");
            });
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
        }
    }
}
