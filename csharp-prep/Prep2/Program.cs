using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string userInput = Console.ReadLine();
        int gradePercentage = int.Parse(userInput);

        string letter = "F";
        string sign = "";

        if (gradePercentage >= 90)
        {
            letter = "A";
        }
        else if (gradePercentage >= 80)
        {
            letter = "B";
        }
        else if (gradePercentage >= 70)
        {
            letter = "C";
        }
        else if (gradePercentage >= 60)
        {
            letter = "D";
        }

        int gradePercentageRemainder = gradePercentage % 10;
        if (gradePercentageRemainder >= 7 && letter != "A" && letter != "F")
        {
            sign = "+";
        }
        else if (gradePercentageRemainder <= 3 && letter != "F")
        {
            sign = "-";
        }

        Console.WriteLine($"Your grade is {letter}{sign}");

        if (gradePercentage >= 70)
        {
            Console.WriteLine("Congratulations, you have passed the course.");
        }
        else
        {
            Console.WriteLine("Keep trying and you will surely be able to achieve it.");
        }
    }
}