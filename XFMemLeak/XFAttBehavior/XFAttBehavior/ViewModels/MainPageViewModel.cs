using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;

namespace XFAttBehavior.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public string Title { get; set; }


        public DelegateCommand ReloadCommand { get; set; }

        private readonly INavigationService _navigationService;
        public MainPageViewModel(INavigationService navigationService)
        {

            _navigationService = navigationService;

            ReloadCommand = new DelegateCommand(async () =>
            {
                await _navigationService.NavigateAsync("xf:///MainPage");
            });
        }

        ~ MainPageViewModel()
        {
            Debug.WriteLine($"--------------->>> ~ MainPageViewModel");
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("title"))
                Title = (string)parameters["title"] + " and Prism";
        }
    }
}
