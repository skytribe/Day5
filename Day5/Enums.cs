using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{

    public enum Suit { Clubs, Hearts, Spades, Diamonds }

    public enum Cards { Card_Ace, c2, c3, c4, c5, c6, c7, c8, c9, c10, Card_Jack, Card_Queen, Card_King }

    public enum  PlayerType { Player, Dealer}

    public enum PlayerState { Playing, Busted, Hold }

}
