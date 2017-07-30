using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using XFVisualTree.Models;

namespace XFVisualTree.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {

        public event PropertyChangedEventHandler PropertyChanged;
        public string Title { get; set; }
        public bool GetLabelBC { get; set; } = false;
        public bool GetViewCellBC { get; set; } = false;

        public void OnGetViewCellBCChanged()
        {
            if(GetViewCellBC == true)
            {
                ProductItemList[1].ShowBindingContext = true;
            }
            else
            {
                ProductItemList[1].ShowBindingContext = false;
            }
        }

        public ObservableCollection<ProductItem> ProductItemList { get; set; } = new ObservableCollection<ProductItem>();
        public MainPageViewModel()
        {
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

            for (int i = 0; i < 10; i++)
            {
                ProductItemList.Add(new ProductItem
                {
                     id = i,
                     Name=$"產品名稱{i}",
                     Description=$"規格說明{i}"
                });
            }
        }
    }
}
