using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;

namespace XFStackLayout.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {

        public event PropertyChangedEventHandler PropertyChanged;


        public ObservableCollection<Color> ColorList { get; set; } = new ObservableCollection<Color>();

        public MainPageViewModel()
        {
            ColorList.Add(Color.Aqua);
            ColorList.Add(Color.Blue);
            ColorList.Add(Color.Fuchsia);
            ColorList.Add(Color.Silver);
            ColorList.Add(Color.Maroon);
            ColorList.Add(Color.Orange);
            ColorList.Add(Color.Purple);
            ColorList.Add(Color.Teal);
            ColorList.Add(Color.Red);
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
