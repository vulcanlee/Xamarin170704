using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace XFDialog.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public string Title { get; set; }


        public DelegateCommand 選擇項目Command { get; set; }
        public DelegateCommand 注意事項對話窗Command { get; set; }


        public readonly IPageDialogService _dialogService;
        public MainPageViewModel(IPageDialogService dialogService)
        {

            _dialogService = dialogService;

            選擇項目Command = new DelegateCommand(async () =>
            {
                var fooResult = await _dialogService.DisplayActionSheetAsync("Information", "取消", null, "Option1", "Option2", "Option3", "Option4");
                if (string.IsNullOrEmpty(fooResult))
                {
                    Title = $"你沒有選擇任何項目";
                }
                else
                {
                    Title = $"你回答的是 {fooResult}";
                }
            });
            注意事項對話窗Command = new DelegateCommand(async () =>
            {
                var fooResult = await _dialogService.DisplayAlertAsync("警告", "你的裝置需要連上網際網路，才能正常操作!?", "確定", "取消");
                Title = $"你回答的是 {fooResult}";
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
