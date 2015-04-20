using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PrisonersDilemma.Test
{
    /// <summary>
    /// Summary description for Prisoner
    /// </summary>
    [TestClass]
    public class PrisonerTests
    {

        #region "Creating new prisoners"
        [TestMethod]
        public void Prisoner_Name()
        {
            var p = new PrisonersDilemma.Prisoner("Cooperator", new PrisonersDilemma.Cooperator());
            Assert.AreEqual(p.Name, "Cooperator", "Prisoner name not set correctly");
        }

        [TestMethod]
        public void Prisoner_Name_Null()
        {

            try
            {
                var p = new PrisonersDilemma.Prisoner(null, new PrisonersDilemma.Cooperator());
                Assert.Fail("Expected exception did not occur");
            }
            catch (ArgumentNullException)
            { }
            catch
            {
                Assert.Fail("Expected exception did not occur");
            }

        }

        [TestMethod]
        public void Prisoner_Name_Blank()
        {

            try
            {
                var p = new PrisonersDilemma.Prisoner("", new PrisonersDilemma.Cooperator());
                Assert.Fail("Expected exception did not occur");
            }
            catch (ArgumentNullException)
            { }
            catch
            {
                Assert.Fail("Expected exception did not occur");
            }

        }


        [TestMethod]
        public void Prisoner_Strategy_Null()
        {

            try
            {
                var p = new PrisonersDilemma.Prisoner("P1", null);
                Assert.Fail("Expected exception did not occur");
            }
            catch (NullReferenceException)
            { }
            catch
            {
                Assert.Fail("Expected exception did not occur");
            }

        }

        [TestMethod]
        public void Prisoner_Strategy_Cooperate()
        {
            var p = new PrisonersDilemma.Prisoner("P1", new PrisonersDilemma.Cooperator());
            Assert.IsInstanceOfType(p.Strategy, typeof(PrisonersDilemma.Cooperator), "Type is not cooperator");
        }

        [TestMethod]
        public void Prisoner_Strategy_Defector()
        {
            var p = new PrisonersDilemma.Prisoner("P2", new PrisonersDilemma.Defector());
            Assert.IsInstanceOfType(p.Strategy, typeof(PrisonersDilemma.Defector), "Type is not defector");
        }

        [TestMethod]
        public void Prisoner_Strategy_Interface_IDPStrategy()
        {
            var p = new PrisonersDilemma.Prisoner("P2", new PrisonersDilemma.Defector());
            Assert.IsInstanceOfType(p.Strategy, typeof(PrisonersDilemma.IPDStrategy), "Type is not interface IPDStrategy");
        }
        #endregion

        #region "Round Score Tests"
        [TestMethod]
        public void Prisoner_AddScore_roundScore1()
        {
            var p = new PrisonersDilemma.Prisoner("P2", new PrisonersDilemma.Defector());
            p.AddScore(0);
            Assert.AreEqual(0, p.RoundScore, "Unexpected Score");
        }

        [TestMethod]
        public void Prisoner_AddScore_roundScore2()
        {
            var p = new PrisonersDilemma.Prisoner("P2", new PrisonersDilemma.Defector());
            p.AddScore(3);
            Assert.AreEqual(3, p.RoundScore, "Unexpected Score");
        }


        [TestMethod]
        public void Prisoner_AddScore_roundScore3()
        {
            var p = new PrisonersDilemma.Prisoner("P2", new PrisonersDilemma.Defector());
            p.AddScore(1);
            Assert.AreEqual(1, p.RoundScore, "Unexpected Score");
        }

        #endregion

        #region "Total Score Tests"
        [TestMethod]
        public void Prisoner_AddScore_CumulativeScore1()
        {
            var p = new PrisonersDilemma.Prisoner("P2", new PrisonersDilemma.Defector());
            p.AddScore(1);
            p.AddScore(1);
            Assert.AreEqual(2, p.TotalScore, "Unexpected Score");
        }
        [TestMethod]
        public void Prisoner_AddScore_CumulativeScore2()
        {
            var p = new PrisonersDilemma.Prisoner("P2", new PrisonersDilemma.Defector());
            p.AddScore(1);
            p.AddScore(3);
            Assert.AreEqual(4, p.TotalScore, "Unexpected Score");
        }

        [TestMethod]
        public void Prisoner_AddScore_CumulativeScore3()
        {
            var p = new PrisonersDilemma.Prisoner("P2", new PrisonersDilemma.Defector());
            p.AddScore(0);
            p.AddScore(0);
            Assert.AreEqual(0, p.TotalScore, "Unexpected Score");
        }

        [TestMethod]
        public void Prisoner_AddScore_CumulativeScore4()
        {
            var p = new PrisonersDilemma.Prisoner("P2", new PrisonersDilemma.Defector());
            p.AddScore(-1);
            p.AddScore(-1);
            Assert.AreEqual(-2, p.TotalScore, "Unexpected Score");
        }

        public void Prisoner_AddScore_CumulativeScore5()
        {
            var p = new PrisonersDilemma.Prisoner("P2", new PrisonersDilemma.Defector());
            p.AddScore(1);
            p.AddScore(0);
            Assert.AreEqual(1, p.TotalScore, "Unexpected Score");
        }
        #endregion

    }
}
