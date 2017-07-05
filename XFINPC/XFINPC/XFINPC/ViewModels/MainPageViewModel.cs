using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace XFINPC.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {

        public event PropertyChangedEventHandler PropertyChanged;

        #region 一般的用法
        //private string _YourName;

        //public string YourName
        //{
        //    get { return _YourName; }
        //    set
        //    {
        //        if (_YourName != value)
        //        {
        //            _YourName = value;
        //            OnPropertyChanged("YourName");
        //        }

        //    }
        //}

        //private string _YourAnswer;

        //public string YourAnswer
        //{
        //    get { return _YourAnswer; }
        //    set
        //    {
        //        if (_YourName != value)
        //        {
        //            _YourAnswer = value;
        //            OnPropertyChanged("YourAnswer");
        //        }
        //    }
        //}
        #endregion


        #region CallerMemberName 的用法
        private string _YourName;

        public string YourName
        {
            get { return _YourName; }
            set
            {
                if (_YourName != value)
                {
                    _YourName = value;
                    OnPropertyChanged();
                }

            }
        }

        private string _YourAnswer;

        public string YourAnswer
        {
            get { return _YourAnswer; }
            set
            {
                if (_YourName != value)
                {
                    _YourAnswer = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion
        public DelegateCommand LoginCommand { get; set; }


        public MainPageViewModel()
        {
            LoginCommand = new DelegateCommand(() =>
            {
                YourAnswer = "XF: " + YourName;
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

        #region 一般的用法
        //void OnPropertyChanged(string propertyName = "")
        //{
        //    var fooPropertyChanged = PropertyChanged;
        //    if (fooPropertyChanged != null)
        //    {
        //        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        //    }
        //}
        #endregion

        #region CallerMemberName 的用法
        void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var fooPropertyChanged = PropertyChanged;
            if (fooPropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
