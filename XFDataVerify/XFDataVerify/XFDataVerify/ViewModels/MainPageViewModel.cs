using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace XFDataVerify.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public string Title { get; set; }

        public CustEntryVM Email { get; set; } = new CustEntryVM();
        public CustEntryVM Password { get; set; } = new CustEntryVM();


        public DelegateCommand SaveCommand { get; set; }


        public readonly IPageDialogService _dialogService;
        public MainPageViewModel(IPageDialogService dialogService)
        {

            _dialogService = dialogService;

            SaveCommand = new DelegateCommand(async () =>
            {
                if(Email.WarningTextVisible == true || Password.WarningTextVisible == true)
                {
                    await _dialogService.DisplayAlertAsync("警告", "請輸入正確的電子郵件與密碼", "OK");
                }
                else
                {
                    await _dialogService.DisplayAlertAsync("通知", "資料已經儲存", "OK");
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

            Email.MyEntryPlaceholder = "請輸入電子郵件信箱";
            Email.WarningText = "電子郵件信箱格式不正確";
            Email.WarningTextVisible = true;
            Email.EntryType = MyEntryTextType.Email;

            Password.MyEntryPlaceholder = "請輸入密碼";
            Password.WarningText = "密碼格式不正確，請輸入8個字元以上的密碼";
            Password.WarningTextVisible = true;
            Password.EntryType = MyEntryTextType.Password;
        }
    }
}
