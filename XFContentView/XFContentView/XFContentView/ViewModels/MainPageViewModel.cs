using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;

namespace XFContentView.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public string Title { get; set; }

        public MyButtonVM DeleteButton { get; set; } = new MyButtonVM();
        public MyButtonVM SaveButton { get; set; } = new MyButtonVM();

        public MainPageViewModel()
        {
            DeleteButton.BackgroundColor = Color.Pink;
            DeleteButton.ButtonLabel = "刪除";
            DeleteButton.ButtonLabelColor = Color.Black;
            DeleteButton.MyButtonCommand = new DelegateCommand(() =>
            {
                Title = "Your Press 刪除 按鈕";
            });

            SaveButton.BackgroundColor = Color.Green;
            SaveButton.ButtonLabel = "儲存";
            SaveButton.ButtonLabelColor = Color.White;
            SaveButton.MyButtonCommand = new DelegateCommand(() =>
            {
                Title = "Your Press 儲存 按鈕";
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
