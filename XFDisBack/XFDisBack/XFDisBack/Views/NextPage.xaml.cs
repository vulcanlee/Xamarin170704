using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFDisBack.Views
{
    [XamlCompilation(XamlCompilationOptions.Skip)]
    public partial class NextPage : ContentPage
    {
        public NextPage()
        {
            InitializeComponent();
        }
        protected override bool OnBackButtonPressed()
        {
            base.OnBackButtonPressed();
            return true;
        }
    }
}
