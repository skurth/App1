using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1.GroupTest
{
    class GroupHeaderCell : ViewCell
    {
        public GroupHeaderCell()
        {
            Height = 60;

            Grid grid = new Grid
            {
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Padding = new Thickness(0, 0, 0, 0),
                RowDefinitions =
                {
                    new RowDefinition { Height = GridLength.Auto }
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = new GridLength(60, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(20, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(20, GridUnitType.Star) }
                }
            };

            var groupKey = new Label
            {
                //FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                TextColor = Color.White,
                VerticalTextAlignment = TextAlignment.Center
            };
            groupKey.SetBinding(Label.TextProperty, new Binding("Name"));

            grid.Children.Add(groupKey, 0, 0);

            var ageTotal = new Label
            {
                TextColor = Color.Red,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.EndAndExpand
            };
            ageTotal.SetBinding(Label.TextProperty, new Binding("AgeTotal"));

            grid.Children.Add(ageTotal, 1, 0);

            var button = new Button
            {
                Text = "Delete",
                HorizontalOptions = LayoutOptions.EndAndExpand
            };

            //button.SetBinding(Button.CommandProperty, new Binding("GeldErhoehen"));
            button.SetBinding(Button.CommandParameterProperty, new Binding("."));

            button.Clicked += (sender, e) =>
            {
                var b = (Button)sender;
                var team = (Team)b.CommandParameter;

                team.Teams.Remove(team);
            };

            grid.Children.Add(button, 2, 0);

            View = grid;
            //View = new StackLayout
            //{
            //    Orientation = StackOrientation.Horizontal,
            //    HorizontalOptions = LayoutOptions.StartAndExpand,
            //    HeightRequest = 60,
            //    Children = { groupKey, ageTotal, button }
            //};
        }
    }
}
