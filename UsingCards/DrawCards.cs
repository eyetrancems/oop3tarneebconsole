using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cards;

namespace UsingCards
{
    class DrawCards
    { // Draw cards outlines
        public static void DrawCardOutline(int xcoor, int ycoor)
        {
            Console.ForegroundColor = ConsoleColor.Black; // Change colour later

            int x = xcoor * 7;
            int y = ycoor;

            Console.SetCursorPosition(x, y);
            Console.Write(" _____\n"); // top edge of the card

            for (int i = 0; i < 5; i++)
            {
                Console.SetCursorPosition(x, y + 1 + i);

                if (i != 4)
                {
                    Console.WriteLine("|     |");  // left and right edge of card
                }
                else
                {
                    Console.WriteLine("|_____|"); // bottom
                }
            }

        }

        public static void DrawCardSuitValue(Card card, int xcoor, int ycoor)
        {
            char cardSuit = ' ';
            int x = xcoor * 7;
            int y = ycoor;

            // Encode each byte array from the CodePage437 into a character
            // Hearts and Diamonds are red, Clubs and Spades are black
            switch (card.Suit)
            {
                case Enums.Suit.HEART:
                    //cardSuit = Encoding.GetEncoding(437).GetChars(new byte[] { 3 })[0];
                    cardSuit = 'H';
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case Enums.Suit.DIAMOND:
                    //cardSuit = Encoding.GetEncoding(437).GetChars(new byte[] { 4 })[0];
                    cardSuit = 'D';
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case Enums.Suit.CLUB:
                    //cardSuit = Encoding.GetEncoding(437).GetChars(new byte[] { 5 })[0];
                    cardSuit = 'C';
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
                case Enums.Suit.SPADE:
                    //cardSuit = Encoding.GetEncoding(437).GetChars(new byte[] { 6 })[0];
                    cardSuit = 'S';
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
                default:
                    cardSuit = 'A';
                    break;
            }

            // Display the encoded character and value of card

            Console.SetCursorPosition(x + 3, y + 2);
            Console.Write(cardSuit);

            if (card.CardNumber.ToString().Length == 3)
            {
                Console.SetCursorPosition(x + 2, y + 3);
            }
            else
            {
                Console.SetCursorPosition(x + 1, y + 3);
            }
            Console.Write(card.CardNumber);


        }
    }
}