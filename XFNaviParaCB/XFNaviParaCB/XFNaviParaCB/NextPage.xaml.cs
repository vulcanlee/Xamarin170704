using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFNaviParaCB
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NextPage : ContentPage
    {
        public string YourName { get; set; }
        public NextPage()
        {
            InitializeComponent();
        }

        public void SetYourName(string yourName)
        {
            label.Text = yourName;
        }
    }
}