using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonersDilemma
{
    public static class Score
    {
  
        /// <summary>
        /// Based upon the two prisoners determine what the result is.
        /// •If both Prisoner A and Prisoner B defect (blame the other) then both prisoners get 2 years in prison.
        /// •If Prisoner A defects and Prisoner B cooperates then Prisoner A is set free and Prisoner B gets 3 years in prison.
        /// •If both prisoners cooperate then both prisoners get 1 year in prison.
        /// </summary>
        /// <param name="prisoner1"></param>
        /// <param name="prisoner2"></param>
        public static void DetermineResult( Prisoner prisoner1,  Prisoner prisoner2)
        {
 
            Console.WriteLine("*****************************************"); 
            Console.WriteLine("RESULT FOR ITERATION IN DILEMMA CONTEST");

            if (prisoner1.LastChoice == StrategyChoice.Cooperate && prisoner2.LastChoice == StrategyChoice.Cooperate)
            {
                Console.WriteLine("NONE COOPERATE: Both Prisoners Get 1 Year");
                //Both cooperate - both get 1 year in prison
                prisoner1.AddScore(1);
                prisoner2.AddScore(1);
            }
            else if (prisoner1.LastChoice == StrategyChoice.Cooperate && prisoner2.LastChoice == StrategyChoice.Defect)
            {
                Console.WriteLine("ONLY 1 DEFECT: Prisoner 1 goes free, Prisoner 2 Gets 3 years");
                //Defect goes free
                //Cooperate gets 3 year
                prisoner1.AddScore(0);
                prisoner2.AddScore(3);
            }
            else if (prisoner1.LastChoice == StrategyChoice.Defect && prisoner2.LastChoice == StrategyChoice.Cooperate)
            {
                Console.WriteLine("ONLY 1 DEFECT: Prisoner 1 gets 3 years, Prisoner 2 goes free");
                prisoner1.AddScore(3);
                prisoner2.AddScore(0);
            }
            else
            {
                // Both get 3 years
                Console.WriteLine("BOTH DEFECT: Both get 2 years");
                prisoner1.AddScore(2);
                prisoner2.AddScore(2);
            }
        }
    }

}
