using Newtonsoft.Json;
using PCLStorage;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using XFFiles.Models;

namespace XFFiles.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {

        public event PropertyChangedEventHandler PropertyChanged;
        public string Title { get; set; }
        public 使用這登入資訊 使用這登入資訊紀錄 { get; set; } = new 使用這登入資訊();


        public DelegateCommand 登入Command { get; set; }

        public MainPageViewModel()
        {
            登入Command = new DelegateCommand(async () =>
            {
                if (使用這登入資訊紀錄.記憶密碼 == true)
                {
                    string fooStr = JsonConvert.SerializeObject(使用這登入資訊紀錄);

                    // 取得這個應用程式的所在目錄
                    IFolder rootFolder = FileSystem.Current.LocalStorage;
                    // 產生要儲存資料的資料夾
                    IFolder sourceFolder = await rootFolder.CreateFolderAsync("MyDatas", CreationCollisionOption.ReplaceExisting);
                    // 建立要儲存資料的檔案
                    IFile sourceFile = await sourceFolder.CreateFileAsync("使用這登入資訊紀錄.dat", CreationCollisionOption.ReplaceExisting);

                    await sourceFile.WriteAllTextAsync(fooStr);
                }
            });
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {

        }

        public async void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("title"))
                Title = (string)parameters["title"] + " and Prism";

            try
            {
                // 取得這個應用程式的所在目錄
                IFolder rootFolder = FileSystem.Current.LocalStorage;
                // 取得要讀取資料的資料夾目錄
                IFolder sourceFolder = await rootFolder.GetFolderAsync("MyDatas");
                // 判斷這個資料夾內是否有這個檔案存在
                if (await sourceFolder.CheckExistsAsync("使用這登入資訊紀錄.dat") == ExistenceCheckResult.FileExists)
                {
                    // 開啟這個檔案
                    IFile sourceFile = await sourceFolder.GetFileAsync("使用這登入資訊紀錄.dat");

                    // 將檔案內的文字都讀出來
                    var foo使用這登入資訊紀錄 = await sourceFile.ReadAllTextAsync();
                    // 將 Json 文字反序列會成為 .NET 物件
                    var bar使用這登入資訊紀錄 = JsonConvert.DeserializeObject<使用這登入資訊>(foo使用這登入資訊紀錄);

                    // 將讀出的物件，設定到檢視模型內的屬性上
                    //使用這登入資訊紀錄.姓名 = bar使用這登入資訊紀錄.姓名;
                    //使用這登入資訊紀錄.密碼 = bar使用這登入資訊紀錄.密碼;
                    使用這登入資訊紀錄.帳號 = bar使用這登入資訊紀錄.帳號;
                    使用這登入資訊紀錄.記憶密碼 = bar使用這登入資訊紀錄.記憶密碼;
                }
            }
            catch
            { }
        }
    }
}
