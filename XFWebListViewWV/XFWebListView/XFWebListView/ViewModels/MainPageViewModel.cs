using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;
using XFWebListView.Models;

namespace XFWebListView.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public bool ShowProcessingMask { get; set; }
        public ObservableCollection<營建署所屬景點活動> 營建署所屬景點活動清單 { get; set; } = new ObservableCollection<營建署所屬景點活動>();
        public MainPageViewModel()
        {

        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {

        }

        public async void OnNavigatedTo(NavigationParameters parameters)
        {
            // 這段程式碼為何不寫在建構式中
            #region 讀取網路上最新資料清單，並且顯示在螢幕上
            營建署所屬景點活動清單.Clear();

            // 這裡需要加入 Microsoft.Net.Http & Newtonsoft.Json 兩個 NuGet 套件

            ShowProcessingMask = true;
            using (HttpClient client = new HttpClient())
            {
                // 使用非同步方式呼叫，並免應用程式畫面凍結
                var fooReslut = await client.GetStringAsync("http://data.gov.tw/iisi/logaccess/37612?dataUrl=http://data.moi.gov.tw/MoiOD/System/DownloadFile.aspx?DATA=D768074E-932A-4670-B908-0BE1402A7662&ndctype=JSON&ndcnid=7509");

                var foo營建署所屬景點活動s = JsonConvert.DeserializeObject<List<營建署所屬景點活動>>(fooReslut);
                foreach (var item in foo營建署所屬景點活動s)
                {
                    item.WebViewSource = new HtmlWebViewSource(
                        )
                    {
                        Html = item.description
                    };
                    營建署所屬景點活動清單.Add(item);
                }
            }
            await Task.Delay(2000);
            ShowProcessingMask = false;
            #endregion
        }
    }
}
