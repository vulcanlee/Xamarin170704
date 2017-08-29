using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Collections.ObjectModel;
using XFCorelPicker2.Helpers;
using System.Threading.Tasks;

namespace XFCorelPicker2.ViewModels
{

    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string Picker1SelectedItem { get; set; }
        public string Picker2SelectedItem { get; set; }
        public string Title { get; set; }


        public ObservableCollection<string> Picker1Source { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<string> Picker2Source { get; set; } = new ObservableCollection<string>();


        public DelegateCommand Picker1SelectedCommand { get; set; }



        private readonly INavigationService _navigationService;

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            Picker1SelectedCommand = new DelegateCommand(async () =>
            {
                var fooBackup = Picker2SelectedItem;
                // 變更到最新的 Picker2 的可選取清單
                Picker2Source = PickerSource.GetPickr2Source(Picker1SelectedItem);
                if(Picker2Source.Contains(fooBackup))
                {
                    await Task.Delay(100);
                    Picker2SelectedItem = Picker2Source.FirstOrDefault(x => x == fooBackup);
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
            Picker1Source = PickerSource.GetPicker1Source();
        }

    }

}
