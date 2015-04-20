using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Blackjack;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class Program
    {
        #region "Test Ace values"

        [TestMethod]
        public void PotentialAceValues_Test_Aces_1()
        {
            var x = Blackjack.Program.PotentialAceValues(1);

            // Checking Return Data
            Assert.IsTrue(x.Count == 2, "Incorrect Count");
            Assert.IsTrue(x.Contains(1), "Incorrect Value");
            Assert.IsTrue(x.Contains(11), "Incorrect Value");
        }

        [TestMethod]
        public void PotentialAceValues_Test_Aces_2()
        {

            var x = Blackjack.Program.PotentialAceValues(2);

            // Checking Return Data
            Assert.IsTrue(x.Count == 2, "Incorrect Count");
            Assert.IsTrue(x.Contains(2), "Incorrect Value");
            Assert.IsTrue(x.Contains(12), "Incorrect Value");
        }

        [TestMethod]
        public void PotentialAceValues_Test_Aces_3()
        {

            var x = Blackjack.Program.PotentialAceValues(3);

            // Checking Return Data
            Assert.IsTrue(x.Count == 2, "Incorrect Count");
            Assert.IsTrue(x.Contains(3), "Incorrect Value");
            Assert.IsTrue(x.Contains(13), "Incorrect Value");
        }

        [TestMethod]
        public void PotentialAceValues_Test_Aces_4()
        {
            var x = Blackjack.Program.PotentialAceValues(4);

            // Checking Return Data
            Assert.IsTrue(x.Count == 2, "Incorrect Count");
            Assert.IsTrue(x.Contains(4), "Incorrect Value");
            Assert.IsTrue(x.Contains(14), "Incorrect Value");
        }

        [TestMethod]
        public void PotentialAceValues_Test_Aces_0()
        {
            var x = Blackjack.Program.PotentialAceValues(0);

            // Checking Return Data
            Assert.IsTrue(x.Count == 0, "Incorrect Count");
        }

        [TestMethod]
        public void PotentialAceValues_Test_Aces_6()
        {
            var x = Blackjack.Program.PotentialAceValues(6);

            // Checking Return Data
            Assert.IsTrue(x.Count == 0, "Incorrect Count");
        }

        #endregion

        #region "Test bust scenarios"

        [TestMethod]
        public void IsBusted_Test1()
        {
            List<Card> hand = new List<Card>();
            hand.Add(new Card(Suit.Clubs, Cards.Card_Ace));
            hand.Add(new Card(Suit.Clubs, Cards.c2));

            var x = Blackjack.Program.IsBusted(hand);

            Assert.IsFalse(x, "Expected Not Bust");
        }


        [TestMethod]
        public void IsBusted_Test2()
        {
            // No Ac Busted
            List<Card> hand = new List<Card>();
            hand.Add(new Card(Suit.Clubs, Cards.c9));
            hand.Add(new Card(Suit.Clubs, Cards.c10));
            hand.Add(new Card(Suit.Clubs, Cards.c8));

            var x = Blackjack.Program.IsBusted(hand);

            Assert.IsTrue(x, "Expected Not Bust");
        }

        [TestMethod]
        public void IsBusted_Test3()
        {
            // 2 aces busted
            List<Card> hand = new List<Card>();
            hand.Add(new Card(Suit.Clubs, Cards.Card_Ace));
            hand.Add(new Card(Suit.Clubs, Cards.c9));
            hand.Add(new Card(Suit.Diamonds, Cards.c9));
            hand.Add(new Card(Suit.Diamonds, Cards.Card_Ace));
            hand.Add(new Card(Suit.Diamonds, Cards.Card_Jack));

            var x = Blackjack.Program.IsBusted(hand);

            Assert.IsTrue(x, "Expected Not Bust");
        }


        [TestMethod]
        public void IsBusted_Test4()
        {
            // 3 aces not busted
            List<Card> hand = new List<Card>();
            hand.Add(new Card(Suit.Clubs, Cards.Card_Ace)); ;
            hand.Add(new Card(Suit.Diamonds, Cards.Card_Ace));
            hand.Add(new Card(Suit.Hearts, Cards.Card_Ace));
            var x = Blackjack.Program.IsBusted(hand);
            Assert.IsFalse(x, "Expected Not Bust");
        }

        [TestMethod]
        public void IsBusted_Test5()
        {
            // 3 aces busted
            List<Card> hand = new List<Card>();
            hand.Add(new Card(Suit.Clubs, Cards.Card_Ace)); ;
            hand.Add(new Card(Suit.Diamonds, Cards.Card_Ace));
            hand.Add(new Card(Suit.Hearts, Cards.Card_Ace));
            hand.Add(new Card(Suit.Diamonds, Cards.Card_Jack));
            hand.Add(new Card(Suit.Diamonds, Cards.Card_King));

            var x = Blackjack.Program.IsBusted(hand);
            Assert.IsTrue(x, "Expected Not Bust");
        }
        #endregion

        #region "Test Card Values"

        [TestMethod]
        public void GetValueOfCard_Ace()
        {
            var x = Blackjack.Program.GetValueOfCard(Cards.Card_Ace);
            Assert.AreEqual(1, x, "Expected Value did not return");
        }


        [TestMethod]
        public void GetValueOfCard_C2()
        {
            var x = Blackjack.Program.GetValueOfCard(Cards.c2);
            Assert.AreEqual(2, x, "Expected Value did not return");
        }

        [TestMethod]
        public void GetValueOfCard_C3()
        {
            var x = Blackjack.Program.GetValueOfCard(Cards.c3);
            Assert.AreEqual(3, x, "Expected Value did not return");
        }

        [TestMethod]
        public void GetValueOfCard_C4()
        {
            var x = Blackjack.Program.GetValueOfCard(Cards.c4);
            Assert.AreEqual(4, x, "Expected Value did not return");
        }


        [TestMethod]
        public void GetValueOfCard_C5()
        {
            var x = Blackjack.Program.GetValueOfCard(Cards.c5);
            Assert.AreEqual(5, x, "Expected Value did not return");
        }


        [TestMethod]
        public void GetValueOfCard_C6()
        {
            var x = Blackjack.Program.GetValueOfCard(Cards.c6);
            Assert.AreEqual(6, x, "Expected Value did not return");
        }


        [TestMethod]
        public void GetValueOfCard_C7()
        {
            var x = Blackjack.Program.GetValueOfCard(Cards.c7);
            Assert.AreEqual(7, x, "Expected Value did not return");
        }


        [TestMethod]
        public void GetValueOfCard_C8()
        {
            var x = Blackjack.Program.GetValueOfCard(Cards.c8);
            Assert.AreEqual(8, x, "Expected Value did not return");
        }


        [TestMethod]
        public void GetValueOfCard_C9()
        {
            var x = Blackjack.Program.GetValueOfCard(Cards.c9);
            Assert.AreEqual(9, x, "Expected Value did not return");
        }


        [TestMethod]
        public void GetValueOfCard_C10()
        {
            var x = Blackjack.Program.GetValueOfCard(Cards.c10);
            Assert.AreEqual(10, x, "Expected Value did not return");
        }


        [TestMethod]
        public void GetValueOfCard_Jack()
        {
            var x = Blackjack.Program.GetValueOfCard(Cards.Card_Jack);
            Assert.AreEqual(10, x, "Expected Value did not return");
        }


        [TestMethod]
        public void GetValueOfCard_Queen()
        {
            var x = Blackjack.Program.GetValueOfCard(Cards.Card_Queen);
            Assert.AreEqual(10, x, "Expected Value did not return");
        }


        [TestMethod]
        public void GetValueOfCard_King()
        {
            var x = Blackjack.Program.GetValueOfCard(Cards.Card_King);
            Assert.AreEqual(10, x, "Expected Value did not return");
        }
        #endregion

        #region "Validate Deck and Shuffle"

        [TestMethod]
        public void ValidateDeck()
        {
            var x = Blackjack.Program.PopulateDeck();

            Assert.AreEqual(52, x.Count, "Expected count did not occur");

            //Check each suit is present
            Assert.IsTrue(suiteExists(x, Suit.Clubs));
            Assert.IsTrue(suiteExists(x, Suit.Diamonds));
            Assert.IsTrue(suiteExists(x, Suit.Hearts));
            Assert.IsTrue(suiteExists(x, Suit.Spades));
        }


        [TestMethod]
        public void ValidateShuffle()
        {
            //TODO: Add you validate shuffle test method.
        }


        private bool suiteExists(Dictionary<int, Card> deck, Suit suitToSearch)
        {
            bool found = false;
            foreach (var card in deck)
            {
                if (card.Value.CardSuit == suitToSearch)
                {
                    found = true;
                    break;
                }
            }
            return found;
        }
        #endregion

        #region "Who wins scenarios"

        [TestMethod]
        public void WhoWins_AcesNone()
        {
            var x = Blackjack.Program.WhoWins(0, 10, 0, 0, 11, 0);
            Assert.AreEqual(PlayerType.Dealer, x, "Expect 1 representing dealer wins");

        }

        [TestMethod]
        public void WhoWins_AcesOnePlayer()
        {
            var x = Blackjack.Program.WhoWins(1, 11, 21, 0, 13, 0);
            Assert.AreEqual(PlayerType.Player, x, "Expect 1 representing dealer wins");

        }

        [TestMethod]
        public void WhoWins_AcesOneDealer()
        {
            var x = Blackjack.Program.WhoWins(0, 13, 0, 1, 11, 21);
            Assert.AreEqual(PlayerType.Player, x, "Expect 1 representing dealer wins");

        }


        [TestMethod]
        public void WhoWins_AcesTwoPlayer_DealerWins()
        {
            var x = Blackjack.Program.WhoWins(2, 2, 12, 0, 13, 0);
            Assert.AreEqual(PlayerType.Dealer, x, "Expect 1 representing dealer wins");

        }

        [TestMethod]
        public void WhoWins_AcesTwoDealer_PlayerWins()
        {
            var x = Blackjack.Program.WhoWins(0, 13, 0, 2, 2, 12);
            Assert.AreEqual(PlayerType.Player, x, "Expect 1 representing dealer wins");

        }

        [TestMethod]
        public void WhoWins_AcesTwoDealerLoses()
        {
            var x = Blackjack.Program.WhoWins(0, 20, 0, 2, 2, 12);
            Assert.AreEqual(PlayerType.Player, x, "Expect 1 representing dealer wins");

        }

        [TestMethod]
        public void WhoWins_AcesTwoPlayer_DealerLoses()
        {
            // two aces and a 2 card
            var x = Blackjack.Program.WhoWins(2, 4, 14, 0, 13, 0);
            Assert.AreEqual(PlayerType.Player, x, "Expect 1 representing dealer wins");

        }

        [TestMethod]
        public void WhoWins_AcesBothPlayers_DealerWin()
        {
            // two aces and a 2 card
            var x = Blackjack.Program.WhoWins(2, 4, 14, 1, 5, 15);
            Assert.AreEqual(PlayerType.Dealer, x, "Expect 1 representing dealer wins");

        }

        [TestMethod]
        public void WhoWins_AcesBothPlayers_PlayerWin()
        {
            // two aces and a 2 card
            var x = Blackjack.Program.WhoWins(2, 9, 19, 1, 5, 15);
            Assert.AreEqual(PlayerType.Player, x, "Expect 1 representing dealer wins");

        }

        #endregion
    }
}
