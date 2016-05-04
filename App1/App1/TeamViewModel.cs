using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace App1
{
    public class TeamViewModel : ViewModelBase
    {
        int geld;

        public TeamViewModel()
        {
            Players = new List<PlayerViewModel>();
            GeldErhoehen = new Command(() => { Geld += 1000; });
        }

        public int Rang { get; set; }
        public string Name { get; set; }
        public int Fans { get; set; }

        public List<PlayerViewModel> Players;

        public int Geld
        {
            set { SetProperty(ref geld, value); }
            get { return geld; }
        }

        public ICommand GeldErhoehen { private set; get; }
    }
}
