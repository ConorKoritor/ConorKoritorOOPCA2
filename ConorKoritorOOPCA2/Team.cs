using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConorKoritorOOPCA2
{
    internal class Team
    {
        private string Name {  get; set; }
        private ObservableCollection<Player> Players { get; set; }

        public Team() 
        {
            //Constructor if no data is entered
            //Unnecessary as we will hard code the teams but just future proofs the code
            Name = "No Name";
            Players = new ObservableCollection<Player>();
        }

        public Team(string name)
        {
            //Constructor does not take in a Collection of Players so that the MainWindow.Xaml.cs doesnt have to initialize a bunch of Collections
            Name = name;
        }


        public void AddPlayer(Player player)
        {
            //Takes in a player and adds it to the Observable Collection
            Players.Add(player);
        }
    }
}
