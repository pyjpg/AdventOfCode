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
        static async Task Main(string[] args)
        {
            List<string> lines = new();
            var fileInput = "C://Users//titas//Desktop//AdventOfCode//AdventOfCode//input.txt";
            using (var reader = new StreamReader(fileInput))
            {

                while ((await reader.ReadLineAsync()) is { } line)
                {
                    gridWidth = line.Length;
                    gridHeight++;
                    lines.Add(line);
                }
            }

            grid = new char[gridWidth, gridHeight];

            // Find starting point and obstacles
            for (int y = 0; y < gridHeight; y++)
            {
                for (int x = 0; x < gridWidth; x++)
                {
                    grid[x, y] = lines[y][x];
                    if (grid[x,y] == '^')
                    {
                        startingPoint = new Point(x, y);
                    }
                }
            }
            CountSteps(startingPoint).ToString();
            


        }
        public static int CountSteps(Point startingPoint)
        {
            HashSet<Point> visited = new();
            var currentDirection = new Point(0, -1);
            var currentPoint = startingPoint;
            while (true)
            
            {
                    
                
                visited.Add(currentPoint);
                var nextPosition = new Point((currentPoint.X + currentDirection.X),(currentPoint.Y + currentDirection.Y));
                if (!visited.Add(nextPosition))
                {
                    Console.WriteLine($"Forever loop: {currentPoint.X}, {currentPoint.Y}");

                    var counter = 0;
                    counter++;
                    if (counter > 4)
                    {
                        break;
                    }
                }
                if (OutOfBounds(nextPosition))
                {
                    break;
                }
                if (grid[nextPosition.X, nextPosition.Y] == '#')
                {
                    currentDirection = new Point(-currentDirection.Y, currentDirection.X);
                    nextPosition = new Point(
                        currentPoint.X + currentDirection.X,
                        currentPoint.Y + currentDirection.Y
                    );
                }
                if (OutOfBounds(nextPosition))
                {
                    break;
                }
                 
                currentPoint = nextPosition;
            }
            return visited.Count;
            
         
            
        }
       
        private static bool OutOfBounds(Point nextPoint)
        {
            return nextPoint.X < 0 || nextPoint.Y < 0 || nextPoint.X >= gridWidth || nextPoint.Y >= gridHeight;
        }
    }
}
