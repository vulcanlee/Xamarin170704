using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;

namespace XFCommand.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {


        public event PropertyChangedEventHandler PropertyChanged;

        public string Title { get; set; }

        // ?????????????????????????????????????????????
        // 如何知道 TextColor 的物件是甚麼型別呢？
        // https://developer.xamarin.com/api/type/Xamarin.Forms.Label/
        // ?????????????????????????????????????????????

        /// <summary>
        /// 這個屬性將會用於綁定到要顯示文字的顏色
        /// 也就是可以透過 ViewModel 來控制螢幕上文字顏色
        /// </summary>
        public Color CustomTextColor { get; set; }


        // 要能夠抓取頁面上的 CommandParameter 參數，需要使用 DelegateCommand 的泛型型別來宣告物件
        // 請注意 CommandParameter 與 DelegateCommand 的泛型型別 必須一樣，否則無法使用
        public DelegateCommand<string> Btn1Command { get; set; }
        public DelegateCommand<string> Btn2Command { get; set; }



        public MainPageViewModel()
        {
            CustomTextColor = Color.Black;

            // 因為是泛型型別，所以，Lambda 需要有一個傳入參數，該參數值就是 CommandParameter 的內容
            Btn1Command = new DelegateCommand<string>((x) =>
            {
                Title = $"You have pressed: {x}";
                CustomTextColor = Color.Red;
            });
            Btn2Command = new DelegateCommand<string>((x) =>
            {
                Title = $"He have pressed: {x}";
                CustomTextColor = Color.Lime; 
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
