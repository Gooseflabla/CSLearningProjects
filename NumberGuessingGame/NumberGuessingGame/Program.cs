using System;
using System.Diagnostics;

namespace NumberGuessingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Number Guessing Game!");


            bool playAgain = true;

            while (playAgain)
            {
                Random unknown = new Random();

                int numberToGuess = unknown.Next(1, 101);
                int userGuess = 0;
                int attempts = 0;

                Console.WriteLine("I'm thinking of a number between 1 and 100.");
                Console.WriteLine("Can you guess what it is?");
                Console.WriteLine("Enter the number you'd like to guess.");

                while (userGuess != numberToGuess)
                {
                    string input = Console.ReadLine();

                    if (int.TryParse(input, out userGuess))
                    {
                        attempts++;
                        if (userGuess > numberToGuess)
                        {
                            Console.WriteLine("Too high! Try again.");
                        }
                        else if (userGuess < numberToGuess)
                        {
                            Console.WriteLine("Too Low! Try Again.");
                        }
                        else
                        {
                            Console.WriteLine($"Congrats! You guessed it right in {attempts} attempts!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Input invalid! Please enter a number");
                    }
                }
                Console.WriteLine("Would you like to play again? (Y/N)");
                string replay = Console.ReadLine().ToLower();

                if (replay != "y")
                {
                    Console.WriteLine("Thanks for playing");
                    playAgain = false;
                }
            }
        }
    }
}
    
