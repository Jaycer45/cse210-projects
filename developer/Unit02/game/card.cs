using System;


namespace Unit02.Game
{
    /// <summary>
    /// A small cube with a different number of spots on each of its six sides.
    /// 
    /// The responsibility of Die is to keep track of its currently rolled value and the points its
    /// worth.
    /// </summary> 
    public class Card
    {
        public int card_value = 0;

        /// <summary>
        /// Constructs a new instance of Die.
        /// </summary>
        public Card()
        {
        }

        /// <summary>
        /// Generates a new random value and calculates the points for the die.
        /// </summary>
        public void Draw()
        {
            Random random = new Random();
            card_value = random.Next(1, 14);
            if (c < card_value)
            {
                _points = 100;
            }
            else if (user_guess > card_value)
            {
                _points = -75;
            }
            else
            {
                _points = 0;
            }
        }

    }
}