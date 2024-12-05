using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

public partial class Program
{ 
    
        
    [GeneratedRegex(@"mul\((\d+),(\d+)\)")]
    public static partial Regex MulRegex();

    [GeneratedRegex(@"do\(\)")]
    public static partial Regex DoRegex();

    [GeneratedRegex(@"don't\(\)")]
    public static partial Regex DontRegex();


    [GeneratedRegex(@"\d+")]
    public static partial Regex ExtractNumbersRegex();

    public static void Main(string[] args)
    {
        string[] lines = File.ReadAllLines("C:/Users/titas/Desktop/AdventOfCode/AdventOfCode/input.txt");
        int sum = 0;
        bool isEnabled = true; // Instructions are enabled at the start

        foreach (string line in lines)
        {
            var mulMatches = MulRegex().Matches(line);
            var doMatches = DoRegex().Matches(line);
            var dontMatches = DontRegex().Matches(line);

            var doIndicies = doMatches.Select(m => m.Index).ToList();
            var dontIndicies = dontMatches.Select(m => m.Index).ToList();
            var mergedIndicies = doIndicies.Concat(dontIndicies).OrderBy(i => i).ToArray();

            int index = 0;

            foreach (Match match in mulMatches)
            {
                if (match.Success)
                {
                    var matchIndex = match.Index;

                    while (index < mergedIndicies.Length && matchIndex >= mergedIndicies[index])
                    {
                        
                        if (doIndicies.Contains(mergedIndicies[index]))
                        {
                            isEnabled = true; // Enable future mul() operations
                        }
                        else if (dontIndicies.Contains(mergedIndicies[index]))
                        {
                            isEnabled = false; // Disable future mul() operations
                        }
                        index++;
                    }

                    // Perform the multiplication if enabled
                    if (isEnabled)
                    {
                        string mulNumber = match.Value;
                        var numberMul = ExtractNumbersRegex().Matches(mulNumber);

                        if (numberMul.Count == 2)
                        {
                            int x = int.Parse(numberMul[0].Value);
                            int y = int.Parse(numberMul[1].Value);
                            sum += (x * y);
                        }
                    }
                }
            }
        }

        Console.WriteLine(sum);
    }
}
