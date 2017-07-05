using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace XFFodyDBinding.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        public string YourName { get; set; }
        public string YourAnswer { get; set; }

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
