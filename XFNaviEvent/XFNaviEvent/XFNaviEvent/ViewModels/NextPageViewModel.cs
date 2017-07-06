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
    public class NextPageViewModel : INotifyPropertyChanged, INavigationAware
    {

        public event PropertyChangedEventHandler PropertyChanged;
        public string Title { get; set; }


        public DelegateCommand GoBackCommand { get; set; }


        private readonly INavigationService _navigationService;
        public NextPageViewModel(INavigationService navigationService)
        {

            _navigationService = navigationService;
            GoBackCommand = new DelegateCommand(async () =>
            {
                await _navigationService.GoBackAsync();
            });
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            Debug.WriteLine($"------>>>  下一頁     OnNavigatedFrom");
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            Debug.WriteLine($"------>>>  下一頁     OnNavigatingTo");
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            Debug.WriteLine($"------>>>  下一頁     OnNavigatedTo");

            if (parameters.ContainsKey("title"))
                Title = (string)parameters["title"] + " and Prism";
        }
    }
}
