using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace App1
{
    public partial class Page2 : ContentPage
    {
        public Page2()
        {
            InitializeComponent();

            ObservableCollection<TeamViewModel> list = new ObservableCollection<TeamViewModel>
            {
                new TeamViewModel() { Name="Tübach City", Rang=1, Geld=1000, Players = { new PlayerViewModel() { FirstName = "Max", GoalsScored=1 }, new PlayerViewModel() { FirstName = "Hans", GoalsScored = 3 }, new PlayerViewModel() { FirstName = "Hubert", GoalsScored = 6 }} },
                new TeamViewModel() { Name="1. FC Schwangere Bergente", Rang=2, Geld=800, Players = { new PlayerViewModel() { FirstName = "Adam", GoalsScored=1 }, new PlayerViewModel() { FirstName = "Bjorn", GoalsScored = 3 }, new PlayerViewModel() { FirstName = "Ried", GoalsScored = 6 }} },
                new TeamViewModel() { Name="PSV Tübach", Rang=3, Geld=200, Players = { new PlayerViewModel() { FirstName = "Luli", GoalsScored=1 }, new PlayerViewModel() { FirstName = "Lumpi", GoalsScored = 3 }, new PlayerViewModel() { FirstName = "Franz", GoalsScored = 6 }} }
            };
            
            myListView.ItemTemplate = new DataTemplate(typeof(ViewCellTeamPlayers));
            myListView.ItemsSource = list;
        }

        void OnClick(object sender, EventArgs e)
        {
            ToolbarItem tbi = (ToolbarItem)sender;
            this.DisplayAlert("Selected!", tbi.Text, "OK");
        }
    }
}
