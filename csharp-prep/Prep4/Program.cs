using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<int> numbers = new List<int>();

        // Input loop to populate the list
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        while (true)
        {
            Console.Write("Enter number: ");
            int num = int.Parse(Console.ReadLine());

            if (num == 0)
                break;

            numbers.Add(num);
        }

        // Calculate sum
        int sum = numbers.Sum();

        // Calculate average
        double average = numbers.Average();

        // Find maximum number
        int max = numbers.Max();

        // Output results
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {max}");

        // Stretch challenge: Find smallest positive number
        int smallestPositive = numbers.Where(x => x > 0).DefaultIfEmpty(0).Min();
        Console.WriteLine($"The smallest positive number is: {smallestPositive}");

        // Stretch challenge: Sort and display the list
        numbers.Sort();
        Console.WriteLine("The sorted list is:");
        foreach (var number in numbers)
        {
            Console.WriteLine(number);
        }
    }
}
