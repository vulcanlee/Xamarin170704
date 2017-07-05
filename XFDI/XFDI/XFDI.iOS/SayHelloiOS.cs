using System;
using System.Collections.Generic;
using System.Text;


[assembly: Xamarin.Forms.Dependency(typeof(XFDI.iOS.SayHelloiOS))]
namespace XFDI.iOS
{
    public class SayHelloiOS : ISayHello
    {
        public string Hello()
        {
            string fooRet = Foundation.NSBundle.MainBundle.InfoDictionary["CFBundleVersion"].ToString();
            return $"iOS: {fooRet}";
        }
    }
}
