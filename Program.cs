using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
    class Program 
    {
        
        static  void Main(string[] args)
        {
            List<long> Sums = new();
            long sumOfTrue = 0;
            List<List<long>> operations = new();
            var fileInput = "C://Users//titas//Desktop//AdventOfCode//AdventOfCode//input.txt";
            foreach (var line in File.ReadAllLines(fileInput))
            {
                List<long> currentOperations = new();
                var parts = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int x = 0; x < parts.Length; x++)
                {
                    if (parts[x].Contains(":")) 
                    {
                        parts[x] = parts[x].Replace(":", "");
                        if (long.TryParse(parts[x], out var sum))
                        {
                            Sums.Add(sum);
                        }
                        
                    }
                    else if (long.TryParse(parts[x], out var number))
                    {
                        currentOperations.Add(number);
                        
                    }
                    
                }

                if (currentOperations.Count > 0)
                {
                    operations.Add(currentOperations);
                }

            }
            for (int i = 0; i < operations.Count; i++)
            {
               
                    long sum = Sums[i];
                    var numbers = operations[i]; // Start with the first number

                Console.WriteLine($"Target: {sum}, Numbers: {string.Join(", ", numbers)}");

                if (FindCombination(numbers, sum, 0, numbers[0]))
                {
                    Console.WriteLine($"A valid combination found for {sum}!");
                    sumOfTrue += sum;
                }
                else
                {
                    Console.WriteLine($"No valid combination found for {sum}.");
                }

            }
            Console.WriteLine(sumOfTrue);

            Console.ReadLine();




        }
        public static bool FindCombination(List<long> numbers, long target, int index, long currentResult)
        {

            if (index == numbers.Count - 1)
                return currentResult == target;

            // Try addition
            if (FindCombination(numbers, target, index + 1, currentResult + numbers[index + 1]))
                return true;

            // Try multiplication
            if (FindCombination(numbers, target, index + 1, currentResult * numbers[index + 1]))
                return true;

            // Try concatenation
            long concatenated = long.Parse(currentResult.ToString() + numbers[index + 1].ToString());
            if (FindCombination(numbers, target, index + 1, concatenated))
                return true;
            return false;

        }
            

        }

    }
