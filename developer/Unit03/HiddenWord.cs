using System;
using System.Collections.Generic;
using System.IO;

namespace Unit03
{
    public class HiddenWord{
        public string hiddenword;
        List<char> answer = new List<char>();
        public List<char> guess = new List<char>();

        public HiddenWord(){
            
        }

        public string wordBank(){
            List<string> lines = new List<string>(File.ReadAllLines("words.txt"));
            Random rand = new Random();
            int randomIndex = rand.Next(0, lines.Count);
            string chosenWord = lines[randomIndex];
            return chosenWord;
        }

        public void listWord(string endWord){
            answer.AddRange(endWord.ToLower());
        }

        public void createHiddenWord(){
            foreach (int i in answer){
                guess.Add('_');
            }
            }

        public void printGuess(){
            Console.WriteLine(string.Format("{0}", string.Join(" ", guess)));       
        }

        public int compare(List<char> listPreviousGuesses, int numberOfGuesses){
            for(int i=0;i<answer.Count;i++){
                if (listPreviousGuesses.Contains(answer[i])){
                    guess[i] = answer[i];}}
            if (answer.Contains(listPreviousGuesses[numberOfGuesses-1])){
                return 0;}
            else {
                return 1;}

        }
        public void printAnswer(){
            Console.WriteLine(string.Format("{0}", string.Join(" ", answer)));
        }

    };
}