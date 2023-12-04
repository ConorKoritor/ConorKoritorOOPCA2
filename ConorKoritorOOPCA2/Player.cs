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
        private int TotalPoints {  get; set; }

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
            ResultRecord = new List<string>();
            foreach (string result in results)
            {
                ResultRecord.Add(result);
            }
        }

        public int CalculatePoints()
        {
            //Sets total points to 0 so every time we call this method it resets the total points before recalculating
            TotalPoints = 0;
            //Calculates total points by looping through our List of results
            foreach(string result in ResultRecord)
            {
                //We use a switch statement to check what result the player got. For a win they gain 3 points, for a draw they gain 1 
                //And for a loss they get 0 points which is why it is left out of the switch statement
                switch (result)
                {
                    case "W":
                        TotalPoints += 3;
                        break;
                    case "D":
                        TotalPoints++;
                        break;
                    default: 
                        break;
                }
            }

            return TotalPoints;
        }

        public int GetPoints()
        {
            return TotalPoints;
        }

        public void AddResult(string result)
        {
            ResultRecord.Add(result);
            ResultRecord.RemoveAt(0);
        }

        public override string ToString()
        {
            //Combines the elements of the list of results so that it can be displayed as 1 string
            string resultsCombined = String.Join("", ResultRecord.ToArray());
            return $"{Name} - {resultsCombined} - {TotalPoints}";
        }
    }
}
