using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;

namespace XFNaviEvent.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {

        public event PropertyChangedEventHandler PropertyChanged;
        public string Title { get; set; }


        public DelegateCommand GoNextPageCommand { get; set; }


        private readonly INavigationService _navigationService;
        public MainPageViewModel(INavigationService navigationService)
        {

            _navigationService = navigationService;
            GoNextPageCommand = new DelegateCommand(async () =>
            {
                await _navigationService.NavigateAsync("NextPage");
            });
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            Debug.WriteLine($"------>>>  主頁面     OnNavigatedFrom");
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            Debug.WriteLine($"------>>>  主頁面     OnNavigatingTo");
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            Debug.WriteLine($"------>>>  主頁面     OnNavigatedTo");

            if (parameters.ContainsKey("title"))
                Title = (string)parameters["title"] + " and Prism";
        }
    }
}
