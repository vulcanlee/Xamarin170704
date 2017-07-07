using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace XFEventCmd.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public string Title { get; set; }


        public DelegateCommand<string> Btn1Command { get; set; }


        public readonly IPageDialogService _dialogService;
        public MainPageViewModel(IPageDialogService dialogService)
        {

            _dialogService = dialogService;

            Btn1Command = new DelegateCommand<string>(async x =>
            {
                await _dialogService.DisplayAlertAsync("資訊", $"你按下的按鈕是:{x}", "確定");
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
            if (parameters.ContainsKey("title"))
                Title = (string)parameters["title"] + " and Prism";
        }
    }
}
