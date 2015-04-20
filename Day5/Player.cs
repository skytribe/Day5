using Blackjack;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public class Player
    {
        public Player()
        {
            Hand = new List<Card>();
        }

        public PlayerState  PState { get; set; }  
        public PlayerType  PType { get; set; }   

        public List<Card> Hand { get; set; }

        
        public int AcesInHand
        {
            get {
                return countAcesInHand();
             }
        }

        private int countAcesInHand()
        {
            int count=0 ;
            foreach (var c in Hand)
            {
                if (c.CardType==Cards.Card_Ace )
                {
                    count++;
                }
            }
            return count;
        }

        private int cardTotal;
        private int cardTotalHigherPossibility ;

        public int CardTotal
        {
            get {
                calculateTotal();
                return cardTotal;
            }
        }

        public int CardTotalHigherPossibility 
        {
            get {
                calculateTotal();   //TODO: Put this is for correctness but results in recalc every time either property is checked. 
                return cardTotalHigherPossibility;
            }
        }
        
        private void calculateTotal()
        {
            // Get total of all cards that are not aces            
            int total = 0;
            foreach (var c in Hand)
            {
                if (c.CardType != Cards.Card_Ace)
                {
                    total = total + c.CardValue;
                }
            }

            // get aces count
            if (AcesInHand==0)
            {
                cardTotal = total;
                cardTotalHigherPossibility = 0;
            }
            else
            {
                Debug.Assert(AcesInHand  >=1 && AcesInHand<=4, "Unexpected Potential Return");

                //We need to get the potential for Aces
                var potential = Blackjack.Program.PotentialAceValues(AcesInHand);

                Debug.Assert(potential.Count == 2, "Unexpected Potential Return");

                cardTotal = total + potential[0];
                cardTotalHigherPossibility =  total + potential[1];
            }
        }


        public void ShowHand(bool Clear=false)
        {
            if (Clear)
                Console.Clear();

            //Display a list of all the cards in the players hand
            foreach (var c in  Hand)
            {
                Console.WriteLine("{0}  {1}", c.CardSuit, c.CardType);
                
            }
        }

    }
}
