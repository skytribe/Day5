using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonersDilemma
{

    public class Game
    {
        public  Prisoner prisoner1;
        public Prisoner prisoner2;

        /// <summary>
        /// Establisher a new Game with 2 prisoners 
        /// </summary>
        /// <param name="prisoner1"></param>
        /// <param name="prisoner2"></param>
        public Game( Prisoner prisoner1,  Prisoner prisoner2)
        {
            this.prisoner1 = prisoner1;
            this.prisoner2 = prisoner2;
        }
 
        public string Step()
        {
            StrategyChoice? prisoner1Choice = prisoner1.LastChoice;
            prisoner1.Step(prisoner2.LastChoice);
            prisoner2.Step(prisoner1Choice);

            // This is the key method to determine who gets additional years or not.
            Score.DetermineResult(prisoner1, prisoner2);

            //Return string with results of this round.
            var displayscore = string.Format("{0},{1}", prisoner1.TotalScore, prisoner2.TotalScore);
            return string.Format("{0},{1} {2},{3} {4}", Display(prisoner1.LastChoice.Value), Display(prisoner2.LastChoice.Value), prisoner1.RoundScore, prisoner2.RoundScore, displayscore);
        }

        /// <summary>
        /// Returns the textual description for the strategy choice.
        /// </summary>
        /// <param name="choice"></param>
        /// <returns></returns>
        public static string Display(StrategyChoice choice)
        {
            return choice == StrategyChoice.Cooperate ? "Cooperate" : "Defect";
        }

 
    }
}
