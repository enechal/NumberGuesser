using System;

namespace NumberGuessingGame
{
    class Program
    {
        static int secretNumber;
        static int attempts;

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Number Guessing Game!");
            Console.WriteLine("-----------------------------------");

            PrintGameInstructions();
            InitializeGame();
            PlayGame();

            Console.WriteLine("Thank you for playing the Number Guessing Game!");
            Console.ReadLine();
        }

        static void InitializeGame()
        {
            Random random = new Random();
            secretNumber = random.Next(1, 101);
            attempts = 0;
        }

        static void PlayGame()
        {
            bool guessedCorrectly = false;

            while (!guessedCorrectly)
            {
                int guess = GetPlayerGuess();
                attempts++;

                if (!ValidateGuess(guess))
                {
                    // If the guess is invalid, continue to the next iteration of the loop
                    continue;
                }

                if (guess < secretNumber)
                {
                    PrintMessage("Too low! Try again.");
                }
                else if (guess > secretNumber)
                {
                    PrintMessage("Too high! Try again.");
                }
                else
                {
                    guessedCorrectly = true;
                    PrintMessage("Congratulations! You guessed the secret number " + secretNumber + " correctly!");
                    PrintMessage("Total attempts: " + attempts);
                }
            }

            HandleGameOver();
        }

        static int GetPlayerGuess()
        {
            PrintMessage("Enter your guess (1-100): ");
            int guess = Convert.ToInt32(Console.ReadLine());
            return guess;
        }

        static void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }

        static void PrintErrorMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error: " + message);
            Console.ResetColor();
        }

        static void PrintGameHeader()
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine("        Number Guessing       ");
            Console.WriteLine("------------------------------");
        }

        static void PrintGameStats()
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine("         Game Statistics      ");
            Console.WriteLine("------------------------------");
            Console.WriteLine("Secret Number: " + secretNumber);
            Console.WriteLine("Attempts: " + attempts);
            Console.WriteLine("------------------------------");
        }

        static bool ValidateGuess(int guess)
        {
            if (guess < 1 || guess > 100)
            {
                PrintErrorMessage("Invalid guess. Please enter a number between 1 and 100.");
                return false;
            }
            return true;
        }

        static bool PlayAgain()
        {
            PrintMessage("Do you want to play again? (yes/no)");
            string input = Console.ReadLine().ToLower();
            return input == "yes";
        }

        static void HandleGameOver()
        {
            PrintGameStats();
            if (PlayAgain())
            {
                InitializeGame();
                PlayGame();
            }
            else
            {
                Console.WriteLine("Thank you for playing the Number Guessing Game!");
                Console.ReadLine();
            }
        }

        static void PrintGameInstructions()
        {
            Console.WriteLine("Game Instructions:");
            Console.WriteLine("1. A secret number between 1 and 100 will be generated.");
            Console.WriteLine("2. You need to guess the secret number.");
            Console.WriteLine("3. After each guess, you will be informed if your guess is too low or too high.");
            Console.WriteLine("4. Keep guessing until you correctly guess the secret number.");
            Console.WriteLine("5. The game will display the total number of attempts you made.");
            Console.WriteLine();
        }
    }
}
