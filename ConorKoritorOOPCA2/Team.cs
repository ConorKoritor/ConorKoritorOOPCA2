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

        public Team(string name, ObservableCollection<Player> players)
        {
            Name = name;
            Players = players;
        }
    }
}
