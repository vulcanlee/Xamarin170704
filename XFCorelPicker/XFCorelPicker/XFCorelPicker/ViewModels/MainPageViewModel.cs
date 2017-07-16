using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace XFCorelPicker.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public string SelectedMainCategory { get; set; }
        public string SelectedSubCategory { get; set; }
        public string CustSelectedMainCategory { get; set; }
        public string CustSelectedSubCategory { get; set; }

        public ObservableCollection<string> MainCategoryList { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<string> SubCategoryList { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<string> CustMainCategoryList { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<string> CustSubCategoryList { get; set; } = new ObservableCollection<string>();

        public DelegateCommand MainCategoryChangeCommand { get; set; }
        public DelegateCommand CustMainCategoryChangeCommand { get; set; }

        public MainPageViewModel()
        {
            MainCategoryChangeCommand = new DelegateCommand(() =>
            {
                if (string.IsNullOrEmpty(SelectedMainCategory) == false)
                    SubCategoryList.Clear();
                for (int i = 0; i < 50; i++)
                {
                    SubCategoryList.Add($"{SelectedMainCategory} - {i}");
                }
            });
            CustMainCategoryChangeCommand = new DelegateCommand(() =>
            {
                if (string.IsNullOrEmpty(CustSelectedMainCategory) == false)
                    CustSubCategoryList.Clear();
                for (int i = 0; i < 50; i++)
                {
                    CustSubCategoryList.Add($"{CustSelectedMainCategory} - {i}");
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
            MainCategoryList.Clear();
            for (int i = 0; i < 30; i++)
            {
                MainCategoryList.Add($"主要分類選項 {i}");
            }

            CustMainCategoryList.Clear();
            for (int i = 0; i < 30; i++)
            {
                CustMainCategoryList.Add($"自訂控制項 主要分類選項 {i}");
            }
        }
    }
}
