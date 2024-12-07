using System;
using System.IO;
using System.Collections.Generic;

class day1
{
    static void Main(string[] args)
    {
        // Specify the file path
        string filePath = "/home/marcus/RiderProjects/adventOfCode/adventOfCode/Day1/numbers.txt";

        // Call the method to process the file and get the results
        var (leftNumbers, rightNumbers) = ProcessFile(filePath);

        // Output the results
        leftNumbers.Sort();
        rightNumbers.Sort();
        int totalDifference = 0;
        for (int i = 0; i < leftNumbers.Count; i++)
        {
            int difference = CalculateDifference(leftNumbers[i], rightNumbers[i]);
            Console.WriteLine(difference);
            totalDifference += difference;
        }
        
        
        // Console.WriteLine("Left Numbers: " + string.Join(", ", leftNumbers));
        // Console.WriteLine("Right Numbers: " + string.Join(", ", rightNumbers));
        Console.WriteLine($"Total Difference: {totalDifference}");
    }

    /// <summary>
    /// Processes the file to extract left and right numbers and calculate the total difference.
    /// </summary>
    /// <param name="filePath">The path to the file containing number pairs.</param>
    /// <returns>A tuple containing the left numbers, right numbers, and total difference.</returns>
    static (List<int> leftNumbers, List<int> rightNumbers) ProcessFile(string filePath)
    {
        // Check if the file exists
        if (!File.Exists(filePath))
        {
            Console.WriteLine("File not found!");
            return (new List<int>(), new List<int>());
        }

        // Initialize lists to hold left and right numbers
        List<int> leftNumbers = new List<int>();
        List<int> rightNumbers = new List<int>();

        // Read and process each line
        string[] lines = ReadFile(filePath);

        foreach (string line in lines)
        {
            var result = ProcessLine(line);

            if (result.HasValue)
            {
                // Add numbers to the lists
                leftNumbers.Add(result.Value.left);
                rightNumbers.Add(result.Value.right);

                // Accumulate the total difference
                // totalDifference += result.Value.difference;
            }
        }

        return (leftNumbers, rightNumbers);
    }

    /// <summary>
    /// Reads all lines from the specified file.
    /// </summary>
    /// <param name="filePath">The path to the file.</param>
    /// <returns>An array of lines from the file.</returns>
    static string[] ReadFile(string filePath)
    {
        return File.ReadAllLines(filePath);
    }

    /// <summary>
    /// Processes a single line by extracting numbers and calculating the difference.
    /// </summary>
    /// <param name="line">A line containing two numbers separated by space or tab.</param>
    /// <returns>
    /// A tuple containing the left number, right number, and difference, 
    /// or null if the line format is invalid.
    /// </returns>
    static (int left, int right)? ProcessLine(string line)
    {
        // Split the line into parts
        string[] parts = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

        if (parts.Length == 2 &&
            int.TryParse(parts[0], out int leftNumber) &&
            int.TryParse(parts[1], out int rightNumber))
        {
            
            // Return the tuple
            return (leftNumber, rightNumber);
        }
        else
        {
            Console.WriteLine($"Invalid line format: {line}");
            return null; // Return null for invalid lines
        }
    }


    static int CalculateDifference(int leftNumber, int rightNumber)
    {
        if (leftNumber < rightNumber)
        {
            return rightNumber - leftNumber;
        }
        else
        {
            return leftNumber - rightNumber;
        }
    }
}
 