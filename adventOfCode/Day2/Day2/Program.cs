using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // Specify the file path
        string filePath = "/home/marcus/RiderProjects/adventOfCode/adventOfCode/Day2/Day2/data.txt";

        // Read and process the file into a list of integer arrays
        var rows = ReadAndSplitRows(filePath);
        Console.WriteLine(safeRecords(rows));
        // Display the result
        Console.WriteLine("Rows of data:");
        
    }

    /// <summary>
    /// Reads a file and splits each row into a list of integers.
    /// </summary>
    /// <param name="filePath">The path to the file containing rows of data.</param>
    /// <returns>A list of integer arrays, where each array represents a row.</returns>
    static List<int[]> ReadAndSplitRows(string filePath)
    {
        // Initialize the list to hold rows of data
        List<int[]> rows = new List<int[]>();

        // Read all lines from the file
        string[] lines = File.ReadAllLines(filePath);

        foreach (string line in lines)
        {
            // Split the line by spaces and convert parts to integers
            int[] numbers = line.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            // Add the row to the list
            rows.Add(numbers);
        }

        return rows;
    }


    static bool safeDecresing(int[] numbers)
    {
        List<int>?numbersList= numbers.ToList();
        int numberIndex = 0;
        int maxFails = 1;
        int fails = 0;    
        while (numberIndex < numbersList.Count -1)
        {
            int difference = numbersList[numberIndex] - numbersList[numberIndex + 1];
            
            // Check if the difference is not within the range 1 to 3
            if (difference < 1 || difference > 3)
            {
                {
                    fails++;
                    numbersList.RemoveAt(numberIndex);
                    numberIndex = 0;
                    if (fails > maxFails)
                    {
                        return false;
                    }
                }
            }
            else
            {
                numberIndex++;
            }
        }
        return true;
    }
    static bool safeIncreasing(int[] numbers)
    {
        List<int>?numbersList= numbers.ToList();
        int numberIndex = 0;
        int maxFails = 1;
        int fails = 0;   
        while (numberIndex < numbersList.Count -1)
        {   
            
            int difference = numbersList[numberIndex+1] - numbersList[numberIndex] ;
            
            // Check if the difference is not within the range 1 to 3
            if (difference < 1 || difference > 3)
            {
                fails++;
                numbersList.RemoveAt(numberIndex);
                numberIndex = 0;
                if (fails > maxFails)
                {
                    return false;
                }
            }
            else
            {
                numberIndex ++;
            }
            
        }
        return true;
    }

    static int safeRecords(List<int[]> numbers)
    {
        int sum = 0;
        foreach (var row in numbers)
        {
            if (safeDecresing(row) || safeIncreasing(row))
            {
                sum++;
            }
        }
        
        return sum;
    }
}
