using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace XFGrid.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public double CurrentFontSize { get; set; } = 20;


        public DelegateCommand<string> ChangeFontSizeCommand { get; set; }

        public MainPageViewModel()
        {
            ChangeFontSizeCommand = new DelegateCommand<string>(x =>
            {
                if (x== "1")
                {
                    CurrentFontSize += 4;
                }
                else
                {
                    CurrentFontSize -= 4;
                }
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
