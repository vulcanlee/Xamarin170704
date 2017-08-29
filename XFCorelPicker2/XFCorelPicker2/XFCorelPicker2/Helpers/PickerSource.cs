using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFCorelPicker2.Helpers
{
    public static class PickerSource
    {
        public static ObservableCollection<string>  GetPicker1Source()
        {
            return new ObservableCollection<string>() { "A", "B" };
        }

        public static ObservableCollection<string> GetPickr2Source(string dependby)
        {
            if(dependby == "A")
            {
                return new ObservableCollection<string> { "1", "2", "3" };
            }
            else
            {
                return new ObservableCollection<string> { "1", "2", "4" };
            }
        }
    }
}
