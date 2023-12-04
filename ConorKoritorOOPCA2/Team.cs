using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ConorKoritorOOPCA2
{
    internal class Team : IComparable
    {
        private string Name {  get; set; }
        private List<Player> Players { get; set; }
        private int Totalpoints { get; set; }

        public Team() 
        {
            //Constructor if no data is entered
            //Unnecessary as we will hard code the teams but just future proofs the code
            Name = "No Name";
            Players = new List<Player>();
            CalculatePoints();
        }

        public Team(string name)
        {
            //Constructor does not take in a listof Players so that the MainWindow.Xaml.cs doesnt have to initialize a bunch of lists
            Name = name;
            Players = new List<Player>();
            CalculatePoints();
        }

        public int CompareTo(object obj)
        {
            //Icomparable Logic so that we can sort the list of teams
            if (obj == null) return 1;

            Team otherTeam = obj as Team;
            if (otherTeam != null)
                return this.Totalpoints.CompareTo(otherTeam.Totalpoints);
            else
                throw new ArgumentException("Object is not a Temperature");
        }

        public void AddPlayer(Player player)
        {
            //Takes in a player and adds it to the List
            Players.Add(player);
        }

        public List<Player> getPlayers()
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



            return Totalpoints;
        }

        public override string ToString()
        {
            return $"{Name} - {Totalpoints}";
        }
    }
}
