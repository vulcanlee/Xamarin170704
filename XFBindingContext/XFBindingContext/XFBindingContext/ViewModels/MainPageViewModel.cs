using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace XFBindingContext.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public string Title { get; set; }

        public ObservableCollection<MyItem> MyListItems { get; set; } = new ObservableCollection<MyItem>();

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

            for (int i = 0; i < 500; i++)
            {
                var fooObject = new MyItem
                {
                    Name = $"Item Name :{i}",
                    ID = i,
                };
                MyListItems.Add(fooObject);
            }
        }
    }

    public class MyItem
    {
        public string Name { get; set; }
        public int ID { get; set; }
    }
}
