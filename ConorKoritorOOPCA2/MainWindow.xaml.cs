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

    public partial class MainWindow : Window
    {
        private ObservableCollection<Team> Teams = new ObservableCollection<Team>();
        public MainWindow()
        {
            InitializeComponent();

            GetData();

            DisplayData();

            CalculatePoints();
        }

        public void GetData()
        {
            //Get Data creates 3 teams and adds them to an Observable collection

            Team t1 = new Team("France");
            Team t2 = new Team("Italy");
            Team t3 = new Team("Spain");

            //Adds the 3 teams to the Observable Collection of Teams
            Teams.Add(t1);
            Teams.Add(t2);
            Teams.Add(t3);

            //French players
            Player p1 = new Player("Marie", "W,W,D,D,L");
            Player p2 = new Player("Claude", "D,D,D,L,W");
            Player p3 = new Player("Antoine", "L,W,D,L,W");

            //Adds Players to the teams Observable collection of Players
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
            foreach(Team team in Teams)
            {
                team.CalculatePoints();
            }

        }

        public void DisplayData()
        {
            lstbxTeams.ItemsSource = Teams;
            lstbxTeams.SelectedIndex = 0;

            lstbxPlayers.ItemsSource = Teams[lstbxTeams.SelectedIndex].getPlayers();
        }


    }
}
