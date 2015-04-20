using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public class Program
    {
        static List<Suit> ListOfSuits = new List<Suit> { Suit.Clubs, Suit.Hearts, Suit.Spades, Suit.Diamonds };
        static List<Cards> ListOfCardsInAGivenSuit = new List<Cards> { Cards.Card_Ace, Cards.c2, Cards.c3, Cards.c4, Cards.c5, Cards.c6, Cards.c7, Cards.c8, Cards.c9, Cards.c10, Cards.Card_Jack, Cards.Card_Queen, Cards.Card_King};
     
        static Dictionary<int, Card> Deck;

        const string DEALER_WINS = "DEALER WINS";
        const string DEALER_BUSTS = "DEALER BUSTS";
        const string PLAYER_BUSTS = "PLAYER 1 BUSTS";
        const string PLAYER_WINS = "PLAYER 1 WINS";
        const string BLACKJACK_OCCURED = "Yaaaaaaa   Blackjack occured";


        static void Main(string[] args)
        {
            ////            Create a new Visual Studio Console application named Blackjack. 

            ////Create a Blackjack game that enables you to compete against the computer (the dealer). Here are the rules for Blackjack:
            ////•The goal of the game is to have a hand that has a value greater than the dealer but not greater than 21.
            ////•The number cards have their face values. The Queen, King, Jack have the value 10. Finally, the Ace is worth either 1 or 11 (player's choice).
            ////•If a player's cards add up to over 21 then the player loses (busts).
            ////•Each round, a player can either hit (take a new card) or stand (not take a card).

            ////Write robust code:
            ////•Use XML comments for all methods and properties.
            ////•Use Debug.Asserts() in your code to verify assumptions.
            ////•Use Unit Tests to verify your methods.


            //Randomize the deck
            //Create a random list of numbers - has to be unique random numbers to represent the deck

            Deck = PopulateDeck();

            // Index of random number 0 - 51 representing the indexes in the deck.
            var shuffledDeck = GenerateShuffledDeck();
            // DisplayDeck(shuffledDeck);

            bool newHand = true;  //Indicates if this is the start of a hand which we need to draw 2 cards each.
            int CurrentIndex = 0;  //Current index in the shuffledeck

            //Used to maintain game state totals
            int Player1Total = 0;
            int DealerTotal = 0;

            // Player objects to represent player and dealer
            Player player1 = new Player { PType  =  PlayerType.Player };
            Player dealer = new Player { PType = PlayerType.Dealer };
            
            newHand = true;
            while (CurrentIndex < shuffledDeck.Count)
            {
                if (newHand)
                {
                    if (CurrentIndex + 10 >= 42)
                    {
                        Console.WriteLine("Reshuffling the deck before playing next hand");
                        //wE NEED TO RESHUFFLE THE Deck and reset the index
                        shuffledDeck = GenerateShuffledDeck();
                        CurrentIndex = 0;
                    }

                    //Reset Player details for next hand
                    player1 = new Player { PType = PlayerType.Player };
                    dealer = new Player { PType = PlayerType.Dealer };

                    // Establish startup each player is dealt 2 cards                    
                    player1.PState = 0;
                    player1.Hand.Add(Deck[shuffledDeck[CurrentIndex]]);
                    CurrentIndex++;
                    player1.Hand.Add(Deck[shuffledDeck[CurrentIndex]]);
                    CurrentIndex++;

                    dealer.PState = 0;
                    dealer.Hand.Add(Deck[shuffledDeck[CurrentIndex]]);
                    CurrentIndex++;
                    dealer.Hand.Add(Deck[shuffledDeck[CurrentIndex]]);
                    CurrentIndex++;

                    newHand = false; // we are not a new hand as we have dealt the cards                
                }

                //While Player1 has not busted, stuck and there are cards left.
                while (player1.PState == PlayerState.Playing )
                {
                    if (IsBusted(player1.Hand))
                    {
                        player1.ShowHand();                   
                        player1.PState = PlayerState.Busted ;
                        Console.WriteLine(PLAYER_BUSTS);
                        break;
                    }

                    //Display Player 1 hand so they can see there cards
                    player1.ShowHand();

                    //Detect is blackjack has occured.
              
                    var blackjackoccured = DidBlackJackOccur(player1);
                    if (blackjackoccured)
                    {
                        Console.WriteLine(BLACKJACK_OCCURED);
                        player1.PState = PlayerState.Hold ;
                        break;
                    }

                    // Prompt and get user response if required - ie. they havent busted
                    Console.WriteLine("h to hit, s to stick");
                    var response = Console.ReadLine();
                    if (response == "s")
                    {
                        player1.PState = PlayerState.Hold ;
                    }
                    else if (response == "h")
                    {
                        Console.Clear();
                        player1.PState = PlayerState.Playing;

                        //Pull next card
                        player1.Hand.Add(Deck[shuffledDeck[CurrentIndex]]);
                        CurrentIndex++;
                    }
                    else
                    {
                        Console.Clear();
                    }
                }

              
                PlayerType  WhichPlayerWon = PlayerType.Player ;  
                
                //***********************************************
                // DEALER LOGIC
                //**********************************************
                if (player1.PState == PlayerState.Busted )
                {
                    WhichPlayerWon = PlayerType.Dealer; ;
                    Console.WriteLine(DEALER_WINS);
                    dealer.ShowHand();
                }
                else
                {
                    while (dealer.PState == PlayerState.Playing)
                    {
                        if (IsBusted(dealer.Hand))
                        {
                            WhichPlayerWon = PlayerType.Player ;
                            Console.WriteLine(DEALER_BUSTS);
                            dealer.PState = PlayerState.Busted ;
                            dealer.ShowHand();
                            break;
                        }

                        bool doesDealerNeedToContinue = true;
                        bool blackjackoccured = false;

                        blackjackoccured = DidBlackJackOccur(dealer);
                        if (blackjackoccured)
                        {
                            Console.WriteLine(BLACKJACK_OCCURED);
                            WhichPlayerWon = PlayerType.Dealer;
                            Console.WriteLine(DEALER_WINS);
                            dealer.PState = PlayerState.Hold ;
                            doesDealerNeedToContinue = true;
                        }
                        else
                        {
                            //Blackjack didn't occur so determine who's winning is dealer wins he doesn't
                            //need to continue                            
                            PlayerType  WhichPlayerWon1  = WhoWins(player1.AcesInHand,
                                                               player1.CardTotal,
                                                               player1.CardTotalHigherPossibility,
                                                               dealer.AcesInHand,
                                                               dealer.CardTotal,
                                                               dealer.CardTotalHigherPossibility);

                            if (WhichPlayerWon1 == PlayerType.Dealer)
                                doesDealerNeedToContinue = false;


                            // this condition will determine dealer has a hand that beats the players hand
                            // and therefore we don't need to continue pulling cards
                            if (!doesDealerNeedToContinue)
                            {
                                WhichPlayerWon = PlayerType.Dealer;
                                Console.WriteLine(DEALER_WINS);
                                dealer.ShowHand();
                                break;
                            }
                            // Still need to pull cards to try and beat player
                            //Pull next card
                            dealer.Hand.Add(Deck[shuffledDeck[CurrentIndex]]);
                            CurrentIndex++;
                        }
                    }
                }
                DisplaySummary(ref Player1Total, ref DealerTotal, player1, dealer, WhichPlayerWon);

                Console.WriteLine("Hit any key to deal another hand");
                Console.ReadLine();
                Console.Clear();

                //Reset states
                player1.PState = 0;
                dealer.PState = 0;
                newHand = true;
            }
        }

        /// <summary>
        /// Display a summary of which player won.
        /// What the card totals were for the game and the overall score of hands won for each player
        /// </summary>
        /// <param name="Player1Total"></param>
        /// <param name="DealerTotal"></param>
        /// <param name="player1"></param>
        /// <param name="dealer"></param>
        /// <param name="WhichPlayerWon"></param>
        private static void DisplaySummary(ref int Player1Total, ref int DealerTotal, Player player1, Player dealer, PlayerType WhichPlayerWon)
        {
            // TODO: Check in here that WhichPlayerWon is valid if should be either
            // PlayerType.Player or PlayerType.Dealer

            // Validate player1 or player2 - we need them set
            if (player1 == null || dealer == null)
                return;  

            Console.WriteLine("\n\n\n\n\nRESULT OF HAND\n");            
            
            if (WhichPlayerWon == PlayerType.Player )
            {
                Console.WriteLine(PLAYER_WINS);
                Player1Total++;
            }
            else if (WhichPlayerWon ==PlayerType.Dealer )
            {
                Console.WriteLine(DEALER_WINS);
                DealerTotal++;
            }

            Console.WriteLine("Player Total: {0}({1})      Dealer Value{2}({3})", player1.CardTotal, player1.CardTotalHigherPossibility, dealer.CardTotal, dealer.CardTotalHigherPossibility);
            Console.WriteLine("Overall Total   Player:{0}      Dealer:{1}", Player1Total, DealerTotal);
        }


        /// <summary>
        /// The code determine based upon the score which person won the game.
        /// </summary>
        /// <param name="player1aces"></param>
        /// <param name="playertotal"></param>
        /// <param name="playertotal2"></param>
        /// <param name="dealeraces"></param>
        /// <param name="dealertotal"></param>
        /// <param name="Dealertotal2"></param>
        /// <returns></returns>
        public static PlayerType  WhoWins(int player1aces,
                                  int playertotal,
                                  int playertotal2,
                                  int dealeraces,
                                  int dealertotal,
                                  int Dealertotal2)
        {
            // TODO: Tidy up the variable and comments in here to document this method.
            PlayerType whowins = PlayerType.Player  ; //player1

            if (player1aces == 0 && dealeraces == 0)
            {
                if (dealertotal >= playertotal)
                    whowins = PlayerType.Dealer ;   //dealer wims
            }
            else if (player1aces > 0 && dealeraces == 0)
            {
                // Example Player1 Aces, Queen - 11 or 21 
                //         Dealer  10, 9 - 20

                // We need to check to see fi dealer 1 has any total higher than player1 and less than 21.

                // For this we need to evaluate which has the highest total under 21
                var player1highestunder21 = 0;
                if (playertotal <= 21) player1highestunder21 = playertotal;
                if (playertotal2 <= 21 && playertotal2 > player1highestunder21) player1highestunder21 = playertotal2;

                if (dealertotal >= player1highestunder21)
                {
                    whowins = PlayerType.Dealer;
                }
            }
            else if (player1aces == 0 && dealeraces > 0)
            {
                // Example Player1 Aces, Queen - 11 or 21 
                //         Dealer  10, 9 - 20

                // We need to check to see if dealer 1 has any total higher than player1 and less than 21.
                var dealerhighestunder21 = 0;
                if (dealertotal <= 21) dealerhighestunder21 = dealertotal;
                if (Dealertotal2 <= 21 && playertotal2 > dealerhighestunder21) dealerhighestunder21 = Dealertotal2;

                if (dealerhighestunder21 >= playertotal)
                {
                    whowins = PlayerType.Dealer;
                }
            }
            else if (player1aces > 0 && dealeraces > 0)
            {
                // For this we need to evaluate which has the highest total under 21
                var player1highestunder21 = 0;
                if (playertotal <= 21) player1highestunder21 = playertotal;
                if (playertotal2 <= 21 && playertotal2 > player1highestunder21) player1highestunder21 = playertotal2;

                var dealerhighestunder21 = 0;
                if (dealertotal <= 21) dealerhighestunder21 = dealertotal;
                if (Dealertotal2 <= 21 && playertotal2 > dealerhighestunder21) dealerhighestunder21 = Dealertotal2;

                if (dealerhighestunder21 >= player1highestunder21)
                    whowins = PlayerType.Dealer;
            }
            return whowins;
        }

        /// <summary>
        /// Determines if score of 21 occured.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="blackjackoccured"></param>
        /// <returns></returns>
        private static bool DidBlackJackOccur(Player player)
        {
            bool blackjackoccured = false;

            // if we got here we havent busted 
            //   if we have no aces just look at the total
            //   if we have aces we need to evaluate total and the alternate total as either could result in a 21.
            if (player.AcesInHand == 0)
            {
                if (player.CardTotal == 21)
                    blackjackoccured = true;
            }
            else
            {
                if (player.CardTotal == 21)
                    blackjackoccured = true;

                if (player.CardTotalHigherPossibility == 21)
                    blackjackoccured = true;
            }
            return blackjackoccured;
        }

        static List<int> shuffledDeck;
        static List<int> GenerateShuffledDeck()
        {

            shuffledDeck = new List<int>();

            var r = new Random();

            //We want to keep pulling random numbers until count on the shuffled deck is  = 52
            while (shuffledDeck.Count < 52)
            {
                int v = r.Next(52);
                if (shuffledDeck.Contains(v) == false)
                {
                    shuffledDeck.Add(v);
                }
            }
            return shuffledDeck;
        }

        private static void DisplayDeck(List<int> deck)
        {
            foreach (var item in shuffledDeck)
            {
                Console.WriteLine(item);
            }
        }

        public static Dictionary<int, Card> PopulateDeck()
        {
            var DeckBuilt = new Dictionary<int, Card>();
            int count = 0;  //Used for Key in dictionary

            foreach (var item in ListOfSuits)
            {
                foreach (var item2 in ListOfCardsInAGivenSuit)
                {
                    var c = new Card(item, item2);
                    DeckBuilt.Add(count, c);
                    count++;
                }
            }
            return DeckBuilt;
        }

        public static int GetValueOfCard(Cards item2)
        {
            int val = 0;

            switch (item2)
            {
                case Cards.Card_Ace:
                    val = 1;
                    break;

                case Cards.c2:
                    val = 2;
                    break;

                case Cards.c3:
                    val = 3;
                    break;

                case Cards.c4:
                    val = 4;
                    break;

                case Cards.c5:
                    val = 5;
                    break;

                case Cards.c6:
                    val = 6;
                    break;

                case Cards.c7:
                    val = 7;
                    break;

                case Cards.c8:
                    val = 8;
                    break;

                case Cards.c9:
                    val = 9;
                    break;

                case Cards.c10:
                    val = 10;
                    break;

                case Cards.Card_Jack:
                case Cards.Card_Queen:
                case Cards.Card_King:
                    val = 10;
                    break;

            }
            return val;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="NumberOfAces"></param>
        /// <returns></returns>
        public static List<int> PotentialAceValues(int NumberOfAces)
        {
            var retList = new List<int>();

            if (NumberOfAces < 1 || NumberOfAces > 4) { }
            else
            {
                switch (NumberOfAces)
                {
                    case 1:
                        retList.Add(1);
                        retList.Add(11);
                        break;
                    case 2:
                        retList.Add(2);
                        retList.Add(12);
                        break;
                    case 3:
                        retList.Add(3);
                        retList.Add(13);
                        break;
                    case 4:
                        retList.Add(4);
                        retList.Add(14);
                        break;
                }
            }

            return retList;
        }

        /// <summary>
        /// Calculate if the hand is busted
        /// </summary>
        /// <param name="hand"></param>
        /// <returns></returns>
        public static bool IsBusted(List<Card> hand)
        {
            // depending upon the number of aces we need to determine 
            //if we have bust 
            // if we have a potential of 21
            //if we are lower than 21
            int total = 0;
            int aces = 0;

            // Get total of all cards that are not aces
            foreach (var item in hand)
            {
                if (item.CardType != Cards.Card_Ace)
                {
                    total = total + item.CardValue;
                }
                else
                {
                    aces++;
                }
            }

            // *****************************
            // Determine if we have busted
            // ****************************
            var busted = true;
            // Now we need to detail possible if aces
            if (aces == 0)
            {
                //total is what we have
                if (total < 21)
                    busted = false;
            }
            else
            {
                //We need to get the potential for Aces
                var potential = PotentialAceValues(aces);

                var b = false;
                foreach (var item in potential)
                {
                    var potentialtotal = total + item;
                    if (potentialtotal < 21)
                        b = true;
                }

                if (b)
                {
                    busted = false;
                }
            }


            return busted;
        }


    }
}
