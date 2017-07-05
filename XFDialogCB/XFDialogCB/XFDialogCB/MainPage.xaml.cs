using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFDialogCB
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btn_Clicked(object sender, EventArgs e)
        {
            // 這裡不使用 await 會有甚麼情況
            string fooAnswer = await this.DisplayActionSheet("Information", "確定", null, "Option1", "Option2", "Option3", "Option4");
            YourAnswer.Text = fooAnswer;
        }
    }
}
