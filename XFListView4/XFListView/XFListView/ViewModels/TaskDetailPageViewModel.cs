using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using XFListView.Models;
using Prism.Navigation;
using Prism.Events;

namespace XFListView.ViewModels
{
    public class TaskDetailPageViewModel : INotifyPropertyChanged, INavigationAware
    {

        public event PropertyChangedEventHandler PropertyChanged;
        public MyTaskItem MyTaskItemSelected { get; set; }
        public string TaskMode { get; set; }

        public DelegateCommand DeleteCommand { get; set; }
        public DelegateCommand SaveCommand { get; set; }
        public bool DeleteBtnVbl { get; set; } = true;
        public int SaveCommandColumn { get; set; } = 1;
        public int SaveCommandColumnSpan { get; set; } = 1;


        private readonly INavigationService _navigationService;
        private readonly IEventAggregator _eventAggregator;

        public TaskDetailPageViewModel(IEventAggregator eventAggregator, INavigationService navigationService)
        {

            _eventAggregator = eventAggregator;
            _navigationService = navigationService;

            DeleteCommand = new DelegateCommand(async () =>
           {
               _eventAggregator.GetEvent<MyTaskItemEvent>().Publish(new MyTaskItemPayload
               {
                   MyTaskItemSelected = MyTaskItemSelected,
                   TaskMode = "Delete",
               });
               await _navigationService.GoBackAsync();
           });
            SaveCommand = new DelegateCommand(async () =>
           {
               _eventAggregator.GetEvent<MyTaskItemEvent>().Publish(new MyTaskItemPayload
               {
                   MyTaskItemSelected = MyTaskItemSelected,
                   TaskMode = TaskMode,
               });
               await _navigationService.GoBackAsync();
           });
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("Mode"))
            {
                TaskMode = parameters["Mode"] as string;
                if (TaskMode == "Edit")
                {
                    MyTaskItemSelected = parameters["MyTaskItem"] as MyTaskItem;
                    DeleteBtnVbl = true;
                }
                else
                {
                    MyTaskItemSelected = new MyTaskItem();
                    DeleteBtnVbl = false;
                    SaveCommandColumn = 0;
                    SaveCommandColumnSpan = 2;
                }
            }
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
        }
    }
}
