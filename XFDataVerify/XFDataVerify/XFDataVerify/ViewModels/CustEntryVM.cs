using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace XFDataVerify.ViewModels
{
    public class CustEntryVM : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public string MyEntryText { get; set; }
        public string MyEntryPlaceholder { get; set; }
        public bool WarningTextVisible { get; set; } = false;
        public string WarningText { get; set; }
        public MyEntryTextType EntryType { get; set; } = MyEntryTextType.Email;

        public void OnMyEntryTextChanged()
        {
            if (EntryType == MyEntryTextType.Email)
            {
                if (MyEntryText == null)
                {
                    WarningTextVisible = true;
                }
                else
                {
                    WarningTextVisible = !IsValidEmailAddress(MyEntryText);
                }
            }
            else if (EntryType == MyEntryTextType.Password)
            {
                if (MyEntryText == null || MyEntryText.Length < 8)
                {
                    WarningTextVisible = true;
                }
                else
                {
                    WarningTextVisible = false;
                }
            }
        }

        public bool IsValidEmailAddress(string emailaddress)
        {
            try
            {
                Regex rx = new Regex(@"^[-!#$%&'*+/0-9=?A-Z^_a-z{|}~](\.?[-!#$%&'*+/0-9=?A-Z^_a-z{|}~])*@[a-zA-Z](-?[a-zA-Z0-9])*(\.[a-zA-Z](-?[a-zA-Z0-9])*)+$");
                return rx.IsMatch(emailaddress);
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }

    public enum MyEntryTextType
    {
        Email,
        Password
    }
}
