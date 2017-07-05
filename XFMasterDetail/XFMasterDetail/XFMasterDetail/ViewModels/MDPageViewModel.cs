using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace XFMasterDetail.ViewModels
{
    public class MDPageViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;


        public DelegateCommand GoP1Command { get; set; }
        public DelegateCommand GoP2Command { get; set; }
        public DelegateCommand GoHomeCommand { get; set; }



        private readonly INavigationService _navigationService;
        public MDPageViewModel(INavigationService navigationService)
        {

            _navigationService = navigationService;

            GoP1Command = new DelegateCommand(async () =>
            {
                await _navigationService.NavigateAsync("xf:///MDPage/NaviPage/Page1Page");
            });
            GoP2Command = new DelegateCommand(async () =>
            {
                await _navigationService.NavigateAsync("xf:///MDPage/NaviPage/Page2Page");
            });
            GoHomeCommand = new DelegateCommand(async () =>
            {
                await _navigationService.NavigateAsync("xf:///MDPage/NaviPage/MainPage");
            });
        }
    }
}
