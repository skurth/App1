using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace App1
{
    public partial class Page1 : ContentPage
    {

        ObservableCollection<TeamViewModel> list;

        public Page1()
        {
            InitializeComponent();


            Device.StartTimer(TimeSpan.FromSeconds(10), () =>
            {
                Plugin.LocalNotifications.CrossLocalNotifications.Current.Show("from", "timer!!" + DateTime.Now.ToString(), 0, DateTime.Now.AddSeconds(10));

                return true;
            });

            list = new ObservableCollection<TeamViewModel>
            {
                new TeamViewModel() { Name="Tübach City", Rang=1, Geld=1000 },
                new TeamViewModel() { Name="1. FC Schwangere Bergente", Rang=2, Geld=800 },
                new TeamViewModel() { Name="PSV Tübach", Rang=3, Geld=200 },
                //new TeamViewModel() { Name="Tübach City", Rang=1, Geld=1000 },
                //new TeamViewModel() { Name="1. FC Schwangere Bergente", Rang=2, Geld=800 },
                //new TeamViewModel() { Name="Tübach City", Rang=1, Geld=1000 },
                //new TeamViewModel() { Name="1. FC Schwangere Bergente", Rang=2, Geld=800 },
                //new TeamViewModel() { Name="Tübach City", Rang=1, Geld=1000 },
                //new TeamViewModel() { Name="1. FC Schwangere Bergente", Rang=2, Geld=800 },
                //new TeamViewModel() { Name="Tübach City", Rang=1, Geld=1000 },
                //new TeamViewModel() { Name="1. FC Schwangere Bergente", Rang=2, Geld=800 },
                //new TeamViewModel() { Name="Tübach City", Rang=1, Geld=1000 },
                //new TeamViewModel() { Name="Tübach City", Rang=1, Geld=1000 },
                //new TeamViewModel() { Name="1. FC Schwangere Bergente", Rang=2, Geld=800 },
                //new TeamViewModel() { Name="Tübach City", Rang=1, Geld=1000 },
                //new TeamViewModel() { Name="1. FC Schwangere Bergente", Rang=2, Geld=800 },
                //new TeamViewModel() { Name="1. FC Schwangere Bergente", Rang=2, Geld=800 },
            };

            //MyTeam = new TeamViewModel(){ Name="Tübach City", Rang=1, Geld=1000};
            //BindingContext = MyTeam;
            myStackLayout.BindingContext = list[0];


            list = new ObservableCollection<TeamViewModel>(list.OrderBy(x => x.Name));
            myListView.ItemsSource = list;

            myListView.RefreshCommand = new Command(() =>
            {
                list.Add(new TeamViewModel() { Name = "FC Rorschach harr", Rang = 4, Geld = 50 });
                myListView.IsRefreshing = false;
            });

            list.Add(new TeamViewModel() { Name = "FC Rorschach", Rang = 4, Geld = 50 });

            int i = 9;
        }

        public TeamViewModel MyTeam { get; set; }

        public async void onItemTapped(object sender, ItemTappedEventArgs e)
        {
            Plugin.LocalNotifications.CrossLocalNotifications.Current.Show("test", "blub",0, DateTime.Now.AddSeconds(10));
            
            TeamViewModel item = (TeamViewModel)e.Item;
            myStackLayout.BindingContext = item;

            await Navigation.PushAsync(new EditItem(item)); //Dazu siehe App.cs -> NavigationPage
            //DisplayAlert("test", item.Name, "Abbrechen");
        }

        public void OnDelete(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            list.Remove((TeamViewModel)mi.CommandParameter);
        }
    }
}
