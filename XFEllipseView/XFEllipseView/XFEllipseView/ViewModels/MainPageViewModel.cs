using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace XFEllipseView.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }


        #region BadgeViewModel項目
        private BadgeViewModel _BadgeViewModel項目 = new BadgeViewModel();
        /// <summary>
        /// BadgeViewModel項目
        /// </summary>
        public BadgeViewModel BadgeViewModel項目
        {
            get { return this._BadgeViewModel項目; }
            set { this.SetProperty(ref this._BadgeViewModel項目, value); }
        }
        #endregion

        #region BadgeViewModel警告
        private BadgeViewModel _BadgeViewModel警告=new BadgeViewModel();
        /// <summary>
        /// BadgeViewModel警告
        /// </summary>
        public BadgeViewModel BadgeViewModel警告
        {
            get { return this._BadgeViewModel警告; }
            set { this.SetProperty(ref this._BadgeViewModel警告, value); }
        }
        #endregion


        public readonly IPageDialogService _dialogService;

        /// <summary>
        /// 這個命令，將會綁定到使用者控制項上，當使用者點選這個使用這控制項的時候，會觸發這個命令
        /// </summary>
        public DelegateCommand 點選BadgeCommand { get; set; }
        /// <summary>
        /// 這個命令，將會綁定到使用者控制項上，當使用者點選這個使用這控制項的時候，會觸發這個命令，並且將當時徽章的綁定的ViewModel帶進來
        /// </summary>
        public DelegateCommand<BadgeViewModel> 點選Badge帶參數Command { get; set; }

        // 為了要使用對話窗，在這裡使用了相依性服務，注入了對話窗服務實作物件
        public MainPageViewModel(IPageDialogService dialogService)
        {
            // ?? 請思考看看，為什麼要宣告一個 命令 Field，把注入的物件設定給 Field 呢?
            _dialogService = dialogService;

            點選BadgeCommand = new DelegateCommand(() =>
            {
                _dialogService.DisplayAlertAsync("", "Pressed", "OK");
            });

            點選Badge帶參數Command = new DelegateCommand<BadgeViewModel>(x =>
            {
                _dialogService.DisplayAlertAsync("", $"Pressed {x.BadgeText}", "OK");
            });
        }
        

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("title"))
                Title = (string)parameters["title"] + " and Prism";

            //進行徽章使用者控制項需要用到的ViewModel資料初始化
            BadgeViewModel項目.BadgeColor = Color.Blue;
            BadgeViewModel項目.BadgeText = "23";
            BadgeViewModel警告.BadgeColor = Color.Green;
            BadgeViewModel警告.BadgeText = "99+";
        }
    }
}
