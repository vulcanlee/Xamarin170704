using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFNaviParaCB
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            this.btn.Clicked += async (s, e) =>
             {
                 var fooNextPage = new NextPage();
                 // 使用子頁面的公開屬性來設定要傳遞過去的值
                 //fooNextPage.YourName = YourName.Text;
                 // 使用子頁面的公開方法，來設定要傳遞過去的值
                 fooNextPage.SetYourName(YourName.Text);

                 await this.Navigation.PushAsync(fooNextPage);
             };
        }
    }
}
