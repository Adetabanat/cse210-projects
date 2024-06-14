using System;

using System;

class Program
{
    static void Main()
    {
        GuessMyNumber();
    }

    static void GuessMyNumber()
    {
        Random random = new Random();
        int magicNumber = random.Next(1, 101);
        int numGuesses = 0;

        Console.WriteLine("Welcome to the Guess My Number game!");
        Console.WriteLine("I've picked a number between 1 and 100. Try to guess it!");

        while (true)
        {
            Console.Write("Enter your guess: ");
            if (!int.TryParse(Console.ReadLine(), out int guess))
            {
                Console.WriteLine("Please enter a valid number.");
                continue;
            }

            numGuesses++;

            if (guess < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else if (guess > magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine($"You guessed it in {numGuesses} guesses!");
                break;
            }
        }

        Console.Write("Do you want to play again? (yes/no): ");
        string playAgain = Console.ReadLine().ToLower();

        if (playAgain == "yes")
        {
            GuessMyNumber(); // Recursively start a new game
        }
        else
        {
            Console.WriteLine("Thanks for playing!");
        }
    }
}
