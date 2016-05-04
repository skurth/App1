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
using App1.Droid;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(PlatformService_Droid))]
namespace App1.Droid
{
    public class PlatformService_Droid : IPlatformService
    {
        public void ClearWebViewCache()
        {
            Android.Webkit.WebView wv = new Android.Webkit.WebView(Forms.Context);
            wv.ClearCache(true);
        }
    }
}