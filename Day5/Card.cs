using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public class Card
    {
        public Card(Suit s, Cards c)
        {

            CardSuit = s;
            CardType = c;
        }

        public Suit CardSuit { get; set; }

        public Cards CardType { get; set; }


        public int CardValue
        {
            get { return Program.GetValueOfCard(CardType); }
        }

        public override string ToString()
        {
            return CardSuit + " " + CardType + " " + CardValue.ToString(); ;
        }

    }
}
