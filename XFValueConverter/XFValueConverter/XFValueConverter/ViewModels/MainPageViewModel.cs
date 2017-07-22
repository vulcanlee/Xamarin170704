using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace XFValueConverter.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {


        public event PropertyChangedEventHandler PropertyChanged;

        public string Title { get; set; }
        public string YourAnswer { get; set; }
        public string YourColor { get; set; }


        public MainPageViewModel()
        {

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
