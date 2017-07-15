using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using XFListView.Models;
using XFListView.Repositories;

namespace XFListView.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public MyTaskItem MyTaskItemSelected { get; set; }

        public ObservableCollection<MyTaskItem> MyTaskItemList { get; set; } = new ObservableCollection<MyTaskItem>();


        public DelegateCommand MyTaskItemSelectedCommand { get; set; }


        public readonly IPageDialogService _dialogService;

        public MainPageViewModel(IPageDialogService dialogService)
        {

            _dialogService = dialogService;

            MyTaskItemSelectedCommand = new DelegateCommand(async () =>
            {
                await _dialogService.DisplayAlertAsync("Info", $"你選取的是 {MyTaskItemSelected.MyTaskName}", "OK");
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
            MyTaskRepository fooMyTaskRepository = new MyTaskRepository();
            var fooTasks = fooMyTaskRepository.GetMyTask();
            foreach (var item in fooTasks)
            {
                MyTaskItemList.Add(new MyTaskItem
                {
                    MyTaskName = item.MyTaskName,
                    MyTaskDate = item.MyTaskDate,
                    MyTaskStatus = item.MyTaskStatus,
                });
            }
        }
    }
}
