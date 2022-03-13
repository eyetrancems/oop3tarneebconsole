using System;
using System.Collections.Generic;
using System.Text;
using Cards;

namespace UsingCards
{
    class Player
    {
        public string name { get; set; }
        public List<Card> playersCards = new List<Card>();

    



        public Player(string name, List<Card> playersCards)
        {


            this.name = name;
            this.playersCards = playersCards;
        }




    }
}
