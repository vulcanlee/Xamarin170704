using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;


[assembly: Xamarin.Forms.Dependency(typeof(XFDI.Droid.SayHelloAndroid))]
namespace XFDI.Droid
{
    public class SayHelloAndroid : ISayHello
    {
        public string Hello()
        {
            Context context = Android.App.Application.Context;
            var fooVersionName = context.PackageManager.GetPackageInfo(context.PackageName, 0).VersionName;
            var fooPackageName = context.PackageManager.GetPackageInfo(context.PackageName, 0).PackageName;
            return $"Android: ${fooPackageName}  {fooVersionName}";
        }
    }
}