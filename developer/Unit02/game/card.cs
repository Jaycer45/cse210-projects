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

        /// Creates a value for the card so we can use that to keep score
        public void getNewCard()
        {
            Random randomGenerator = new Random();
            cardValue = randomGenerator.Next(1, 14);
        }

    }
}