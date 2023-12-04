using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace ConorKoritorOOPCA2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// Github Link https://github.com/ConorKoritor/ConorKoritorOOPCA2


    public partial class MainWindow : Window
    {
        private List<Team> Teams = new List<Team>();
        public MainWindow()
        {
            InitializeComponent();
            GetData();
            CalculatePoints();
            DisplayData();
        }

        public void GetData()
        {
            //Get Data creates 3 teams and adds them to a list

            Team t1 = new Team("France");
            Team t2 = new Team("Italy");
            Team t3 = new Team("Spain");

            //Adds the 3 teams to the list of Teams
            Teams.Add(t1);
            Teams.Add(t2);
            Teams.Add(t3);

            //French players
            Player p1 = new Player("Marie", "W,W,D,D,L");
            Player p2 = new Player("Claude", "D,D,D,L,W");
            Player p3 = new Player("Antoine", "L,W,D,L,W");

            //Adds Players to the teams list of Players
            t1.AddPlayer(p1);
            t1.AddPlayer(p2);
            t1.AddPlayer(p3);

            //Italian players
            Player p4 = new Player("Marco", "W,W,D,L,L");
            Player p5 = new Player("Giovanni", "L,L,L,L,D");
            Player p6 = new Player("Valentina", "D,L,W,W,W");

            t2.AddPlayer(p4);
            t2.AddPlayer(p5);
            t2.AddPlayer(p6);

            //Spanish players
            Player p7 = new Player("Maria", "W,W,W,W,W");
            Player p8 = new Player("Jose", "L,L,L,L,L");
            Player p9 = new Player("Pablo", "D,D,D,D,D");

            t3.AddPlayer(p7);
            t3.AddPlayer(p8);
            t3.AddPlayer(p9);
        }

        public void CalculatePoints()
        {
            //Loops through each team in the list teams and calls that teams CalculatePoints() method
            foreach(Team team in Teams)
            {
                team.CalculatePoints();
            }

            Teams.ToList().Sort();
            CollectionViewSource.GetDefaultView(Teams).Refresh();

        }

        public void DisplayData()
        {
            //Sets the display of the left selection box to our list of teams and sets the default selected index of the lstbx
            Teams.Sort();
            Teams.Reverse();
            lstbxTeams.ItemsSource = Teams;
        }

        private void lstbxTeams_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Sets the display of the right lstbx to the Team list of players at the selected index
            lstbxPlayers.ItemsSource = Teams[lstbxTeams.SelectedIndex].getPlayers();
        }

        private void lstbxPlayers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Calls Display stars
            DisplayStars();
        }

        private void DisplayStars()
        {
            //Created Display stars as a seperate method so it can be called after the win/draw/loss buttons are pressed

            //Changes the Rating Stars based off the selected players points.

            Player p = lstbxPlayers.SelectedItem as Player;

            //checks if the selection is not null before checking the players total points
            if (p != null)
            {
                //checks how many points the player has and what category they fall into
                if (p.GetPoints() == 0)
                {
                    //changes all of the star images to the right combination by creating a bitmap image and setting it at the 
                    //file path of the right star
                    //It weither sets the image to the star filled in or the star outline depending on how many stars the players total points 
                    //are worth
                    //0 points all the stars are outlines
                    imgStar1.Source = new BitmapImage(new Uri("images/staroutline.png", UriKind.Relative));
                    imgStar2.Source = new BitmapImage(new Uri("images/staroutline.png", UriKind.Relative));
                    imgStar3.Source = new BitmapImage(new Uri("images/staroutline.png", UriKind.Relative));
                }
                else if (p.GetPoints() >= 1 && p.GetPoints() <= 5)
                {
                    //1-5 points is the first star filled in
                    imgStar1.Source = new BitmapImage(new Uri("images/starsolid.png", UriKind.Relative));
                    imgStar2.Source = new BitmapImage(new Uri("images/staroutline.png", UriKind.Relative));
                    imgStar3.Source = new BitmapImage(new Uri("images/staroutline.png", UriKind.Relative));
                }
                else if (p.GetPoints() >= 6 && p.GetPoints() <= 10)
                {
                    //6-10 points is the first 2 stars filled in
                    imgStar1.Source = new BitmapImage(new Uri("images/starsolid.png", UriKind.Relative));
                    imgStar2.Source = new BitmapImage(new Uri("images/starsolid.png", UriKind.Relative));
                    imgStar3.Source = new BitmapImage(new Uri("images/staroutline.png", UriKind.Relative));
                }
                else if (p.GetPoints() >= 11 && p.GetPoints() <= 15)
                {
                    //11-15 points is all 3 stars filled in
                    imgStar1.Source = new BitmapImage(new Uri("images/starsolid.png", UriKind.Relative));
                    imgStar2.Source = new BitmapImage(new Uri("images/starsolid.png", UriKind.Relative));
                    imgStar3.Source = new BitmapImage(new Uri("images/starsolid.png", UriKind.Relative));
                }
            }
        }

        private void btnWin_Click(object sender, RoutedEventArgs e)
        {
            //When the win button is clicked the program gets the selected player and calls the AddResult method from Player
            Player p = lstbxPlayers.SelectedItem as Player;

            if (p != null) {
                p.AddResult("W");
            }

            //We then want to recalculate the points of the team that the player is a part of
            //This method in teams also calls the CalculatePoints() method inside of each player in the team
            Teams[lstbxTeams.SelectedIndex].CalculatePoints();

            //Sorting the teams from the highest to lowest and then refreshing the display
            Teams.Sort();
            Teams.Reverse();
            CollectionViewSource.GetDefaultView(Teams).Refresh();

            //Calls display stars so the stars are dynamically updated after clicking the button
            DisplayStars();
        }

        private void btnLoss_Click(object sender, RoutedEventArgs e)
        {
            //This is the same logic as the win button but just passes in a loss instead
            Player p = lstbxPlayers.SelectedItem as Player;

            if (p != null)
            {
                p.AddResult("L");
            }

            Teams[lstbxTeams.SelectedIndex].CalculatePoints();
            Teams.Sort();
            Teams.Reverse();
            CollectionViewSource.GetDefaultView(Teams).Refresh();

            DisplayStars();
        }

        private void btnDraw_Click(object sender, RoutedEventArgs e)
        {
            //This is the same logic as the win button but just passes in a draw instead
            Player p = lstbxPlayers.SelectedItem as Player;

            if (p != null)
            {
                p.AddResult("D");
            }

            Teams[lstbxTeams.SelectedIndex].CalculatePoints();
            Teams.Sort();
            Teams.Reverse();
            CollectionViewSource.GetDefaultView(Teams).Refresh();

            DisplayStars();
        }
    }
}
