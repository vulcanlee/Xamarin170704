using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace XFViewHidden.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public bool Label1Visible { get; set; } = true;
        public bool Label2Visible { get; set; } = true;
        public string Btn1Text { get; set; }
        public string Btn2Text { get; set; }


        public DelegateCommand Btn1Command { get; set; }
        public DelegateCommand Btn2Command { get; set; }


        public MainPageViewModel()
        {
            Btn1Text = "隱藏 文字1";
            Btn2Text = "隱藏 文字2";
            Btn1Command = new DelegateCommand(() =>
            {
                if (Btn1Text == "隱藏 文字1")
                {
                    Btn1Text = "顯示 文字1";
                    Label1Visible = false;
                }
                else
                {
                    Btn1Text = "隱藏 文字1";
                    Label1Visible = true;
                }
            });
            Btn2Command = new DelegateCommand(() =>
            {
                if (Btn2Text == "隱藏 文字2")
                {
                    Btn2Text = "顯示 文字2";
                    Label2Visible = false;
                }
                else
                {
                    Btn2Text = "隱藏 文字2";
                    Label2Visible = true;
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
