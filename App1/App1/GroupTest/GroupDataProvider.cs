using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.GroupTest
{
    class GroupDataProvider
    {
        private string fileName = "GroupData.json";

        public bool SaveData(ObservableCollection<Team> teams)
        {
            string json = JsonConvert.SerializeObject(teams);

            SaveAndLoad.Save(fileName, json);

            return true;
        }

        public ObservableCollection<Team> GetData()
        {
            string json = SaveAndLoad.Load(fileName);
            if(string.IsNullOrEmpty(json))
            {
                return new ObservableCollection<Team>();
            }

            ObservableCollection<Team> teams = JsonConvert.DeserializeObject<ObservableCollection<Team>>(json);

            foreach (Team team in teams)
            {
                team.Teams = teams;

                foreach (Player player in team)
                {
                    player.Team = team;
                }
            }

            return teams;
        }


        //public async Task<bool> SaveData(ObservableCollection<Team> teams)
        //{
        //    string json = JsonConvert.SerializeObject(teams);

        //    SaveAndLoad.Save(fileName, json);

        //    return true;
        //}

        //public async Task<ObservableCollection<Team>> GetData()
        //{
        //    string json = SaveAndLoad.Load(fileName);
        //    ObservableCollection<Team> teams = JsonConvert.DeserializeObject<ObservableCollection<Team>>(json);

        //    foreach (Team team in teams)
        //    {
        //        team.Teams = teams;

        //        foreach (Player player in team)
        //        {
        //            player.Team = team;
        //        }
        //    }

        //    return teams;
        //}
    }
}
