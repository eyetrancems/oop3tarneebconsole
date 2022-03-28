using System;
using Cards;
using System.Collections.Generic;
using System.Linq;

namespace UsingCards
{
    class Program
    {
        // List of String that holds Tarneeb suit betting (1. Tarneeb Suit, 2. Bet number, 3. Player who betted the most) global variable
        public static List<String> tarneebSuit = new List<String>() { };

        public static string difficulty = "easy";
        // Play Tarneeb is played is a global variable
        public static bool tarneebPlayed = false;

        public static Teams FirstTeam = new Teams();
        public static Teams SecondTeam = new Teams();

        // Main
        static void Main(string[] args)
        {
            // Set dimensions for console window
            Console.BufferWidth = 120;
            Console.BufferHeight = 50;
            Console.SetWindowSize(120, 50);
            
            // Title for console window
            Console.Title = "Tarneeb - Console Version";

            // List of String tarneeb settings (betting, selection, and player) called with RoundBet function
            tarneebSuit = RoundBetRandom();

            // Change console color to white
            Console.BackgroundColor = ConsoleColor.White;
                  

            // Create a deck
            var deck = new Deck();
            // Shuffle the deck
            deck.Shuffle();
            // Pass out 13 cards to each
            List<Card> pass1 = deck.Sort(deck.TakeCards(13));
            List<Card> pass2 = deck.Sort(deck.TakeCards(13));
            List<Card> pass3 = deck.Sort(deck.TakeCards(13));
            List<Card> pass4 = deck.Sort(deck.TakeCards(13));

            // Create Player1 with cards            
            Player player1 = new Player("Alaadin Addas", pass1);
            //player1.playersCards.ForEach(Console.WriteLine);
            //Console.WriteLine("_____________________________________");
            
            // Create Player2 with cards
            Player player2 = new Player("John Doe", pass2);
            //player2.playersCards.ForEach(Console.WriteLine);
            //Console.WriteLine("_____________________________________");
            
            // Create Player3 with cards
            Player player3 = new Player("Jane Doe", pass3);
            //player3.playersCards.ForEach(Console.WriteLine);
            //Console.WriteLine("_____________________________________");
            
            // Create Player4 with cards
            Player player4 = new Player("Some Doe", pass4);
            //player4.playersCards.ForEach(Console.WriteLine);

            //Assign Players to Teams
            FirstTeam = new Teams(player1, player2);
            SecondTeam = new Teams(player3, player4);

            // Create a List of Players
            List<Player> playerList = new List<Player> { player1, player2, player3, player4 };

            // Display all Players with cards cards
            displayCards(player1, player2, player3, player4);

            //bool quit = false;

            // Create empty card for each player
            Card playerCardChoose = new Card();
            Card computerCard1Choose = new Card();
            Card computerCard2Choose = new Card();
            Card computerCard3Choose = new Card();

            // List of Card for cards choosen for display and for evaluation
            List<Card> drawnCardList = new List<Card>();

            // Highest bidder player to start round
            int roundWinner = Convert.ToInt32(tarneebSuit[2]);

            // Stop game when no cards left (might have to change to when quit bool variable instead of all cards gone)
            while (FirstTeam.score != 41 || SecondTeam.score != 41)
            {
                // The drawn cards are emptied before each round
                drawnCardList = new List<Card>() { };
                
                //char selection = ' ';

                // Tarneeb played for each round is turned false Global variable
                tarneebPlayed = false;

                // Each round is dependent on who betted the most at first round or last round played player won
                // Player 0 won
                if (roundWinner == 0)
                {
                    // Player choose card
                    playerCardChoose = ChooseCard(player1, player1, player2, player3, player4, drawnCardList);                  
                    // Add card to list drawn
                    drawnCardList.Add(playerCardChoose);

                    // Computer 1  choose card
                    computerCard1Choose = ChooseCardComputer(player2, player1, player2, player3, player4, drawnCardList);
                    // Add card to list drawn
                    drawnCardList.Add(computerCard1Choose);

                    // Computer 2 choose card
                    computerCard2Choose = ChooseCardComputer(player3, player1, player2, player3, player4, drawnCardList);                  
                    // Add card to list drawn
                    drawnCardList.Add(computerCard2Choose);

                    // Computer 3 choose card
                    computerCard3Choose = ChooseCardComputer(player4, player1, player2, player3, player4, drawnCardList);
                    // Add card to list drawn
                    drawnCardList.Add(computerCard3Choose);
                }
                // Player 1 won
                else if (roundWinner == 1)
                {
                    // Computer 1
                    computerCard1Choose = ChooseCardComputer(player2, player1, player2, player3, player4, drawnCardList);
                    drawnCardList.Add(computerCard1Choose);

                    // Computer 2
                    computerCard2Choose = ChooseCardComputer(player3, player1, player2, player3, player4, drawnCardList);
                    drawnCardList.Add(computerCard2Choose);

                    // Computer 3
                    computerCard3Choose = ChooseCardComputer(player4, player1, player2, player3, player4, drawnCardList);
                    drawnCardList.Add(computerCard3Choose);

                    // Player 
                    playerCardChoose = ChooseCard(player1, player1, player2, player3, player4, drawnCardList);
                    drawnCardList.Add(playerCardChoose);
                }
                // Player 2 won
                else if (roundWinner == 2)
                {
                    // Computer 2
                    computerCard2Choose = ChooseCardComputer(player3, player1, player2, player3, player4, drawnCardList);
                    drawnCardList.Add(computerCard2Choose);

                    // Computer 3
                    computerCard3Choose = ChooseCardComputer(player4, player1, player2, player3, player4, drawnCardList);
                    drawnCardList.Add(computerCard3Choose);

                    // Player 
                    playerCardChoose = ChooseCard(player1, player1, player2, player3, player4, drawnCardList);
                    drawnCardList.Add(playerCardChoose);

                    // Computer 1
                    computerCard1Choose = ChooseCardComputer(player2, player1, player2, player3, player4, drawnCardList);
                    drawnCardList.Add(computerCard1Choose);
                }
                // Player 3 won
                else if (roundWinner == 3)
                {
                    // Computer 3
                    computerCard3Choose = ChooseCardComputer(player4, player1, player2, player3, player4, drawnCardList);
                    drawnCardList.Add(computerCard3Choose);

                    // Player 
                    playerCardChoose = ChooseCard(player1, player1, player2, player3, player4, drawnCardList);
                    drawnCardList.Add(playerCardChoose);

                    // Computer 1
                    computerCard1Choose = ChooseCardComputer(player2, player1, player2, player3, player4, drawnCardList);
                    drawnCardList.Add(computerCard1Choose);

                    // Computer 2
                    computerCard2Choose = ChooseCardComputer(player3, player1, player2, player3, player4, drawnCardList);
                    drawnCardList.Add(computerCard2Choose);
                }

                // Clear console
                Console.Clear();

                // Display cards
                displayCards(player1, player2, player3, player4);
                // Draw list of draw cards
                DrawDrawnCards(drawnCardList);

                // Evaluate

                int xcoor = 0;
                int ycoor = 47;
                Console.SetCursorPosition(xcoor, ycoor);
                
                // If tarneeb played the methods are different from just normal game
                if (tarneebPlayed == true)
                {
                    // 4 digit code for the 4 cards that are tarneeb
                    int comboSuit = FindTarneebsInList(drawnCardList);
                   
                    // Evaluate which player won the hand with tarneeb played
                    int whichPlayer = -1;
                    whichPlayer = HighestValueWithTarneeb(comboSuit, drawnCardList);

                    // If there is a winner
                    if (whichPlayer != -1)
                    {
                        // Determine the round winner
                        roundWinner = whichPlayer + roundWinner;
                        if (roundWinner > 3)
                        {
                            roundWinner = roundWinner - 4;
                        }

                        // Write to console which player won with what card
                        if (whichPlayer == 0)
                        {
                            Console.WriteLine(playerList[roundWinner].name + " has highest card! " + drawnCardList[0].ToString());
                            //FirstTeam.score += 1;
                        }
                        else if (whichPlayer == 1)
                        {
                            Console.WriteLine(playerList[roundWinner].name + " has highest card! " + drawnCardList[1].ToString());
                            //FirstTeam.score += 1;
                        }
                        else if (whichPlayer == 2)
                        {
                            Console.WriteLine(playerList[roundWinner].name + " has highest card! " + drawnCardList[2].ToString());
                            //SecondTeam.score += 1;
                        }
                        else if (whichPlayer == 3)
                        {
                            Console.WriteLine(playerList[roundWinner].name + " has highest card! " + drawnCardList[3].ToString());
                            //SecondTeam.score += 1;
                        }

                        // remove the played cards from players
                        player1.playersCards.Remove(playerCardChoose);
                        player2.playersCards.Remove(computerCard1Choose);
                        player3.playersCards.Remove(computerCard2Choose);
                        player4.playersCards.Remove(computerCard3Choose);

                        if (roundWinner == 0 || roundWinner == 1)
                        {
                            FirstTeam.score += 1;
                        }
                        else
                        {
                            SecondTeam.score += 1;
                        }
                    }

                    // Pause
                    Console.ReadLine();

                }

                // Played normal game without tarneeb played
                else
                {
                    // Determine the 4 digit code with cards with same suit as first
                    int comboSuit = ReturnSameSuitAsFirst(drawnCardList);

                    // Determine which player had the highest card
                    int whichPlayer = -1;               
                    whichPlayer = HighestValueWithDifferentSuits(comboSuit, drawnCardList);                   

                    // If there was a winner
                    if (whichPlayer != -1)
                    {
                        // Determine round winner for next round
                        roundWinner = whichPlayer + roundWinner;
                        if (roundWinner > 3)
                        {
                            roundWinner = roundWinner - 4;
                        }

                        // Write to console which player won with what card
                        if (whichPlayer == 0)
                        {
                            Console.WriteLine(playerList[roundWinner].name + " has highest card! " + drawnCardList[0].ToString());
                            //FirstTeam.score += 1;
                        }
                        else if (whichPlayer == 1)
                        {
                            Console.WriteLine(playerList[roundWinner].name + " has highest card! " + drawnCardList[1].ToString());
                            //FirstTeam.score += 1;
                        }
                        else if (whichPlayer == 2)
                        {
                            Console.WriteLine(playerList[roundWinner].name + " has highest card! " + drawnCardList[2].ToString());
                            //SecondTeam.score += 1;
                        }
                        else if (whichPlayer == 3)
                        {
                            Console.WriteLine(playerList[roundWinner].name + " has highest card! " + drawnCardList[3].ToString());
                            //SecondTeam.score += 1;
                        }

                        // Remove played cards
                        player1.playersCards.Remove(playerCardChoose);
                        player2.playersCards.Remove(computerCard1Choose);
                        player3.playersCards.Remove(computerCard2Choose);
                        player4.playersCards.Remove(computerCard3Choose);

                        if (roundWinner == 0 || roundWinner == 1)
                        {
                            FirstTeam.score += 1;
                        }
                        else
                        {
                            SecondTeam.score += 1;
                        }
                    }

                    // Pause
                    Console.ReadLine();


                    // Restart Game USE LATER after 13 rounds depleted not implemented properly yet
                    //while (!selection.Equals('Y') && !selection.Equals('N'))
                    //{
                    //    Console.SetCursorPosition(0, 48);
                    //    Console.WriteLine("Play again? Y-N");
                    //    selection = Convert.ToChar(Console.ReadLine().ToUpper());

                    //    if (selection.Equals('Y'))
                    //        quit = false;
                    //    else if (selection.Equals('N'))
                    //        quit = true;
                    //    else
                    //        Console.WriteLine("Invalid Selection! Try again.");
                    //}
                }



            }

            // Pause
            Console.ReadLine();

        }

        // Choose Card method
        public static Card ChooseCard(Player playerSelection, Player player1, Player player2, Player player3, Player player4, List<Card> listOfCards)
        {
            List<Card> selectedPlayersCards = new List<Card>();
            //String selectedPlayer = "";

            Card selectedCardSuit = new Card();
            //String selectedCardSuitString = "";


            // Select first card as selection suit for remaining players.
            if (listOfCards.Count > 0)
            {                
                // Select first card for suit seletion for remaining plays
                if (listOfCards[0].Suit.ToString() != "0")
                {
                    selectedCardSuit = listOfCards[0];
                }
            }

            // Determine who is playing to select their cards
            if (playerSelection.name == "John Doe") // Computer 1
            {
                selectedPlayersCards = playerSelection.playersCards;
                //selectedPlayer = "COMP1";
            }
            else if (playerSelection.name == "Jane Doe") // Computer 2
            {
                selectedPlayersCards = playerSelection.playersCards;
                //selectedPlayer = "COMP2";
            }
            else if (playerSelection.name == "Some Doe") // Computer 3
            {
                selectedPlayersCards = playerSelection.playersCards;
                //selectedPlayer = "COMP3";
            }
            else
            {
                selectedPlayersCards = playerSelection.playersCards;
                //selectedPlayer = "Player";
            }

            // Suit selection
            char suitSelection = ' ';
            String suitSelectionToFullname = "";

            // bool to find card in hand
            bool foundCard = false;
            //bool cardSameSuit = false;

            // Card choosen 
            Card CardChoose = new Card();

            // Must find card to select in hand
            while (!foundCard)
            {
                // Display player cards
                displayCards(player1, player2, player3, player4);

                // Display cards drawn
                DrawDrawnCards(listOfCards);

                // Set cursor under display player cards
                int xcoor = 0;
                int ycoor = 34;
                Console.SetCursorPosition(xcoor, ycoor);

                // Display Scores
                Console.WriteLine("Team 1: " + FirstTeam.score.ToString() + ", Team 2: " + SecondTeam.score.ToString());
                // Display tarneeb selection
                Console.WriteLine("The Tarneeb is: " + tarneebSuit[0] + ". Bet is: " + tarneebSuit[1] + " at Player " + tarneebSuit[2]);
                // Ask user for suit selection
                Console.WriteLine("Select " + playerSelection.name + " card SUIT: H = Hearts, S = Spades, D = Diamonds, C = Clubs");
                suitSelection = Convert.ToChar(Console.ReadLine().ToUpper());

                // Get full name of suit selection
                switch (suitSelection)
                {
                    case 'H':
                        suitSelectionToFullname = "HEART";
                        break;
                    case 'S':
                        suitSelectionToFullname = "SPADE";
                        break;
                    case 'D':
                        suitSelectionToFullname = "DIAMOND";
                        break;
                    case 'C':
                        suitSelectionToFullname = "CLUB";
                        break;
                }

                // CardNumber selection
                string valueSelection = "";
                Console.WriteLine("Select " + playerSelection.name + " card VALUE: TWO to ACE");
                valueSelection = Console.ReadLine().ToUpper();

                xcoor = 0;
                ycoor = 40;

                // Find the card user selected
                foreach (Card c in selectedPlayersCards)
                {
                    // first card is Tarneeb and drawnlist is empty
                    if (c.Suit.ToString() == suitSelectionToFullname && c.CardNumber.ToString() == valueSelection && selectedCardSuit.Suit.ToString() == "0" && c.Suit.ToString() == tarneebSuit[0])
                    {
                        CardChoose = c;
                        Console.WriteLine("You chose the Tarneeb suit!");
                        Console.ReadLine();
                        tarneebPlayed = true;
                        foundCard = true;
                    }
                    // First card with no tarneeb
                    else if (c.Suit.ToString() == suitSelectionToFullname && c.CardNumber.ToString() == valueSelection && selectedCardSuit.Suit.ToString() == "0" )
                    {
                        CardChoose = c;                        
                        Console.WriteLine("Card found!");
                        foundCard = true;
                    }
                    // Normal Case same suit
                    else if (c.Suit.ToString() == suitSelectionToFullname && c.CardNumber.ToString() == valueSelection && selectedCardSuit.Suit.ToString() == c.Suit.ToString())
                    {
                        CardChoose = c;
                        Console.WriteLine("Card found!");
                        foundCard = true;
                    }
                    // Different suit card (need two cases) 1. Out of cards 2. Tarneeb
                    else if (c.Suit.ToString() == suitSelectionToFullname && c.CardNumber.ToString() == valueSelection && selectedCardSuit.Suit.ToString() != c.Suit.ToString())
                    {
                        // Count cards in hand if there are cards of same suit
                        int numberOfCardsInSameSuit = 0;
                        foreach (Card cSearch in selectedPlayersCards)
                        {
                            if (cSearch.Suit.ToString() == selectedCardSuit.Suit.ToString())
                            {
                                numberOfCardsInSameSuit++;
                            }
                        }

                        // If no cards are same suit as first card (0) then choose whatever card
                        if (numberOfCardsInSameSuit == 0)
                        {
                            CardChoose = c;
                            Console.WriteLine("No more same suit cards found! Chose other card");
                            foundCard = true;
                        }
                        // Else a Tarneeb is choosen
                        else
                        {
                            if (c.Suit.ToString() == tarneebSuit[0])
                            {
                                CardChoose = c;
                                Console.WriteLine("You chose the Tarneeb suit!");
                                Console.ReadLine();
                                tarneebPlayed = true;
                                foundCard = true;
                            }

                        }


                    }
                }

                // Card not found and retry
                Console.SetCursorPosition(xcoor, ycoor);
                if (foundCard == false)
                {
                    Console.WriteLine("Card NOT found!");
                    Console.ReadKey();
                }

            }

            // return card
            return CardChoose;
        }

        // Choose AI (EASY and HARD) Computer Card method 
        public static Card ChooseCardComputer(Player playerSelection, Player player1, Player player2, Player player3, Player player4, List<Card> listOfCards)
        {
            List<Card> selectedPlayersCards = new List<Card>();
            //String selectedPlayer = "";

            Card selectedCardSuit = new Card();
            String selectedCardSuitString = "";

            // Card index
            int i = 0;

            // Select first card as selection suit for remaining players.
            if (listOfCards.Count > 0)
            {
                // Select first card for suit seletion for remaining plays
                if (listOfCards[0].Suit.ToString() != "0")
                {
                    selectedCardSuit = listOfCards[0];
                    selectedCardSuitString = selectedCardSuit.Suit.ToString();
                }
            }

            // Determine who is playing to select their cards
            if (playerSelection.name == "John Doe") // Computer 1
            {
                selectedPlayersCards = playerSelection.playersCards;
                //selectedPlayer = "COMP1";
            }
            else if (playerSelection.name == "Jane Doe") // Computer 2
            {
                selectedPlayersCards = playerSelection.playersCards;
                //selectedPlayer = "COMP2";
            }
            else if (playerSelection.name == "Some Doe") // Computer 3
            {
                selectedPlayersCards = playerSelection.playersCards;
                //selectedPlayer = "COMP3";
            }
            else
            {
                selectedPlayersCards = playerSelection.playersCards;
                //selectedPlayer = "Player";
            }

            // Suit selection
            char suitSelection = ' ';
            String suitSelectionToFullname = "";

           
            //bool cardSameSuit = false;

            // Card choosen 
            Card CardChoose = new Card();


            // Display player cards
            displayCards(player1, player2, player3, player4);

            // Display cards drawn
            DrawDrawnCards(listOfCards);



            // Set cursor under display player cards
            int xcoor = 0;
            int ycoor = 34;
            Console.SetCursorPosition(xcoor, ycoor);

            // Display Scores
            Console.WriteLine("Team 1: " + FirstTeam.score.ToString() + ", Team 2: " + SecondTeam.score.ToString());
            // Display tarneeb selection
            Console.WriteLine("The Tarneeb is: " + tarneebSuit[0] + ". Bet is: " + tarneebSuit[1] + " at Player " + tarneebSuit[2]);

            // Easy AI Artificial Intelligence
            if (difficulty == "easy")
            {
                // Select Trump card anywhere
                int weakCardOfTarneebSuit = selectedPlayersCards.FindLastIndex(c => c.Suit.ToString() == tarneebSuit[0]);

                if (weakCardOfTarneebSuit == -1)
                {
                    // No cards drawn yet
                    if (listOfCards.Count == 0)
                    {
                        var rand = new Random();
                        int randomCard = rand.Next(selectedPlayersCards.Count);
                        // Return something random
                        return selectedPlayersCards[randomCard];
                    }

                    if (selectedCardSuitString != "")
                    { 
                        // Check if cards of same suit left
                        int numberOfCardsInSameSuit = 0;
                        foreach (Card cSearch in selectedPlayersCards)
                        {
                            if (cSearch.Suit.ToString() == selectedCardSuit.Suit.ToString())
                            {
                                numberOfCardsInSameSuit++;
                            }
                        }
                        if (numberOfCardsInSameSuit != 0)
                        {
                            int weakCardOfSelectedCardSuit = selectedPlayersCards.FindLastIndex(c => c.Suit.ToString() == selectedCardSuit.Suit.ToString());
                            return selectedPlayersCards[weakCardOfSelectedCardSuit];
                        }
                        else
                        {
                            var rand = new Random();
                            int randomCard = rand.Next(selectedPlayersCards.Count);
                            // Return something random
                            return selectedPlayersCards[randomCard];
                        }

                    }
                    
                }
                i = weakCardOfTarneebSuit;
                return selectedPlayersCards[weakCardOfTarneebSuit];
            }

            // HARD AI Artifical Intelligence
            else if (difficulty == "hard")
            {
                // Select Trump card anywhere
                int strongCardOfTarneebSuit = selectedPlayersCards.FindIndex(c => c.Suit.ToString() == tarneebSuit[0]);

                if (strongCardOfTarneebSuit == -1)
                {
                    // No cards drawn yet
                    if (listOfCards.Count == 0)
                    {
                        var rand = new Random();
                        int randomCard = rand.Next(selectedPlayersCards.Count);
                        // Return something random
                        return selectedPlayersCards[randomCard];
                    }


                    if (selectedCardSuitString != "")
                    {
                        // Check if cards of same suit left
                        int numberOfCardsInSameSuit = 0;
                        foreach (Card cSearch in selectedPlayersCards)
                        {
                            if (cSearch.Suit.ToString() == selectedCardSuit.Suit.ToString())
                            {
                                numberOfCardsInSameSuit++;
                            }
                        }
                        if (numberOfCardsInSameSuit != 0)
                        {
                            int strongCardOfSelectedCardSuit = selectedPlayersCards.FindIndex(c => c.Suit.ToString() == selectedCardSuit.Suit.ToString());
                            return selectedPlayersCards[strongCardOfSelectedCardSuit];
                        }
                        else
                        {
                            var rand = new Random();
                            int randomCard = rand.Next(selectedPlayersCards.Count);
                            // Return something random
                            return selectedPlayersCards[randomCard];
                        }

                    }
                    

                }

                i = strongCardOfTarneebSuit;

                return selectedPlayersCards[strongCardOfTarneebSuit];
            }

            
            return selectedPlayersCards[i];
        }

        // Find all the Tarneeb cards and return 4 digit code
        static int FindTarneebsInList(List<Card> cards)
        {
            int comboSuit = -1;
            List<int> comboSuitList = new List<int> { };
            foreach (Card c in cards)
            {
                if (c.Suit.ToString() == tarneebSuit[0])
                {
                    comboSuitList.Add(1);
                }
                else
                {
                    comboSuitList.Add(0);
                }
            }

            String result = String.Join("", comboSuitList);
            comboSuit = Convert.ToInt32(result);
            return comboSuit;
        }

        

        // Return 4 digit code of cards of same suit in drawn list
        static int ReturnSameSuitAsFirst(List<Card> cards)
        {
            if (cards[0].Suit == cards[1].Suit && cards[0].Suit == cards[2].Suit && cards[0].Suit == cards[3].Suit)
            {
                return 1111;
            }

            if (cards[0].Suit != cards[1].Suit && cards[0].Suit != cards[2].Suit && cards[0].Suit != cards[3].Suit)
            {
                return 1000;
            }

            if (cards[0].Suit == cards[1].Suit && cards[0].Suit != cards[2].Suit && cards[0].Suit != cards[3].Suit)
            {
                return 1100;
            }

            if (cards[0].Suit == cards[1].Suit && cards[0].Suit != cards[2].Suit && cards[0].Suit == cards[3].Suit)
            {
                return 1101;
            }

            if (cards[0].Suit == cards[1].Suit && cards[0].Suit == cards[2].Suit && cards[0].Suit != cards[3].Suit)
            {
                return 1110;
            }
            if (cards[0].Suit != cards[1].Suit && cards[0].Suit != cards[2].Suit && cards[0].Suit == cards[3].Suit)
            {
                return 1001;
            }

            if (cards[0].Suit != cards[1].Suit && cards[0].Suit == cards[2].Suit && cards[0].Suit == cards[3].Suit)
            {
                return 1011;
            }

            if (cards[0].Suit != cards[1].Suit && cards[0].Suit == cards[2].Suit && cards[0].Suit != cards[3].Suit)
            {
                return 1010;
            }

            return 0000;
        }

        // Find highest value with Tarneebs in drawn hand
        static int HighestValueWithTarneeb(int combo, List<Card> cards)
        {
            if (combo == 1111)
            {
                if ((int)cards[0].CardNumber > (int)cards[1].CardNumber && (int)cards[0].CardNumber > (int)cards[2].CardNumber && (int)cards[0].CardNumber > (int)cards[3].CardNumber)
                {
                    return 0;
                }
                else if ((int)cards[1].CardNumber > (int)cards[0].CardNumber && (int)cards[1].CardNumber > (int)cards[2].CardNumber && (int)cards[1].CardNumber > (int)cards[3].CardNumber)
                {
                    return 1;
                }
                else if ((int)cards[2].CardNumber > (int)cards[0].CardNumber && (int)cards[2].CardNumber > (int)cards[1].CardNumber && (int)cards[2].CardNumber > (int)cards[3].CardNumber)
                {
                    return 2;
                }
                else if ((int)cards[3].CardNumber > (int)cards[0].CardNumber && (int)cards[3].CardNumber > (int)cards[1].CardNumber && (int)cards[3].CardNumber > (int)cards[2].CardNumber)
                {
                    return 3;
                }
                return -1;
            }

            if (combo == 1000)
            {
                return 0;
            }
            if (combo == 1100)
            {
                if ((int)cards[0].CardNumber > (int)cards[1].CardNumber)
                {
                    return 0;
                }
                return 1;
            }
            if (combo == 1101)
            {
                if ((int)cards[0].CardNumber > (int)cards[1].CardNumber && (int)cards[0].CardNumber > (int)cards[3].CardNumber)
                {
                    return 0;
                }
                else if ((int)cards[1].CardNumber > (int)cards[0].CardNumber && (int)cards[1].CardNumber > (int)cards[3].CardNumber)
                {
                    return 1;
                }

                else if ((int)cards[3].CardNumber > (int)cards[0].CardNumber && (int)cards[3].CardNumber > (int)cards[1].CardNumber)
                {
                    return 3;
                }
                return -1;
            }

            if (combo == 1110)
            {
                if ((int)cards[0].CardNumber > (int)cards[1].CardNumber && (int)cards[0].CardNumber > (int)cards[2].CardNumber)
                {
                    return 0;
                }
                else if ((int)cards[1].CardNumber > (int)cards[0].CardNumber && (int)cards[1].CardNumber > (int)cards[2].CardNumber)
                {
                    return 1;
                }
                else if ((int)cards[2].CardNumber > (int)cards[0].CardNumber && (int)cards[2].CardNumber > (int)cards[1].CardNumber)
                {
                    return 2;
                }
                return -1;
            }
            if (combo == 1001)
            {
                if ((int)cards[0].CardNumber > (int)cards[3].CardNumber)
                {
                    return 0;
                }
                return 3;
            }
            if (combo == 1011)
            {
                if ((int)cards[0].CardNumber > (int)cards[2].CardNumber && (int)cards[0].CardNumber > (int)cards[3].CardNumber)
                {
                    return 0;
                }
                else if ((int)cards[2].CardNumber > (int)cards[0].CardNumber && (int)cards[2].CardNumber > (int)cards[3].CardNumber)
                {
                    return 2;
                }
                else if ((int)cards[3].CardNumber > (int)cards[0].CardNumber && (int)cards[3].CardNumber > (int)cards[2].CardNumber)
                {
                    return 3;
                }
                return -1;
            }
            if (combo == 1010)
            {
                if ((int)cards[0].CardNumber > (int)cards[2].CardNumber)
                {
                    return 0;
                }
                return 2;
            }
            // NEW
            if (combo == 0111)
            {
                if ((int)cards[1].CardNumber > (int)cards[2].CardNumber && (int)cards[1].CardNumber > (int)cards[3].CardNumber)
                {
                    return 1;
                }
                else if ((int)cards[2].CardNumber > (int)cards[1].CardNumber && (int)cards[2].CardNumber > (int)cards[3].CardNumber)
                {
                    return 2;
                }
                else if ((int)cards[3].CardNumber > (int)cards[1].CardNumber && (int)cards[3].CardNumber > (int)cards[2].CardNumber)
                {
                    return 3;
                }

                return -1;
            }

            if (combo == 0110)
            {
                if ((int)cards[1].CardNumber > (int)cards[2].CardNumber)
                {
                    return 1;
                }
                else if ((int)cards[2].CardNumber > (int)cards[1].CardNumber)
                {
                    return 2;
                }

                return -1;
            }

            if (combo == 0101)
            {
                if ((int)cards[1].CardNumber > (int)cards[3].CardNumber)
                {
                    return 1;
                }
                else if ((int)cards[3].CardNumber > (int)cards[1].CardNumber)
                {
                    return 3;
                }

                return -1;
            }

            if (combo == 0100)
            {
                return 1;
            }

            if (combo == 0011)
            {
                if ((int)cards[2].CardNumber > (int)cards[3].CardNumber)
                {
                    return 2;
                }
                else if ((int)cards[3].CardNumber > (int)cards[2].CardNumber)
                {
                    return 3;
                }

                return -1;
            }

            if (combo == 0010)
            {
                return 2;
            }

            if (combo == 0001)
            {
                return 3;
            }


            return -1;
        }

        // Dont need can use above but with no Tarneeb. Find highest value in hand with first card determining suit
        static int HighestValueWithDifferentSuits(int combo, List<Card> cards)
        {
            if (combo == 1111)
            {
                if ((int)cards[0].CardNumber > (int)cards[1].CardNumber && (int)cards[0].CardNumber > (int)cards[2].CardNumber && (int)cards[0].CardNumber > (int)cards[3].CardNumber)
                {
                    return 0;
                }
                else if ((int)cards[1].CardNumber > (int)cards[0].CardNumber && (int)cards[1].CardNumber > (int)cards[2].CardNumber && (int)cards[1].CardNumber > (int)cards[3].CardNumber)
                {
                    return 1;
                }
                else if ((int)cards[2].CardNumber > (int)cards[0].CardNumber && (int)cards[2].CardNumber > (int)cards[1].CardNumber && (int)cards[2].CardNumber > (int)cards[3].CardNumber)
                {
                    return 2;
                }
                else if ((int)cards[3].CardNumber > (int)cards[0].CardNumber && (int)cards[3].CardNumber > (int)cards[1].CardNumber && (int)cards[3].CardNumber > (int)cards[2].CardNumber)
                {
                    return 3;
                }
                return -1;
            }
 
            if (combo == 1000)
            {
                return 0;
            }
            if (combo == 1100)
            {
                if ((int)cards[0].CardNumber > (int)cards[1].CardNumber)
                {
                    return 0;
                }
                return 1;
            }
            if (combo == 1101)
            {
                if ((int)cards[0].CardNumber > (int)cards[1].CardNumber && (int)cards[0].CardNumber > (int)cards[3].CardNumber)
                {
                    return 0;
                }
                else if ((int)cards[1].CardNumber > (int)cards[0].CardNumber && (int)cards[1].CardNumber > (int)cards[3].CardNumber)
                {
                    return 1;
                }
                
                else if ((int)cards[3].CardNumber > (int)cards[0].CardNumber && (int)cards[3].CardNumber > (int)cards[1].CardNumber)
                {
                    return 3;
                }
                return -1;
            }

            if (combo == 1110)
            {
                if ((int)cards[0].CardNumber > (int)cards[1].CardNumber && (int)cards[0].CardNumber > (int)cards[2].CardNumber)
                {
                    return 0;
                }
                else if ((int)cards[1].CardNumber > (int)cards[0].CardNumber && (int)cards[1].CardNumber > (int)cards[2].CardNumber)
                {
                    return 1;
                }
                else if ((int)cards[2].CardNumber > (int)cards[0].CardNumber && (int)cards[2].CardNumber > (int)cards[1].CardNumber)
                {
                    return 2;
                }
                return -1;
            }
            if (combo == 1001)
            {
                if ((int)cards[0].CardNumber > (int)cards[3].CardNumber)
                {
                    return 0;
                }
                return 3;
            }
            if (combo == 1011)
            {
                if ((int)cards[0].CardNumber > (int)cards[2].CardNumber && (int)cards[0].CardNumber > (int)cards[3].CardNumber)
                {
                    return 0;
                }
                else if ((int)cards[2].CardNumber > (int)cards[0].CardNumber && (int)cards[2].CardNumber > (int)cards[3].CardNumber)
                {
                    return 2;
                }
                else if ((int)cards[3].CardNumber > (int)cards[0].CardNumber && (int)cards[3].CardNumber > (int)cards[2].CardNumber)
                {
                    return 3;
                }
                return -1;
            }
            if (combo == 1010)
            {
                if ((int)cards[0].CardNumber > (int)cards[2].CardNumber)
                {
                    return 0;
                }
                return 2;
            }
            return -1;
        }

        // Draw the selected cards on bottom screen each time card is drawn
        static void DrawDrawnCards(List<Card> listOfCards)
        {

            int xcoor = 0;
            int ycoor = 41;

            foreach (Card c in listOfCards)
            {
                DrawCards.DrawCardOutline(xcoor, ycoor);
                DrawCards.DrawCardSuitValue(c, xcoor, ycoor);
                xcoor += 1;
                ycoor = 41;
            }

        }

        // Round Bet (highest, suit and player)
        public static List<String> RoundBetRandom()
        {

            var rand = new Random();
            int playerNumberRandom = rand.Next(3);


            //int numberSelected = 7;

            int playerNumberSelected = 0;
            List<int> playerNumberSelections = new List<int>();

            char suitSelection = 'A';
            String suitSelectionToFullname = "";
            bool firstNumberOK = false;


            Console.WriteLine("Player " + playerNumberRandom.ToString() +  " select number from 7 to 13: ");
            playerNumberSelected = Convert.ToInt32(Console.ReadLine());


            if (playerNumberSelected > 6 && playerNumberSelected < 14)
            {
                playerNumberSelections.Add(playerNumberSelected);
            }
            else
            {
                while (!firstNumberOK)
                {
                    Console.WriteLine("Player " + playerNumberRandom.ToString() + " select number from 7 to 13: ");
                    playerNumberSelected = Convert.ToInt32(Console.ReadLine());
                    if (playerNumberSelected > 6 && playerNumberSelected < 14)
                    {
                        playerNumberSelections.Add(playerNumberSelected);
                        firstNumberOK = true;
                    }
                }
            }


            String result = string.Join(",", playerNumberSelections);
            for (int i = 1; i < 4; i++)
            {
                bool afterNumberOK = false;
                //Console.WriteLine(playerNumberSelections.ToString());

                result = string.Join(",", playerNumberSelections);
                Console.WriteLine("Current number list: " + result);

                int pc = playerNumberRandom + i;
                if (pc > 3)
                {
                    pc -= 4;
                }
                Console.WriteLine("Player " + (pc).ToString() + " select number from 7 to 13: ");
                playerNumberSelected = Convert.ToInt32(Console.ReadLine());

                while (!afterNumberOK)
                {
                    if (playerNumberSelected > 6 && playerNumberSelected < 14 && playerNumberSelections.IndexOf(playerNumberSelected) == -1)
                    {
                        playerNumberSelections.Add(playerNumberSelected);
                        afterNumberOK = true;
                    }
                    else
                    {
                        Console.WriteLine("Number already in list or not in range.");
                        Console.WriteLine("Player " + pc.ToString() + " select number from 7 to 13: ");
                        playerNumberSelected = Convert.ToInt32(Console.ReadLine());
                    }
                }

            }

            result = string.Join(",", playerNumberSelections);
            Console.WriteLine("Current number list: " + result);
            int maxIndex = playerNumberSelections.IndexOf(playerNumberSelections.Max());
            if (maxIndex > 3)
            {
                maxIndex = maxIndex - 4;
            }
            Console.WriteLine("The max index is: " + playerNumberSelections.Max() + " at Player " + maxIndex.ToString());

            Console.WriteLine("Player " + maxIndex.ToString() + ", Select card SUIT: H = Hearts, S = Spades, D = Diamonds, C = Clubs");
            suitSelection = Convert.ToChar(Console.ReadLine().ToUpper());

            switch (suitSelection)
            {
                case 'H':
                    suitSelectionToFullname = "HEART";
                    break;
                case 'S':
                    suitSelectionToFullname = "SPADE";
                    break;
                case 'D':
                    suitSelectionToFullname = "DIAMOND";
                    break;
                case 'C':
                    suitSelectionToFullname = "CLUB";
                    break;
            }

            return new List<string> { suitSelectionToFullname, playerNumberSelections.Max().ToString(), maxIndex.ToString() };
        }


        // Round Bet (highest, suit and player)
        public static List<String> RoundBet()
        {
            //int numberSelected = 7;

            int playerNumberSelected = 0;
            List<int> playerNumberSelections = new List<int>();
            
            char suitSelection = 'A';
            String suitSelectionToFullname = "";
            bool firstNumberOK = false;


            Console.WriteLine("Player 0 select number from 7 to 13: ");
            playerNumberSelected = Convert.ToInt32(Console.ReadLine());


            if (playerNumberSelected > 6 && playerNumberSelected < 14)
            {
                playerNumberSelections.Add(playerNumberSelected);
            }
            else
            {
                while (!firstNumberOK)
                {
                    Console.WriteLine("Player 0 select number from 7 to 13: ");
                    playerNumberSelected = Convert.ToInt32(Console.ReadLine());
                    if (playerNumberSelected > 6 && playerNumberSelected < 14)
                    {
                        playerNumberSelections.Add(playerNumberSelected);
                        firstNumberOK = true;
                    }
                }
            }


            String result = string.Join(",", playerNumberSelections);
            for (int i = 1; i < 4; i++)
            {
                bool afterNumberOK = false;
                //Console.WriteLine(playerNumberSelections.ToString());

                result = string.Join(",", playerNumberSelections);
                Console.WriteLine("Current number list: " + result);

                Console.WriteLine("Player " + i.ToString() + " select number from 7 to 13: ");
                playerNumberSelected = Convert.ToInt32(Console.ReadLine());

                while (!afterNumberOK)
                {
                    if (playerNumberSelected > 6 && playerNumberSelected < 14 && playerNumberSelections.IndexOf(playerNumberSelected) == -1)
                    {
                        playerNumberSelections.Add(playerNumberSelected);
                        afterNumberOK = true;
                    }
                    else
                    {
                        Console.WriteLine("Number already in list or not in range.");
                        Console.WriteLine("Player " + i.ToString() + " select number from 7 to 13: ");
                        playerNumberSelected = Convert.ToInt32(Console.ReadLine());
                    }
                }
                
            }

            result = string.Join(",", playerNumberSelections);
            Console.WriteLine("Current number list: " + result);
            int maxIndex = playerNumberSelections.IndexOf(playerNumberSelections.Max());
            Console.WriteLine("The max index is: " + playerNumberSelections.Max() + " at Player " + maxIndex.ToString());

            Console.WriteLine("Player " + maxIndex.ToString() + ", Select card SUIT: H = Hearts, S = Spades, D = Diamonds, C = Clubs");
            suitSelection = Convert.ToChar(Console.ReadLine().ToUpper());

            switch (suitSelection)
            {
                case 'H':
                    suitSelectionToFullname = "HEART";
                    break;
                case 'S':
                    suitSelectionToFullname = "SPADE";
                    break;
                case 'D':
                    suitSelectionToFullname = "DIAMOND";
                    break;
                case 'C':
                    suitSelectionToFullname = "CLUB";
                    break;
            }

            return new List<string> { suitSelectionToFullname, playerNumberSelections.Max().ToString() , maxIndex.ToString() };
        }

        // Display Cards of players
        public static void displayCards(Player player1, Player player2, Player player3, Player player4)
        {
            Console.Clear();
            int x = 0; // x position of the cursor. We move left to right
            int y = 1; // y position of the cursor, we move up to down

            // Display player hand
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(player1.name + " hand:");
            for (int i = 0; i < player1.playersCards.Count; i++)
            {
                DrawCards.DrawCardOutline(x, y);
                DrawCards.DrawCardSuitValue(player1.playersCards[i], x, y);
                x++; // move to the right
            }
            y = 9; // move the row of computer cards below the player's cards
            x = 0; // reset x position

            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(player2.name + " hand:");
            y = 10; // move the row of computer cards below the player's cards
            x = 0; // reset x position

            for (int i = 0; i < player2.playersCards.Count; i++)
            {
                DrawCards.DrawCardOutline(x, y);
                DrawCards.DrawCardSuitValue(player2.playersCards[i], x, y);
                x++; // move to the right
            }


            y = 18; // move the row of computer cards below the player's cards
            x = 0; // reset x position

            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(player3.name + " hand:");
            y = 19; // move the row of computer cards below the player's cards
            x = 0; // reset x position

            for (int i = 0; i < player3.playersCards.Count; i++)
            {
                DrawCards.DrawCardOutline(x, y);
                DrawCards.DrawCardSuitValue(player3.playersCards[i], x, y);
                x++; // move to the right
            }

            y = 27; // move the row of computer cards below the player's cards
            x = 0; // reset x position

            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(player4.name + " hand:");
            y = 28; // move the row of computer cards below the player's cards
            x = 0; // reset x position


            for (int i = 0; i < player4.playersCards.Count; i++)
            {
                DrawCards.DrawCardOutline(x, y);
                DrawCards.DrawCardSuitValue(player4.playersCards[i], x, y);
                x++; // move to the right
            }

        }
    }
}
