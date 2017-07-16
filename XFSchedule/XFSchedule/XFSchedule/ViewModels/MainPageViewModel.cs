using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using XFSchedule.Models;

namespace XFSchedule.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<ExerciseClass> Classes { get; set; } = new ObservableCollection<ExerciseClass>();

        public ExerciseClass ClassesSelectedItem { get; set; }

        public DelegateCommand ListTappedCommand { get; set; }

        public MainPageViewModel()
        {
            ListTappedCommand = new DelegateCommand(() =>
            {
                //請試著將底下程式碼註解起來，看看有何不同執行結果
                ClassesSelectedItem = null;
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
            DataFactory();
        }

        void DataFactory()
        {
            Classes = new ObservableCollection<ExerciseClass>
            {
                new ExerciseClass
                {
                    ClassName = "Yoga",
                    Instructor = "Maharshi Patanjali",
                    ClassTime = TodayAt(8,00),
                },
                 new ExerciseClass
                {
                    ClassName = "ABS + Stretch",
                    Instructor = "David Hasslehoff",
                    ClassTime = TodayAt(9,30),
                },
                 //new ExerciseClass
                //{
                //    ClassName = "Body Sculpt",
                //    Instructor = "Sadie Terry",
                //    ClassTime = DateTime.Now.AddHours(3),
                //},
                 new ExerciseClass
                {
                    ClassName = "Cycle",
                    Instructor = "Lance Armstrong",
                    ClassTime = TodayAt(12,00),
                },
                 new ExerciseClass
                {
                    ClassName = "Aerobics",
                    Instructor = "Jacky Chan",
                    ClassTime = TodayAt(15,30),
                },
                 new ExerciseClass
                {
                    ClassName = "Weights",
                    Instructor = "Arnold Schwarzenegger",
                    ClassTime = TodayAt(18,00),
                    IsLast = true
                },
            };
        }

        DateTime TodayAt(int hour, int minute)
        {
            return new DateTime(DateTime.Now.Year,
                DateTime.Now.Month,
                DateTime.Now.Day,
                hour, minute, 0);
        }
    }
}
