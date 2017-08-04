using Newtonsoft.Json;
using PCLStorage;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using XFPCLFile.Models;

namespace XFPCLFile.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public string Title { get; set; }

        public MyPageData PageData { get; set; } = new MyPageData();

        public DelegateCommand SaveCommand { get; set; }
        public DelegateCommand LoadCommand { get; set; }

        public MainPageViewModel()
        {
            SaveCommand = new DelegateCommand(async () =>
            {
                IFolder fooFolder = await FileSystem.Current.LocalStorage.CreateFolderAsync("MyFolder", CreationCollisionOption.OpenIfExists);
                IFile fooFile = await fooFolder.CreateFileAsync("PageData.dat", CreationCollisionOption.ReplaceExisting);
                var fooJson = JsonConvert.SerializeObject(PageData);
                await fooFile.WriteAllTextAsync(fooJson);
            });
            LoadCommand = new DelegateCommand(async () =>
            {
                IFolder fooFolder = await FileSystem.Current.LocalStorage.CreateFolderAsync("MyFolder", CreationCollisionOption.OpenIfExists);
                IFile fooFile = await fooFolder.GetFileAsync("PageData.dat");
                var fooContent = await fooFile.ReadAllTextAsync();
                PageData = JsonConvert.DeserializeObject<MyPageData>(fooContent);
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
