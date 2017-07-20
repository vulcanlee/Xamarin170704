using System;
using System.Text;
using Xamarin.Forms;

namespace XFBindingContext.Views
{
    public partial class MainPage : ContentPage
    {
        string fooViewCellType = "";
        public MainPage()
        {
            InitializeComponent();
            this.ThisListView.ItemAppearing += (s, arg) =>
            {
                fooViewCellType = arg.Item.GetType().Name;
            };
        }

        private void btnViewBC_Clicked(object sender, System.EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            var fooValue = ThisStackLayout.GetType().Name;
            sb.Append($"ContentPage BindingContext = {this.BindingContext.GetType().Name}\n");
            sb.Append($"StackLayout BindingContext = {ThisStackLayout.BindingContext.GetType().Name}\n");
            sb.Append($"Label BindingContext = {ThisLabel.BindingContext.GetType().Name}\n");
            sb.Append($"ThisListView BindingContext = {ThisListView.BindingContext.GetType().Name}\n");
            sb.Append($"ViewCell BindingContext = {fooViewCellType}\n");

            ThisLabel.Text = sb.ToString();
        }

    }
}
