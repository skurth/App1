using App1.GroupTest;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace App1.GroupTest
{
    public partial class GroupTest : ContentPage
    {
        ObservableCollection<Team> teams;

        public GroupTest()
        {
            InitializeComponent();

            //ObservableCollection<TeamViewModel> list = new ObservableCollection<TeamViewModel>
            //{
            //    new TeamViewModel() { Name="Tübach City", Rang=1, Geld=1000, Players = { new PlayerViewModel() { FirstName = "Max", GoalsScored=1 }, new PlayerViewModel() { FirstName = "Hans", GoalsScored = 3 }, new PlayerViewModel() { FirstName = "Hubert", GoalsScored = 6 }} },
            //    new TeamViewModel() { Name="1. FC Schwangere Bergente", Rang=2, Geld=800, Players = { new PlayerViewModel() { FirstName = "Adam", GoalsScored=1 }, new PlayerViewModel() { FirstName = "Bjorn", GoalsScored = 3 }, new PlayerViewModel() { FirstName = "Ried", GoalsScored = 6 }} },
            //    new TeamViewModel() { Name="PSV Tübach", Rang=3, Geld=200, Players = { new PlayerViewModel() { FirstName = "Luli", GoalsScored=1 }, new PlayerViewModel() { FirstName = "Lumpi", GoalsScored = 3 }, new PlayerViewModel() { FirstName = "Franz", GoalsScored = 6 }} }
            //};

            teams = new ObservableCollection<Team>
            {
                
            };

            Team team1 = new Team("Tübach City", "T", teams);
            team1.Add(new Player("Max", "Muster", 88, team1));
            team1.Add(new Player("Hans", "Heiri", 17, team1));
            team1.Add(new Player("Allain", "Blub", 18, team1));

            Team team2 = new Team("1. FC Schwangere Bergente", "F", teams);
            team2.Add(new Player("Sam", "Uel", 22, team2));
            team2.Add(new Player("Ku", "Rth", 33, team2));
            team2.Add(new Player("Dr", "Dölfi", 78, team2));

            Team team3 = new Team("PSW Tübach", "F", teams);
            team3.Add(new Player("Bla", "Uel", 22, team3));
            team3.Add(new Player("Blu", "Rth", 13, team3));
            team3.Add(new Player("Bli", "Dölfi", 77, team3));

            teams.Add(team1);
            teams.Add(team2);
            teams.Add(team3);

            myListView.ItemTemplate = new DataTemplate(typeof(ItemCell));
            if(Device.OS != TargetPlatform.WinPhone)
            {
                myListView.GroupHeaderTemplate = new DataTemplate(typeof(GroupHeaderCell));
            }

            myListView.RefreshCommand = new Command(() =>
            {
                myListView.IsRefreshing = false;
            });

            //myListView.ItemsSource = teams;

            GroupDataProvider dataProvider = new GroupDataProvider();
            ObservableCollection<Team> teamsFromFile = dataProvider.GetData();
            if(teamsFromFile.Count > 0)
            {
                teams = teamsFromFile;
            }
            
            myListView.ItemsSource = teams;

            //myPicker.Items.Add("Blub");
            //myPicker.Items.Add("Blab");
            //myPicker.Items.Add("Blib");
        }

        //public Picker GetPicker()
        //{
        //    return myPicker;
        //}


        //void OnItemTapped(Object sender, ItemTappedEventArgs e)
        //{
        //    var dataItem = (Player)(e.Item);
        //    DisplayAlert("tapped", dataItem.FirstName, "Abbrechen");
        //}

        void SaveData(object sender, EventArgs e)
        {
            //string json = JsonConvert.SerializeObject(teams, Newtonsoft.Json.Formatting.Indented, new JsonSerializerSettings
            //{
            //    TypeNameHandling = TypeNameHandling.All,
            //    TypeNameAssemblyFormat = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple
            //});


            GroupDataProvider dataProvider = new GroupDataProvider();
            dataProvider.SaveData(teams);
            
            //List<A> list = new List<A>()
            //{
            //    new A() { TestA = 1 },
            //    new A() { TestA = 3 }
            //};

            //list[0].Add(new B() { TestB = 7.7 });
            //list[0].Add(new B() { TestB = 8.8 });

            //string json = JsonConvert.SerializeObject(list);

            //SaveAndLoad.Save("Test.json", json);
            //json = SaveAndLoad.Load("Test.json");

            //List<A> list_ret = JsonConvert.DeserializeObject<List<A>>(json);
        }

        public void OnDelete(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            //list.Remove((TeamViewModel)mi.CommandParameter);
        }
    }

    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class A : List<B>
    {
        [JsonProperty]
        public double TestA { get; set; }

        [JsonProperty]
        public B[] Items
        {
            get
            {
                return this.ToArray();
            }
            set
            {
                if (value != null)
                    this.AddRange(value);
            }
        }
    }

    public class B
    {
        public double TestB { get; set; }
    }
}
