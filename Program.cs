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
                    if (grid[x, y] == '.' && obstaclesPoint.Add(new Point(x, y))) // Only add obstacle if not already added
                    {
                        
                        InsertObstacle(new Point(x, y));

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
            var foreverObstacle = 0;
            var counter = 0;
            while (true)

            {
                // add an obstacle and let the guard patrol if he doesnt get into a forever loop then we dont add position for the obstacle

                visited.Add(currentPoint);
                var nextPosition = new Point((currentPoint.X + currentDirection.X), (currentPoint.Y + currentDirection.Y));
                if (!visited.Add(nextPosition))
                {
                    Console.WriteLine($"Forever loop: {currentPoint.X}, {currentPoint.Y}");


                    counter++;
                    if (counter > 4)
                    {
                        foreverObstacle++;
                        return counter;
                        
                    }
                }
                if (OutOfBounds(nextPosition))
                {
                    break;
                }
                if (grid[nextPosition.X, nextPosition.Y] == '#' || grid[nextPosition.X, nextPosition.Y] == 'O')
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

        public static void InsertObstacle(Point obstacle)
        {
            
            if (obstacle.X < gridWidth && obstacle.Y < gridHeight && obstacleLimit < 1 )
            {

                    obstaclesPoint.Add(obstacle);
                    obstacleLimit++;
                    grid[obstacle.X, obstacle.Y] = 'O';
                
            }
        }
        private static bool OutOfBounds(Point nextPoint)
        {
            return nextPoint.X < 0 || nextPoint.Y < 0 || nextPoint.X >= gridWidth || nextPoint.Y >= gridHeight;
        }
    }
}
