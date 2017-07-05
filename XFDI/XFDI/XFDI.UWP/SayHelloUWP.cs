using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


[assembly: Xamarin.Forms.Dependency(typeof(XFDI.UWP.SayHelloUWP))]
namespace XFDI.UWP
{
    public class SayHelloUWP : ISayHello
    {
        public string Hello()
        {
            var Version = $"{Windows.ApplicationModel.Package.Current.Id.Version.Major}.{Windows.ApplicationModel.Package.Current.Id.Version.Minor}";
            var Build = Windows.ApplicationModel.Package.Current.Id.Version.Build;
            var Name = Windows.ApplicationModel.Package.Current.Id.Name;
            var fooRet= $"UWP {Version}.{Build}.{Name}";
            return fooRet;
        }
    }
}
