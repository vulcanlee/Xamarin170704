using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace XFCustVM.ViewModels
{
    public class MyCustVM : INotifyPropertyChanged, INavigationAware
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public delegate string MyString();

        public MyString MyStringDelegated;

        public string Title { get; set; }
        public string EventLog { get; set; } = "";

        public DelegateCommand SayHelloCommand { get; set; }

        public MyCustVM()
        {
            SayHelloCommand = new DelegateCommand(() =>
            {
                if (MyStringDelegated != null)
                {
                    Title = MyStringDelegated();
                }
                else
                {
                    Title = $"Not Found";
                }
            });
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            System.Diagnostics.Debug.WriteLine("----->>>  OnNavigatedFrom");
            EventLog += "----->>>  OnNavigatedFrom" + "\r\n";
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            System.Diagnostics.Debug.WriteLine("----->>>  OnNavigatedTo");
            EventLog += "----->>>  OnNavigatedTo" + "\r\n";
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            System.Diagnostics.Debug.WriteLine("----->>>  OnNavigatingTo");
            EventLog += "----->>>  OnNavigatingTo" + "\r\n";
        }
    }
}
