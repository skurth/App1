using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace App1.GroupTest
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class Team : ObservableCollection<Player>, INotifyPropertyChanged
    {
        string name = string.Empty;
        [JsonProperty]
        public string Name
        {
            set { SetProperty(ref name, value); }
            get { return name; }
        }

        [JsonProperty]
        public string ShortName { get; set; }

        double ageTotal = 0;
        [JsonProperty]
        public double AgeTotal
        {
            set { SetProperty(ref ageTotal, value); }
            get
            {
                double calc = 0;
                for (int i = 0; i < base.Count; i++)
                {
                    calc += base[i].Age;
                }

                return calc;
            } 
        }

        [JsonProperty]
        public Player[] Players
        {
            get
            {
                return this.ToArray();
            }
            set
            {
                if (value != null)
                    foreach (var item in value)
                    {
                        this.Add(item);
                    }
            }
        }

        [JsonIgnore]
        public ObservableCollection<Team> Teams;

        public Team(string name, string shortName, ObservableCollection<Team> teams)
        {
            Name = name;
            ShortName = shortName;
            Teams = teams;
        }

        public void CalculateAgeTotal()
        {
            OnPropertyChanged("AgeTotal");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected bool SetProperty<T>(ref T storage, T value,
                                      [CallerMemberName] string propertyName = null)
        {
            if (Object.Equals(storage, value))
                return false;

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
