using Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFUserPanel.ViewModels
{
    public class MyMenuButtonVM : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public Color ButtonColor { get; set; }
        public string ButtonText { get; set; }
        public Color ButtonTextColor { get; set; }
        public string ButtonSource { get; set; }
        public bool ButtonVisible { get; set; }

        public DelegateCommand<string> ButtonTapCommand { get; set; }

    }
}
