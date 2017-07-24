using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFUserPanel.ViewModels
{
    public class MyMenuPanelVM : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public Color PanelColor { get; set; }
        public MyMenuButtonVM Button1 { get; set; } = new MyMenuButtonVM();
        public MyMenuButtonVM Button2 { get; set; } = new MyMenuButtonVM();
        public MyMenuButtonVM Button3 { get; set; } = new MyMenuButtonVM();
        public MyMenuButtonVM Button4 { get; set; } = new MyMenuButtonVM();
        public MyMenuButtonVM Button5 { get; set; } = new MyMenuButtonVM();

    }
}
