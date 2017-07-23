using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace XFCustPicker.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public string Title { get; set; }
        public string PickerSelected { get; set; }
        public string PickerSelectedTitle { get; set; }

        public ObservableCollection<string> PickerVM { get; set; } = new ObservableCollection<string>();


        public DelegateCommand<string> SelectedIndexChangedCommand { get; set; }

        public MainPageViewModel()
        {
            SelectedIndexChangedCommand = new DelegateCommand<string>((x) =>
            {
                PickerSelectedTitle = x;
            });

            PickerVM.Clear();
            PickerVM.Add("Item1");
            PickerVM.Add("Item2");
            PickerVM.Add("Item3");
            PickerVM.Add("Item4");
            PickerVM.Add("Item5");
            PickerVM.Add("Item6");
            PickerVM.Add("Item7");

            PickerSelectedTitle = "這裡是由 SelectedItem 資料綁定自動設定";
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
