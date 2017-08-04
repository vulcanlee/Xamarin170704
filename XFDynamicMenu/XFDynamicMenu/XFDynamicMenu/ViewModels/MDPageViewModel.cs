using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;

namespace XFDynamicMenu.ViewModels
{
    public class MDPageViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public bool ShowMenuA { get; set; }
        public bool ShowMenuB { get; set; }
        public bool ShowMenuC { get; set; }


        public DelegateCommand<string> MenuCommand { get; set; }

        public DelegateCommand<string> MenuItemCommand { get; set; }

        public MDPageViewModel()
        {
            MenuCommand = new DelegateCommand<string>(x =>
            {
                if(x=="A")
                {
                    ShowMenuA = !ShowMenuA;
                } else if (x == "B")
                {
                    ShowMenuB = !ShowMenuB;
                } else if (x == "C")
                {
                    ShowMenuC = !ShowMenuC;
                }
            });

            MenuItemCommand = new DelegateCommand<string>(x =>
            {
                Debug.WriteLine($"你已經點選了功能項目 {x}");
            });
        }
    }
}
