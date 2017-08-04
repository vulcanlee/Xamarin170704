using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace XFAppProp.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public string Title { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int Amt { get; set; }
        public bool IsMemory { get; set; }


        public DelegateCommand SaveCommand { get; set; }
        public DelegateCommand LoadCommand { get; set; }


        public MainPageViewModel()
        {
            SaveCommand = new DelegateCommand(async () =>
            {
                App.Current.Properties["Name"] = Name;
                App.Current.Properties["Date"] = Date;
                App.Current.Properties["Amt"] = Amt;
                App.Current.Properties["IsMemory"] = IsMemory;
                await App.Current.SavePropertiesAsync();
            });
            LoadCommand = new DelegateCommand(() =>
            {
                // 在這裡，若一開始就讀取，會有甚麼結果呢？
                Name = App.Current.Properties["Name"] as string;
                Date = (DateTime)App.Current.Properties["Date"];
                Amt = (int)App.Current.Properties["Amt"];
                IsMemory = (bool)App.Current.Properties["IsMemory"];
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
