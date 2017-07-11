using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;

namespace XFCommand.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public string Title { get; set; }


        public DelegateCommand<string> BtnCommand { get; set; }

        public DelegateCommand<Button> Btn3Command { get; set; }


        public MainPageViewModel()
        {
            BtnCommand = new DelegateCommand<string>((x) =>
            {
                Title = x;
            });

            Btn3Command = new DelegateCommand<Button>(x =>
            {
                Title = $"這是綁定 Button 參數 : {x.Text}";
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
