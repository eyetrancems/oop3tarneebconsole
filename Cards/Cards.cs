using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards
{
    public static class Enums
    {

        public enum Suit
        {
            CLUB = 1,
            DIAMOND = 2,
            HEART = 3,
            SPADE = 4,
        }

        public enum CardNumber
        {
            TWO = 1,
            THREE = 2,
            FOUR = 3,
            FIVE = 4,
            SIX = 5,
            SEVEN = 6,
            EIGHT = 7,
            NINE = 8,
            TEN = 9,
            JACK = 10,
            QUEEN = 11,
            KING = 12,
            ACE = 13

        }

        //public enum Value
        //{
        //    TWO = 1,
        //    THREE = 2,
        //    FOUR = 3,
        //    FIVE = 4,
        //    SIX = 5,
        //    SEVEN = 6,
        //    EIGHT = 7,
        //    NINE = 8,
        //    TEN = 9,
        //    JACK = 10,
        //    QUEEN = 11,
        //    KING = 12,
        //    ACE = 13
        //}




    }

    public class Card
    {
        
        public Enums.Suit Suit { get; set; }
        public Enums.CardNumber CardNumber { get; set; }

        //public Enums.Value Value { get; set; }

        public override string ToString()
        {

            return "The Suit is: " + this.Suit + " The card number is: " + this.CardNumber;



        }
    }

    public class Deck
    {
        public Deck()
        {
            Reset();
        }

        public List<Card> Cards { get; set; }

        public void Reset()
        {
            Cards = Enumerable.Range(1, 4)
                .SelectMany(s => Enumerable.Range(1, 13)
                                    .Select(c => new Card()
                                    {
                                        Suit = (Enums.Suit)s,
                                        CardNumber = (Enums.CardNumber)c
                                    }
                                            )
                            )
                   .ToList();
        }

        public void Shuffle()
        {
            Cards = Cards.OrderBy(c => Guid.NewGuid())
                         .ToList();
        }

        public Card TakeCard()
        {
            var card = Cards.FirstOrDefault();
            Cards.Remove(card);

            return card;
        }

        public List<Card> TakeCards(int numberOfCards)
        {
            var cards = Cards.Take(numberOfCards);

            //var takeCards = cards as Card[] ?? cards.ToArray();
            var takeCards = cards as List<Card> ?? cards.ToList();
            Cards.RemoveAll(takeCards.Contains);

            return takeCards;
        }

        public List<Card> Sort(List<Card> listOfCards)
        {
            List<Card> sorted = listOfCards.GroupBy(s => s.Suit).
                OrderByDescending(c => c.Count()).SelectMany(g => g.OrderByDescending(c => c.CardNumber)).ToList();

            return sorted;

        }
    }


}
