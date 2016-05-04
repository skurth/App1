using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1
{
    class SaveAndLoad
    {

        public static void Save(string filename, string text)
        {
            DependencyService.Get<ISaveAndLoad>().SaveText(filename, text);
        }

        public static string Load(string filename)
        {
            return DependencyService.Get<ISaveAndLoad>().LoadText(filename);
        }
    }
}
