using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace XFAnimation.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public string Title { get; set; }

        public DelegateCommand 下一頁Command { get; private set; }
        public DelegateCommand 各自動畫Command { get; private set; }
        public DelegateCommand 串接動畫Command { get; private set; }

        public Func<Task> 各自動畫Delegate;
        public Func<Task> 串接動畫Delegate;
        public Func<Task> 頁面消失動畫Delegate;
        
        private readonly INavigationService _navigationService;
        public MainPageViewModel(INavigationService navigationService)
        {

            _navigationService = navigationService;

            下一頁Command = new DelegateCommand(async () =>
            {
                await 頁面消失動畫Delegate();
                await Task.Delay(1000);
                await _navigationService.NavigateAsync("NewPage", null, null, false);
            });
            各自動畫Command = new DelegateCommand(async () =>
            {
                await 各自動畫Delegate();
            });
            串接動畫Command = new DelegateCommand(async () =>
            {
                await 串接動畫Delegate();
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
