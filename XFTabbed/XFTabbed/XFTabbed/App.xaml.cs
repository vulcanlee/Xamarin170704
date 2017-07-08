using Prism.Unity;
using XFTabbed.Views;
using Xamarin.Forms;

namespace XFTabbed
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            // 可以嘗試解除底下程式碼註解，執行看看結果是如何？
            //NavigationService.NavigateAsync("NavigationPage/TabPage/P3Page");

            NavigationService.NavigateAsync("TabPage/P3Page");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<NavigationPage>();
            Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterTypeForNavigation<P2Page>();
            Container.RegisterTypeForNavigation<P3Page>();
            Container.RegisterTypeForNavigation<TabPage>();
        }
    }
}
