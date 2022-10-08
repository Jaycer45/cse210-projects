using System;
using System.Collections.Generic;


namespace Unit02.HiLo
{
    /// The Director will help set the pace of the game
    public class Director
    {
        List<Card> cards = new List<Card>();
        int start_points = 300;
        bool is_playing = true;
        int is_right = 100;
        int is_wrong = 75;

        int current_card;
        int next_card;

        /// You can only draw 1 card at a time
        public Director()
        {
            for (int i = 0; i < 1; i++)
            {
                Card card = new Card();
                cards.Add(card);
            }
        }

        /// The game starts by issuing a card
        public void StartGame()
        {
            foreach (Card card in cards)
            {
                card.getNewCard();
                current_card = card.cardValue;
            }

            while (is_playing)
            {
                gameMain();
                gameResume();
            }
        }
        public void gameMain()
        {
            Console.WriteLine($"The card is {current_card}");
            if (!is_playing)
            {
                return;
            }
            foreach (Card card in cards)
            {
                card.getNewCard();
                next_card = card.cardValue;
            }
            
            Console.Write("Higher or Lower? [h/l]: ");
            string cardGuess = Console.ReadLine();
            Console.WriteLine($"The next card was:{next_card}");

            
            if (cardGuess == "h" && current_card < next_card)
            {
                start_points += is_right;
            }

            else if (cardGuess == "h" && current_card > next_card)
            {
                start_points -= is_wrong;
                if (start_points < 0)
                {
                    start_points = 0;
                }
            }

            if (cardGuess == "l" && current_card > next_card)
            {
                start_points += is_right;
            }

            else if (cardGuess == "l" && current_card < next_card)
            {
                start_points -= is_wrong;
                if (start_points < 0)
                {
                    start_points = 0;
                }
            }


        }

        public void gameResume()
        {
            Console.WriteLine($"Your score is {start_points}");
            if (start_points == 0)
            {
                is_playing = false;
                Console.WriteLine("Game Over");
            }

            if (!is_playing)
            {
                return;
            }

            current_card = next_card;
            Console.Write("Play again? [y/n]: ");
            string keepPlaying = Console.ReadLine();
            is_playing = (keepPlaying == "y");
        }
    }
}