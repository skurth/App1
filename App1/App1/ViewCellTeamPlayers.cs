using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XLabs.Forms.Controls;

namespace App1
{
    class ViewCellTeamPlayers : ViewCell
    {

        public ViewCellTeamPlayers()
        {
            var team = new Label();
            team.SetBinding(Label.TextProperty, "Name");

            var playerName = new Label();
            playerName.SetBinding(Label.TextProperty, "FirstName");

            //var players = new ListView()
            //{
            //    BindingContext = "Players"
            //};
            //players.ItemTemplate = new DataTemplate(() => {
            //    ViewCell cell = new ViewCell();

            //    var playerName2 = new Label();
            //    playerName2.SetBinding(Label.TextProperty, "FirstName");

            //    cell.View = playerName2;

            //    return cell;
            //});
            //players.SetBinding(ListView.ItemsSourceProperty, "Players");

            //var players = new StackLayout()
            //{
            //    Orientation = StackOrientation.Horizontal,
            //    Children = { playerName }
            //};
            //players.SetBinding(StackLayout.BindingContextProperty, ".Players");

            //var players = new RepeaterView<PlayerViewModel>()
            //{
            //    Children = { playerName }
            //};
            //players.SetBinding(RepeaterView<PlayerViewModel>.ItemsSourceProperty, "Players");

            var cellLayout = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Children = { team }
            };

            this.View = cellLayout;
        }
    }
}
