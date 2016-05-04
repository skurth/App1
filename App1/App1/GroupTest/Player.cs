using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.GroupTest
{
    public class Player : ViewModelBase
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }

        [JsonIgnore]
        public Team Team { get; set; }

        string spezi = "Kopf";
        public string Spezi
        {
            set { SetProperty(ref spezi, value); }
            get { return spezi; }
        }

        double age = 0;
        public double Age
        {
            set
            {
                bool valueChanged = (age != value);
                age = value;
                //SetProperty(ref age, value);
                //bool valueChanged = false;
                //if (age != value) { valueChanged = true; }
                //age = value;
                //if (Team != null && valueChanged)
                //{
                //    Team.CalculateAgeTotal();
                //}

                if(Team != null && valueChanged)
                {
                    Team.CalculateAgeTotal();
                }
            }
            get { return age; }
        }

        public Player(string firstName, string surname, double age, Team team)
        {
            FirstName = firstName;
            Surname = surname;
            Age = age;
            Team = team;
        }
    }
}
