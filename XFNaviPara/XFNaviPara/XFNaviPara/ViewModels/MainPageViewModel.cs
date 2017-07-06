using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace XFNaviPara.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public string Title { get; set; }
        public string YourName { get; set; }
        public string YourAccount { get; set; }


        public DelegateCommand GoNextCommand { get; set; }


        private readonly INavigationService _navigationService;

        public MainPageViewModel(INavigationService navigationService)
        {

            _navigationService = navigationService;

            GoNextCommand = new DelegateCommand(async () =>
            {
                NavigationParameters fooParas = new NavigationParameters();
                fooParas.Add("YourName", YourName);
                fooParas.Add("YourAccount", YourAccount);

                // 直接將導航參數物件傳送過去
                //await _navigationService.NavigateAsync("NextPage", fooParas);

                // 將導航參數物件，轉換成為 QueryString
                string fooQS = fooParas.ToString();
                await _navigationService.NavigateAsync("NextPage" + fooQS);
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
