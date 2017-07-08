using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace XFToolbarItem.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public string Title { get; set; }



        public DelegateCommand<string> TBCommand { get; set; }



        public readonly IPageDialogService _dialogService;
        public MainPageViewModel(IPageDialogService dialogService)
        {

            _dialogService = dialogService;

            TBCommand = new DelegateCommand<string>(async (x) =>
            {
                await _dialogService.DisplayAlertAsync("Information", $"你選擇的是 {x}", "OK");
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
