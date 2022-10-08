using System;


namespace Unit02.HiLo
{
    
    public class Card
    {
        public int cardValue = 0;
        

        /// Makes the Card class public
        public Card()
        {
        }

        /// Generates a new random value for a card value.
        public void getNewCard()
        {
            Random randomGenerator = new Random();
            cardValue = randomGenerator.Next(1, 14);
        }

    }
}