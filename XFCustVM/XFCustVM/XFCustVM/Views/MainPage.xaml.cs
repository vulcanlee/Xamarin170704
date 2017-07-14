using Xamarin.Forms;
using XFCustVM.ViewModels;

namespace XFCustVM.Views
{
    public partial class MainPage : ContentPage
    {
        MyCustVM fooMyCustVM;
        public MainPage()
        {
            InitializeComponent();

            fooMyCustVM = this.BindingContext as MyCustVM;
            // 在這裡，指定 Code Behind 的一個方法到 ViewModel 內的委派物件上
            // 當 ViewModel 執行這個委派物件，也就執行了 Code Behind 內的方法
            fooMyCustVM.MyStringDelegated = CodeBehindMyString;
        }

        public string CodeBehindMyString()
        {
            return "Code Behind";
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            fooMyCustVM.EventLog += "OnAppearing" + "\r\n";
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            fooMyCustVM.EventLog += "OnDisappearing" + "\r\n";
        }
    }
}
