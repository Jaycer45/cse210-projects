using System;
using System.Collections.Generic;


namespace Unit02.Game
{
    /// <summary>
    /// A person who directs the game. 
    ///
    /// The responsibility of a Director is to control the sequence of play.
    /// </summary>
    public class Director
    {
        List<Card> cards = new List<Card>();
        int current_card;
        bool _isPlaying = true;
        int _score = 0;
        int correct_guess = 100;
        int incorrect_guess = 75;
        int next_card;
        int start_score = 300;

        /// <summary>
        /// Constructs a new instance of Director.
        /// </summary>
        public Director()
        {
            for (int i = 0; i < 1; i++){
                 Card card = new Card();
                cards.Add(card);
            }
        }

        /// <summary>
        /// Starts the game by running the main game loop.
        /// </summary>
        public void StartGame()
        {
            while (_isPlaying)
            {
                GetInputs();
                DoUpdates();
                DoOutputs();
            }
        }

        /// <summary>
        /// Asks the user if they want to roll.
        /// </summary>
        public void GetInputs()
        {
            Console.Write($"A Card is: {Card}" );
            Console.Write("Higher or Lower? [h/l] " );
            string user_guess = Console.ReadLine();
            _isPlaying = (rollDice == "y");
        }

        /// <summary>
        /// Updates the player's score.
        /// </summary>
        public void DoUpdates()
        {
            if (!_isPlaying)
            {
                return;
            }

            _score = 0;
            {
                card.Draw();
                _score += card._points;
            }
            _totalScore += _score;
        }

        /// <summary>
        /// Displays the dice and the score. Also asks the player if they want to roll again. 
        /// </summary>
        public void DoOutputs()
        {
            if (!_isPlaying)
            {
                return;
            }

            string values = "";
            foreach (Die die in _dice)
            {
                values += $"{die._value} ";
            }

            Console.WriteLine($"You rolled: {values}");
            Console.WriteLine($"Your score is: {_totalScore}\n");
            _isPlaying = (_score > 0);
        }
    }
}