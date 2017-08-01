using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFFiles.Models
{
    public class 使用這登入資訊 : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public string 姓名 { get; set; } = "";
        public string 帳號 { get; set; } = "";
        public string 密碼 { get; set; } = "";
        public bool 記憶密碼 { get; set; }
    }
}
