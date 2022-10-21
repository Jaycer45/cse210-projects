using System;
using System.Collections.Generic;

namespace Unit03
{
    public class Director
    {
        private bool isPlaying = true;
        private string chosenWord;

        private TerminalService terminalService = new TerminalService();
        public HiddenWord hiddenWord = new HiddenWord();
        private Jumper jumper = new Jumper();
        public int tries = 0;
        public int numberOfGuesses = 0;

        private bool checkInput;

        List<char> guessedLetters = new List<char>();

        public string currentGuess = "test";


        /// Constructs a new instance of Director.
        public Director()
        {
        }
        public void StartGame()
        {
            StartUp();
            while (isPlaying)
            {
                GetInputs();
                DoUpdates();
                DoOutputs();
            }
        }

        private void StartUp()
        {
            Console.WriteLine("\nHint: Type of Fruit");
            chosenWord = hiddenWord.wordBank();
            hiddenWord.listWord(chosenWord);
            hiddenWord.createHiddenWord();
            hiddenWord.printGuess();
        }
        private void GetInputs()
        {
            Console.WriteLine("\n");
            jumper.printJumper(tries);
            checkInput = true;
            while (checkInput){
                currentGuess = terminalService.ReadGuess("\nGuess a letter [a-z]: ");
                checkInput = jumper.checkInput(guessedLetters, currentGuess);
            }
            guessedLetters.Add(currentGuess[0]);
            
        }
        private void DoUpdates()
        {
            numberOfGuesses = guessedLetters.Count;
            int oldTries = hiddenWord.compare(guessedLetters, numberOfGuesses);
            tries = tries + oldTries;
            isPlaying = jumper.checkJumper(hiddenWord.guess, tries);
        }
        
        private void DoOutputs()
        {
            Console.WriteLine("\n");
            if (isPlaying){
                hiddenWord.printGuess();
            }
            else {
                jumper.printJumper(tries);
                hiddenWord.printAnswer();
                Console.WriteLine("\n");
                Console.WriteLine("Congratulations! You got the word.");
                Console.WriteLine("\n");
            }
  
        }
    }
}