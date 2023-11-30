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

        public Player(string name, string resultsRecord)
        {
            Name = name;
            string[]results = resultsRecord.Split(',');
            foreach (string result in results)
            {
                ResultRecord.Add(result);
            }
        }
    }
}
