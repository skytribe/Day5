using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PrisonersDilemma.Test
{
    [TestClass]
    public class Game
    {


        [TestMethod]
        public void TestMethod_Game_GameType()
        {

            var p1 = new Prisoner("Coperator", new Cooperator());
            var p2 = new Prisoner("untitfortate", new UnTitForTat());

            var g = new PrisonersDilemma.Game(p1, p2);

            Assert.IsInstanceOfType(g, typeof(PrisonersDilemma.Game), "Unexpected Type Created");
        }

        #region "Verify prisoner strategies are correctly set by various game constructors"
        [TestMethod]
        public void TestMethod_Game_Set_prisoner1()
        {

            var p1 = new Prisoner("Coperator", new Cooperator());
            var p2 = new Prisoner("untitfortate", new UnTitForTat());

            var g = new PrisonersDilemma.Game(p1, p2);

            Assert.IsInstanceOfType(g.prisoner1.Strategy, typeof(Cooperator), "Unexpected prisoner in game");
        }

        [TestMethod]
        public void TestMethod_Game_Set_prisoner2()
        {

            var p1 = new Prisoner("Coperator", new Cooperator());
            var p2 = new Prisoner("untitfortate", new UnTitForTat());

            var g = new PrisonersDilemma.Game(p1, p2);

            Assert.IsInstanceOfType(g.prisoner2.Strategy, typeof(UnTitForTat), "Unexpected prisoner in game");
        }
        [TestMethod]
        public void TestMethod_Game_Set_prisoner2a()
        {

            var p1 = new Prisoner("Coperator", new Cooperator());
            var p2 = new Prisoner("untitfortate", new TitForTat());

            var g = new PrisonersDilemma.Game(p1, p2);

            Assert.IsInstanceOfType(g.prisoner2.Strategy, typeof(TitForTat), "Unexpected prisoner in game");
        }

        [TestMethod]
        public void TestMethod_Game_Set_prisoner1a()
        {

            var p1 = new Prisoner("Defector", new Defector());
            var p2 = new Prisoner("untitfortate", new TitForTat());

            var g = new PrisonersDilemma.Game(p1, p2);

            Assert.IsInstanceOfType(g.prisoner1.Strategy, typeof(Defector), "Unexpected prisoner in game");
        }
        #endregion
    }
}
