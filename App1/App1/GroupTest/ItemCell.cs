using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XLabs.Forms.Controls;

namespace App1.GroupTest
{
    class ItemCell : ViewCell
    {
        public ItemCell()
        {
            Grid grid = new Grid
            {
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Padding = new Thickness(0,0,0,0),
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

            var name = new Label
            {
                //BackgroundColor = Color.Red
            };
            name.SetBinding(Label.TextProperty, new Binding("FirstName"));

            grid.Children.Add(name, 0, 0);

            var spezi = new ExtendedPicker
            {
                HorizontalOptions = LayoutOptions.Start,
                Title = "Test",
                IsVisible = false
            };

            //spezi.Items.Add("Kopf");
            //spezi.Items.Add("Schnell");
            //spezi.Items.Add("Ballzauberer");
            spezi.ItemsSource = new List<string>() { "Kopf", "Schnell", "Ballzauberer" };
            spezi.SetBinding(ExtendedPicker.SelectedItemProperty, new Binding("Spezi", BindingMode.TwoWay));
            grid.Children.Add(spezi, 1, 0);

            spezi.Focused += (object sender, FocusEventArgs e) =>
            {
                int b = 5;
            };

            var speziButton = new Button
            {
                HorizontalOptions = LayoutOptions.Start,
                HeightRequest = 16,
                FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Button))
            };
            speziButton.SetBinding(Button.TextProperty, new Binding("Spezi"));
            speziButton.SetBinding(Button.CommandParameterProperty, new Binding("."));

            speziButton.Clicked += (sender, e) =>
            {
                //var page = (GroupTest)Application.Current.MainPage.Navigation.NavigationStack[Application.Current.MainPage.Navigation.NavigationStack.Count - 1];

                spezi.Focus();
                //var b = (Button)sender;
                //var player = (Player)b.CommandParameter;

                //player = player;
            };

            grid.Children.Add(speziButton, 1, 0);

            var age = new Entry
            {
                HorizontalOptions = LayoutOptions.EndAndExpand,
                WidthRequest = 70
            };
            age.SetBinding(Entry.TextProperty, new Binding("Age", converter: new DoubleConverter()));

            grid.Children.Add(age, 2, 0);

            View = grid;

            //var name = new Label
            //{
            //    VerticalOptions = LayoutOptions.Center
            //};
            //name.SetBinding(Label.TextProperty, new Binding("FirstName"));

            //var lsta = new Button
            //{
            //    HorizontalOptions = LayoutOptions.CenterAndExpand,
            //    Text = "LSTA",
            //    HeightRequest = 16,
            //    FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Button))
            //};

            //var age = new Entry
            //{
            //    HorizontalOptions = LayoutOptions.EndAndExpand,
            //    WidthRequest = 70
            //};
            //age.SetBinding(Entry.TextProperty, new Binding("Age", converter: new DoubleConverter()));

            //View = new StackLayout
            //{
            //    Orientation = StackOrientation.Horizontal,
            //    HorizontalOptions = LayoutOptions.StartAndExpand,
            //    Children = { name, lsta, age }
            //};
        }
    }
}
