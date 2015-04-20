using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonersDilemma
{

    //    Create a new Visual Studio Console application named PrisonersDilemma.

    //In the Prisoner's Dilemma, two members of a gang of bank robbers are arrested. The prisoners are being held in seperate cells and they cannot communicate with one another. Both prisoners have the option to either blame the crime on the other prisoner (defect) or remain silent (cooperate).
    //•If both Prisoner A and Prisoner B defect (blame the other) then both prisoners get 2 years in prison.
    //•If Prisoner A defects and Prisoner B cooperates then Prisoner A is set free and Prisoner B gets 3 years in prison.
    //•If both prisoners cooperate then both prisoners get 1 year in prison.

    //What’s the best strategy to follow? Create 5 player classes that represent different strategies:
    //1.Defector – Always defects
    //2.Cooperator – Always cooperates
    //3.Random – Randomly decides
    //4.TitForTat – Does the same thing as the last thing the other prisoner chose.
    //5.UnTitForTat – Does the opposite of the last thing the other prisoner chose.

    //Create a Game class that enables you to compare the different strategies:
    //•You should be able to specify the number of rounds to test.
    //•The Game class should report the scores for each strategy at the end of the game.

    //What's the best strategy for winning the prisoner's dilemma?

    //Write robust code:
    //•Include unit tests - especially for the different strategies
    //•Include lots of comments - XML and inline.

    //Think about performance:
    //•Use the Visual Studio Profiler to identify slow running code and try to improve it.



    public class Prisoner
    {
        private int totalScore = 0;   // Cumulative years over multiple rounds
        private int roundScore = 0;   // Additional years for just this round

        public string Name { get; set; }
        public StrategyChoice? LastChoice { get; set; }
        public IPDStrategy Strategy { get; private set; }

        // Read Only Properties for Scores - set through AddScore method
        public int RoundScore { get { return roundScore; } }
        public int TotalScore { get { return totalScore; } }


        /// <summary>
        /// Constructor used to establish the prisoner name and the strategy that they are adopting
        /// </summary>
        /// <param name="name"></param>
        /// <param name="strategy"></param>
        public Prisoner(string name, IPDStrategy strategy)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException("name", "name can not be null or empty");
            if (strategy == null) throw new NullReferenceException("Strategy not set");

            Name = name;
            Strategy = strategy;
            LastChoice = null;
        }


        public StrategyChoice Step(StrategyChoice? opponentChoice)
        {
            if (Strategy == null) throw new NullReferenceException("Strategy not set");

            // Set LastChoice based upon if this is the first iteration or not.
            LastChoice = !opponentChoice.HasValue ? Strategy.Start() : Strategy.Step(opponentChoice.Value);
            return LastChoice.Value;
        }

        /// <summary>
        /// Update the score depending upon inputScore
        /// </summary>
        /// <param name="inputScore">Represents additional years</param>
        public void AddScore(int inputScore)
        {
            roundScore = inputScore;
            totalScore += inputScore;   // Increments cumulative total by score
        }

    }
}
