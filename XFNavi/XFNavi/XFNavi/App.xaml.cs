using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace XFNavi
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //App.Current.MainPage = your new mailpage
            //App.Current.Properties["CurrMainPage"] = "P1";
            //App.Current.SavePropertiesAsync();
            //MainPage = new NavigationPage( new XFNavi.MainPage());
            MainPage = new XFNavi.P3Page();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
