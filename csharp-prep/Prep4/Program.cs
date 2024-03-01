using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        bool stop = false;
        
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        while (!stop)
        {
            Console.Write("Enter number: ");
            string userInput = Console.ReadLine();
            int userNumber = int.Parse(userInput);

            if (userNumber == 0)
            {
                stop = true;
            }
            else
            {
                numbers.Add(userNumber);
            }
        }
        
        int min = 999999999;
        int max = 0;
        int sum = 0;

        foreach (int num in numbers)
        {
            sum += num;
            if (num > max)
            {
                max = num;
            }
            else if (num < min && num >= 0)
            {
                min = num;
            }
        }

        float average = ((float)sum / numbers.Count);

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {max}");
        Console.WriteLine($"The smallest positive number is: {min}");

        numbers.Sort();
        Console.WriteLine("The sorted list is:");
        foreach (int numberSorted in numbers)
        {
            Console.WriteLine(numberSorted);
        }
    }
}