using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFPCLFile.Models
{
    public class MyPageData : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int Amt { get; set; }
        public bool IsMemory { get; set; }
    }
}
