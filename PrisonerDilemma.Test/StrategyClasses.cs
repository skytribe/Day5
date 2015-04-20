using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PrisonersDilemma.Test
{
    [TestClass]
    public class StrategyClassTests
    {
        [TestMethod]
        public void Cooperator_Step()
        {
            var p = new Cooperator();
            Assert.AreEqual(p.Step(StrategyChoice.Cooperate), StrategyChoice.Cooperate, "unexpected Initial State");
        }


        [TestMethod]
        public void Defector_Step()
        {
            var p = new Defector();
            Assert.AreEqual(p.Step(StrategyChoice.Defect), StrategyChoice.Defect, "unexpected Initial State");
        }


        [TestMethod]
        public void TitTat_Coorprator_Step()
        {
            var p = new TitForTat();
            Assert.AreEqual(p.Step(StrategyChoice.Cooperate), StrategyChoice.Cooperate, "unexpected Initial State");
        }

        [TestMethod]
        public void TitTat_Defector_Step()
        {
            var p = new TitForTat();
            Assert.AreEqual(p.Step(StrategyChoice.Defect), StrategyChoice.Defect, "unexpected Initial State");
        }


        [TestMethod]
        public void UnTitTat_Defector_Step()
        {
            var p = new UnTitForTat();
            Assert.AreEqual(p.Step(StrategyChoice.Defect), StrategyChoice.Cooperate, "unexpected Initial State");
        }


        [TestMethod]
        public void UnTitTat_Coorprator_Step()
        {
            var p = new UnTitForTat();
            Assert.AreEqual(p.Step(StrategyChoice.Cooperate), StrategyChoice.Defect, "unexpected Initial State");
        }



        [TestMethod]
        public void Random_Coorprator_Step()
        {

            bool differentResult = true;

            var p = new RandomChoice();
            validateRandomChoice(StrategyChoice.Cooperate, ref differentResult, ref p);


            Assert.IsTrue(differentResult, "didn't see a random in 5 occurences");
        }

        [TestMethod]
        public void Random_Defector_Step()
        {



            bool differentResult = true;

            var p = new RandomChoice();
            validateRandomChoice(StrategyChoice.Defect, ref differentResult, ref p);
            Assert.IsTrue(differentResult, "didn't see a random in 5 occurences");
        }


        private static void validateRandomChoice(StrategyChoice startStrategy, ref bool differentResult, ref RandomChoice p)
        {
            //Check one of the two valid values is found.
            //  bool foundValidValue = false;
            var x = p.Step(startStrategy);
      

            for (int i = 0; i < 5; i++)
            {
                p = new RandomChoice();
                var xr = p.Step(startStrategy);

                if (x != xr)
                {
                    differentResult = true;
                    break;
                }

            }
        }
    }
}
