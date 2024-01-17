using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_03
{
    public class Game
    {
        public void GuessingGame()
        {
            string[] wordDatabase = { "giraffe", "tiger", "lion", "bear", "zebra", "elephant","wolf","panther"};
            int totalIncorrectGuess = 5;
            bool gameContinue = true;

            Console.WriteLine("Welcome to the Word Guessing Game!");

            while (gameContinue)
            {
                string choosenWord = wordDatabase[new Random().Next(wordDatabase.Length)];
                string displayWord = new string('_', choosenWord.Length);
                int incorrectGuess = 0;
                string guessedWords = "";

                Console.WriteLine("Start Guessing animal name ........");

                while (incorrectGuess < totalIncorrectGuess && displayWord.Contains('_'))
                {
                    // get user input
                    char guessedLetter = GetUserInput();

                    guessedWords += guessedLetter + " ";


                    // Check if the guessed letter is in the word
                    if (choosenWord.Contains(guessedLetter))
                    {
                        // updating display string with correctly guessed letter
                        for (int i = 0; i < choosenWord.Length; i++)
                        {
                            if (choosenWord[i] == guessedLetter)
                            {
                                // display word with the guessed letters
                                string prefix = displayWord.Substring(0, i);
                                string suffix = displayWord.Substring(i + 1);
                                displayWord = prefix + guessedLetter + suffix;
                            }
                        }

                        // checking if the whole word is guessed or not
                        if(!displayWord.Contains('_'))
                        {
                            Console.WriteLine("Word : {0}", displayWord);
                            Console.WriteLine("Guessed Letters : {0}", guessedWords);
                            Console.WriteLine("Incorrect Guesses : {0}", incorrectGuess);
                            Console.WriteLine("Congratulations! You guessed the word.");
                            break;
                        }
                    }
                    else
                    {
                        // Incorrect guesses
                        incorrectGuess++;
                    }

                    Console.WriteLine("Word : {0}", displayWord);
                    Console.WriteLine("Guessed Letters : {0}", guessedWords);
                    Console.WriteLine("Incorrect Guesses : {0}", incorrectGuess);
                    Console.WriteLine();
                }

                // when game is over
                if (incorrectGuess == totalIncorrectGuess)
                {
                    Console.WriteLine("Game Over! You reach the maximum incorrect guesses.");
                    Console.WriteLine("The correct word was : {0}", choosenWord);
                    gameContinue = false; // stop the game
                }

                // Reset the game for a new round
                gameContinue = false;
            }
        }

        public char GetUserInput()
        {
            char guessedLetter = ' ';
            while(true)
            {
                try
                {
                    Console.Write("Enter a letter: ");
                    string input = Console.ReadLine().ToLower();

                    if (input.Length == 1 && Char.IsLetter(input[0]))
                    {
                        guessedLetter = input[0];
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid letter."); 
                    }
                }
                catch
                {
                    Console.WriteLine("Invalid input.");
                }
            }
            return guessedLetter;
        }
    }
}
