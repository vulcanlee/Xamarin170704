using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace XFCanExecute.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public string Title { get; set; }

        // ??????
        // 這裡為什麼需要使用 = ""; 這樣的敘述式呢
        public string YourAccount { get; set; } = "";

        public DelegateCommand LoginCommand { get; set; }

        #region 用來偵測 YourAccount 是否已經有變動
        // https://github.com/Fody/PropertyChanged/wiki/On_PropertyName_Changed
        void OnYourAccountChanged()
        {
            // 當YourAccount 的內容有變動的時候，需要更新指定的 DelegateCommand 物件，
            // 是否可以啟用
            LoginCommand.RaiseCanExecuteChanged();
        }
        #endregion

        public MainPageViewModel()
        {
            LoginCommand = new DelegateCommand(
                () =>
                {
                    Title = YourAccount;
                },
                () =>
                {
                    if (YourAccount.Length > 6)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
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
            if (parameters.ContainsKey("title"))
                Title = (string)parameters["title"] + " and Prism";
        }
    }
}
