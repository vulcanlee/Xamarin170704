using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace XFDisBack.ViewModels
{
    public class NextPageViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;


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
    }
}
