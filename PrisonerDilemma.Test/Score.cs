using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PrisonersDilemma.Test
{
    [TestClass]
    public class Score
    {
        [TestMethod]
        public void Score_BothCooperator()
        {
            var p1 = new PrisonersDilemma.Prisoner("p1", new PrisonersDilemma.Cooperator());
            var p2 = new PrisonersDilemma.Prisoner("p2", new PrisonersDilemma.Cooperator());
            
            //Set the prisoners Last Choices
            p1.LastChoice  = PrisonersDilemma.StrategyChoice.Cooperate;
            p2.LastChoice  = PrisonersDilemma.StrategyChoice.Cooperate;

            PrisonersDilemma.Score.DetermineResult(p1, p2); 

           Assert.AreEqual(p1.RoundScore, 1);
           Assert.AreEqual(p2.RoundScore,1);

        }
        [TestMethod]
        public void Score_BothDefect()
        {
            var p1 = new PrisonersDilemma.Prisoner("p1", new PrisonersDilemma.Defector ());
            var p2 = new PrisonersDilemma.Prisoner("p2", new PrisonersDilemma.Defector());
            //Set the prisoners Last Choices
            p1.LastChoice = PrisonersDilemma.StrategyChoice.Defect ;
            p2.LastChoice = PrisonersDilemma.StrategyChoice.Defect ;

            PrisonersDilemma.Score.DetermineResult(p1, p2);

            Assert.AreEqual(p1.RoundScore, 2);
            Assert.AreEqual(p2.RoundScore, 2);

        }
        [TestMethod]
        public void Score_OneDefect()
        {
            var p1 = new PrisonersDilemma.Prisoner("p1", new PrisonersDilemma.Defector());
            var p2 = new PrisonersDilemma.Prisoner("p2", new PrisonersDilemma.Defector());
            //Set the prisoners Last Choices
            p1.LastChoice = PrisonersDilemma.StrategyChoice.Defect;
            p2.LastChoice = PrisonersDilemma.StrategyChoice.Cooperate ;

            PrisonersDilemma.Score.DetermineResult(p1, p2);

            Assert.AreEqual(p1.RoundScore, 3);
            Assert.AreEqual(p2.RoundScore, 0);
        }

        [TestMethod]
        public void Score_OneDefect_2()
        {
            var p1 = new PrisonersDilemma.Prisoner("p1", new PrisonersDilemma.Defector());
            var p2 = new PrisonersDilemma.Prisoner("p2", new PrisonersDilemma.Defector());
            //Set the prisoners Last Choices
            p1.LastChoice = PrisonersDilemma.StrategyChoice.Cooperate ;
            p2.LastChoice = PrisonersDilemma.StrategyChoice.Defect ;

            PrisonersDilemma.Score.DetermineResult(p1, p2);

            Assert.AreEqual(p1.RoundScore, 0);
            Assert.AreEqual(p2.RoundScore, 3);
     
        }
    }
}
