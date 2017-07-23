using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFTempSel.Models
{
    public enum 對話類型
    {
        他人,
        自己
    }
    public class ChatContent : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public string 對話人圖片 { get; set; }
        public string 對話內容 { get; set; }
        public 對話類型 對話類型 { get; set; }
        public Color 對話文字顏色 { get; set; }


        public ChatContent()
        {
        }
    }
}
