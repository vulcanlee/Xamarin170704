using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace XFNaviPara.ViewModels
{
    public class NextPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string YourName { get; set; }
        public string YourAccount { get; set; }


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

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("YourName"))
            {
                YourName = parameters["YourName"] as string;
            }
            if (parameters.ContainsKey("YourAccount"))
            {
                YourAccount = parameters["YourAccount"] as string;
            }
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {

        }
    }
}
