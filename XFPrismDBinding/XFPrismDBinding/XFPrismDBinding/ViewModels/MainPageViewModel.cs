using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace XFPrismDBinding.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {

        #region YourName
        private string _YourName;
        /// <summary>
        /// YourName
        /// </summary>
        public string YourName
        {
            get { return this._YourName; }
            set { this.SetProperty(ref this._YourName, value); }
        }
        #endregion


        #region YourAnswer
        private string _YourAnswer;
        /// <summary>
        /// YourAnswer
        /// </summary>
        public string YourAnswer
        {
            get { return this._YourAnswer; }
            set { this.SetProperty(ref this._YourAnswer, value); }
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
    }
}
