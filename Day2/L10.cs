using System;

class GuessingGame
{
    static void Main()
    {
        const int secret = 7; // Secret number

        // Start the guessing game
        PlayGame(secret);
    }

    // Runs the guessing game logic
    static void PlayGame(int secret)
    {
        int guess;

        // Repeat until user guesses correctly
        do
        {
            Console.Write("Guess the number: ");
            guess = int.Parse(Console.ReadLine()!);

            // Check incorrect guess
            if (guess != secret)
                Console.WriteLine("Wrong guess. Try again.");
        }
        while (guess != secret);

        // Correct guess message
        Console.WriteLine("Correct! You guessed it.");
    }
}
