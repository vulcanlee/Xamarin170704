using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;

namespace XFUserPanel.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {

        public event PropertyChangedEventHandler PropertyChanged;
        public string Title { get; set; }

        public MyMenuPanelVM MyMenuPanelVMObject { get; set; } = new MyMenuPanelVM();

        public MainPageViewModel()
        {

        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("title"))
                Title = (string)parameters["title"] + " and Prism";

            MyMenuPanelVMObject.PanelColor = Color.Lime;
            #region Button1
            MyMenuPanelVMObject.Button1.ButtonVisible = true;
            MyMenuPanelVMObject.Button1.ButtonColor = Color.Yellow;
            MyMenuPanelVMObject.Button1.ButtonTextColor = Color.Black;
            MyMenuPanelVMObject.Button1.ButtonSource = "Button1";
            MyMenuPanelVMObject.Button1.ButtonText = "按鈕1";
            MyMenuPanelVMObject.Button1.ButtonTapCommand = new DelegateCommand<string>(MyButtonTapCommand);
            #endregion

            #region Button2
            MyMenuPanelVMObject.Button2.ButtonVisible = true;
            MyMenuPanelVMObject.Button2.ButtonColor = Color.Purple;
            MyMenuPanelVMObject.Button2.ButtonTextColor = Color.White;
            MyMenuPanelVMObject.Button2.ButtonSource = "Button2";
            MyMenuPanelVMObject.Button2.ButtonText = "按鈕2";
            MyMenuPanelVMObject.Button2.ButtonTapCommand = new DelegateCommand<string>(MyButtonTapCommand);
            #endregion

            #region Button3
            MyMenuPanelVMObject.Button3.ButtonVisible = true;
            MyMenuPanelVMObject.Button3.ButtonColor = Color.Maroon;
            MyMenuPanelVMObject.Button3.ButtonTextColor = Color.White;
            MyMenuPanelVMObject.Button3.ButtonSource = "Button3";
            MyMenuPanelVMObject.Button3.ButtonText = "按鈕3";
            MyMenuPanelVMObject.Button3.ButtonTapCommand = new DelegateCommand<string>(MyButtonTapCommand);
            #endregion

            #region Button4
            MyMenuPanelVMObject.Button4.ButtonVisible = true;
            MyMenuPanelVMObject.Button4.ButtonColor = Color.Fuchsia;
            MyMenuPanelVMObject.Button4.ButtonTextColor = Color.White;
            MyMenuPanelVMObject.Button4.ButtonSource = "Button4";
            MyMenuPanelVMObject.Button4.ButtonText = "按鈕4";
            MyMenuPanelVMObject.Button4.ButtonTapCommand = new DelegateCommand<string>(MyButtonTapCommand);
            #endregion

            #region Button5
            MyMenuPanelVMObject.Button5.ButtonVisible = true;
            MyMenuPanelVMObject.Button5.ButtonColor = Color.Aqua;
            MyMenuPanelVMObject.Button5.ButtonTextColor = Color.Black;
            MyMenuPanelVMObject.Button5.ButtonSource = "Button5";
            MyMenuPanelVMObject.Button5.ButtonText = "按鈕5";
            MyMenuPanelVMObject.Button5.ButtonTapCommand = new DelegateCommand<string>(MyButtonTapCommand);
            #endregion

        }

        private void MyButtonTapCommand(string obj)
        {
            if(obj == "Button1")
            {
                MyMenuPanelVMObject.Button3.ButtonVisible = false;
                MyMenuPanelVMObject.Button5.ButtonVisible = false;
            }
            else if (obj == "Button2")
            {
                MyMenuPanelVMObject.Button1.ButtonVisible = true;
                MyMenuPanelVMObject.Button2.ButtonVisible = true;
                MyMenuPanelVMObject.Button3.ButtonVisible = true;
                MyMenuPanelVMObject.Button4.ButtonVisible = true;
                MyMenuPanelVMObject.Button5.ButtonVisible = true;

            }
            else if (obj == "Button3")
            {
                MyMenuPanelVMObject.Button4.ButtonVisible = !(MyMenuPanelVMObject.Button4.ButtonVisible);
                MyMenuPanelVMObject.Button5.ButtonVisible = !(MyMenuPanelVMObject.Button5.ButtonVisible);
            }
            else if (obj == "Button4")
            {

            }
            else if (obj == "Button5")
            {

            }
        }
    }
}
