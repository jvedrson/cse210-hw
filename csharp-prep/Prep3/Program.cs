using System;

class Program
{
    static void Main(string[] args)
    {
        bool finished = false;
        int totalGuessed = 0;
        int totalAttempts = 0;

        while (!finished)
        {
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 100);
            int attempts = 0;
            bool guessed = false;

            while (!guessed)
            {
                Console.Write("What is your guess? ");
                string userInputGuessNumber = Console.ReadLine();
                int userNumber = int.Parse(userInputGuessNumber);
                attempts += 1;

                if (magicNumber == userNumber)
                {
                    Console.WriteLine("You guessed it!");
                    Console.WriteLine($"Attempts: {attempts}\n");
                    totalGuessed += 1;
                    totalAttempts += attempts;
                    guessed = true;
                }
                else if (magicNumber > userNumber)
                {
                    Console.WriteLine("Higher");
                }
                else
                {
                    Console.WriteLine("Lower");
                }
            }

            Console.Write("Do you want to play again? ");
            string userInputContinue = Console.ReadLine();
            Console.WriteLine();


            if (userInputContinue.ToLower() != "yes")
            {
                finished = true;
                Console.WriteLine("Game over!");
                Console.WriteLine($"Total numbers guessed: {totalGuessed}");
                Console.WriteLine($"Attempts made: {totalAttempts}");
            }
        }        
    }
}