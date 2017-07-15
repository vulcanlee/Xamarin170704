using Prism.Commands;
using Prism.Events;
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
        public bool RefreshingStatus { get; set; }

        public ObservableCollection<MyTaskItem> MyTaskItemList { get; set; } = new ObservableCollection<MyTaskItem>();

        public int RefreshIndex { get; set; } = 0;

        public DelegateCommand MyTaskItemSelectedCommand { get; set; }
        public DelegateCommand MyTaskRefreshCommand { get; set; }
        public DelegateCommand AddCommand { get; set; }


        public readonly IPageDialogService _dialogService;

        private readonly INavigationService _navigationService;

        private readonly IEventAggregator _eventAggregator;

        public MainPageViewModel(IPageDialogService dialogService, INavigationService navigationService,
            IEventAggregator eventAggregator)
        {

            _eventAggregator = eventAggregator;
            _navigationService = navigationService;
            _dialogService = dialogService;

            MyTaskItemSelectedCommand = new DelegateCommand(async () =>
            {
                //await _dialogService.DisplayAlertAsync("Info", $"你選取的是 {MyTaskItemSelected.MyTaskName}", "OK");

                NavigationParameters fooPara = new NavigationParameters();

                // 為什麼這裡需要做 MemberwiseClone，不做，會有甚麼影響
                fooPara.Add("MyTaskItem", MyTaskItemSelected.Clone() as MyTaskItem);
                fooPara.Add("Mode", "Edit");
                await _navigationService.NavigateAsync("TaskDetailPage", fooPara);
            });

            AddCommand = new DelegateCommand(async () =>
            {
                NavigationParameters fooPara = new NavigationParameters();
                fooPara.Add("Mode", "Add");
                await _navigationService.NavigateAsync("TaskDetailPage", fooPara);
            });

            MyTaskRefreshCommand = new DelegateCommand(() =>
            {
                RefreshIndex++;
                MyTaskItemList.Clear();
                MyTaskRepository fooMyTaskRepository = new MyTaskRepository();
                var fooTasks = fooMyTaskRepository.GetMyTask();
                foreach (var item in fooTasks)
                {
                    MyTaskItemList.Add(new MyTaskItem
                    {
                        MyTaskName = $"{RefreshIndex} {item.MyTaskName}",
                        MyTaskDate = item.MyTaskDate,
                        MyTaskStatus = item.MyTaskStatus,
                    });
                }
                RefreshingStatus = false;
            });

            _eventAggregator.GetEvent<MyTaskItemEvent>().Subscribe(x =>
            {
                var fooEditTask = MyTaskItemList.FirstOrDefault(s => s.MyTaskName == x.MyTaskItemSelected.MyTaskName);
                if (x.TaskMode == "Edit")
                {
                    if (fooEditTask != null)
                    {
                        fooEditTask.MyTaskDate = x.MyTaskItemSelected.MyTaskDate;
                        fooEditTask.MyTaskStatus = x.MyTaskItemSelected.MyTaskStatus;
                    }
                }
                else if (x.TaskMode == "Delete")
                {
                    if(fooEditTask!=null)
                    {
                        MyTaskItemList.Remove(fooEditTask);
                    }
                }
                else
                {
                    MyTaskItemList.Insert(0, x.MyTaskItemSelected);
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
