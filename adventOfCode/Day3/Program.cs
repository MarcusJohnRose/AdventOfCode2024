using System.Text.RegularExpressions;
class Program

{
    static void Main(string[] args)
    {
        // Specify the file path
        string filePath = "/home/marcus/RiderProjects/adventOfCode/adventOfCode/Day3/data.txt";

        // Read and process the file into a list of integer arrays
        // var rows = ReadAndSplitRows(filePath);
        // Display the result
        var texxt = ReadAndSplitRows(filePath);
        var test1 =processMatches(texxt);
        Console.WriteLine($"Rows of data:{test1}");

    }

    static List<string> ReadAndSplitRows(string filePath)
    {
        // Initialize the list to hold rows of data
        List<int[]> rows = new List<int[]>();

        // Read all lines from the file
        string stringlines = File.ReadAllText(filePath);
        // string regPattern = @"mul\(\d{1,3},\d{1,3}\)";
        string regPattern = @"mul\(\d+,\d+\)|don't\(\)|do\(\)";
        MatchCollection matches = Regex.Matches(stringlines, regPattern);
        foreach (Match match in matches)
        {
            Console.WriteLine(match.Value);
        }

        return matches.Cast<Match>().Select(x => x.Value).ToList();
    }

    static int processMatches(List<string> matches)
    {
        bool calulcate = true;
        
        int count = 0;
        string Rightstring = String.Empty;
        foreach (string match in matches)
        {
            if (match.Contains("don't"))
            {
             calulcate = false;
             
            }else if (match.Contains("do"))
            {
                calulcate = true;
            }
            if (calulcate && match.Contains("mul")){
                // string numberString= match.Substring(match.IndexOf("("),match.IndexOf(")"));
                int startIndex = match.IndexOf("(") + 1;
                int endIndex = match.IndexOf(")");

                string numberString = match.Substring(startIndex, endIndex - startIndex);
                var splitString = numberString.Split(",");
                int leftNum = Int32.Parse(splitString[0]);
                int rightNum = Int32.Parse(splitString[1]);
                count += leftNum * rightNum;
            }
        }
        
        return count;
    }

    
}