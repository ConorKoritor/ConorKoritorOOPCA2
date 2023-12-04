using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ConorKoritorOOPCA2
{
    internal class Team
    {
        private string Name {  get; set; }
        private ObservableCollection<Player> Players { get; set; }
        private int Totalpoints { get; set; }

        public Team() 
        {
            //Constructor if no data is entered
            //Unnecessary as we will hard code the teams but just future proofs the code
            Name = "No Name";
            Players = new ObservableCollection<Player>();
            CalculatePoints();
        }

        public Team(string name)
        {
            //Constructor does not take in a Collection of Players so that the MainWindow.Xaml.cs doesnt have to initialize a bunch of Collections
            Name = name;
            Players = new ObservableCollection<Player>();
            CalculatePoints();
        }


        public void AddPlayer(Player player)
        {
            //Takes in a player and adds it to the Observable Collection
            Players.Add(player);
        }

        public ObservableCollection<Player> getPlayers()
        {
            return Players;
        }

        public int CalculatePoints()
        {
            //This method calculates the total points of the players in the team. The points are based off of wins, losses and draws
            //the method then returns an int of the total points calculated
            //This method calls the CaslculatePoints method of each player which allows us to only have to call the Calculate points method of each team
            //instead of each player individually
            Totalpoints = 0;

            foreach(Player player in Players)
            {
                Totalpoints += player.CalculatePoints();
            }

            //Refreshes the collection of players after calculating point totals
            CollectionViewSource.GetDefaultView(Players).Refresh();

            return Totalpoints;
        }

        public override string ToString()
        {
            return $"{Name} - {Totalpoints}";
        }
    }
}
