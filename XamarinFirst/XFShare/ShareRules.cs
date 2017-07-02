using System;
using System.Collections.Generic;
using System.Text;

namespace XFShare
{
    public class ShareRules
    {
        public string CalString(string yourName)
        {
            string MyAnswer = "";

#if __ANDROID__
            MyAnswer = "SAP Android:";
#elif __IOS__
            MyAnswer = "SAP iOS:";
#else
            MyAnswer = "SAP UWP:";
#endif
            MyAnswer += yourName;
            return MyAnswer;
        }
    }
}
