using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace App1
{
    public partial class WebView : ContentPage
    {
        public WebView()
        {
            InitializeComponent();

            var service = DependencyService.Get<IPlatformService>();
            service.ClearWebViewCache();
        }
    }
}
