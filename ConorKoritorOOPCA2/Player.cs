using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConorKoritorOOPCA2
{
    internal class Player
    {
        private string Name {  get; set; }
        private List<string> ResultRecord {  get; set; }

        public Player()
        {
            //Constructor with no Arguments
            //Will not need as we will hard code the players. Just future proofs the code
            Name = "No Name";
            ResultRecord = new List<string>{"L", "L", "L", "L", "L"};
        }

        public Player(string name, List<string> resultRecord)
        {
            Name = name;
            ResultRecord = resultRecord;
        }
    }
}
