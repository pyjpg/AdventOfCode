using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
    class Program 
    {
        private static int gridWidth;
        private static int gridHeight;
        private static Point startingPoint;
        private static char[,] grid;
        private static HashSet<Point> obstaclesPoint = new();
        private static List<Point> availablePositions = new();
        public static int obstacleLimit = 0;
        static  void Main(string[] args)
        {
            List<int> Sums = new();
            int sumOfTrue = 0;
            List<List<int>> operations = new();
            var fileInput = "C://Users//titas//Desktop//AdventOfCode//AdventOfCode//input.txt";
            foreach (var line in File.ReadAllLines(fileInput))
            {
                List<int> currentOperations = new();
                var parts = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int x = 0; x < parts.Length; x++)
                {
                    if (parts[x].Contains(":")) 
                    {
                        parts[x] = parts[x].Replace(":", "");
                        if (int.TryParse(parts[x], out var sum))
                        {
                            Sums.Add(sum);
                        }
                        
                    }
                    else if (int.TryParse(parts[x], out var number))
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

               
                
                    var sum = Sums[i];
                 

                    for (int x = 0; x < operations[i].Count; x++)
                    {
                        for (int y = x + 1; y < operations[i].Count; y++)
                        {
                            var operationX = operations[i][x];
                            var operationY = operations[i][y];


                            var combo1 = operationX * operationY;
                            var combo2 = operationX + operationY;


                            if (sum == combo1 || sum == combo2)
                            {
                                Console.WriteLine($"The operations match the sum: {sum} using operations {operationX} and {operationY}");
                                sumOfTrue += sum;
                            }
                        }
                    }
                
                
            }
            Console.WriteLine(sumOfTrue);

            Console.ReadLine();




        }
       
    }
}
