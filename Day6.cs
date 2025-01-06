//using System;
//using System.Collections.Generic;
//using System.Drawing;
//using System.IO;
//using System.Linq;

//namespace AdventOfCode
//{
//    class Program
//    {
//        private static int gridWidth;
//        private static int gridHeight;
//        private static Point startingPoint;
//        private static char[,] grid;
//        private static HashSet<Point> obstaclesPoint = new();
//        private static List<Point> availablePositions = new();
//        public static int obstacleLimit = 0;
//        static async Task<int> Main(string[] args)
//        {
//            List<string> lines = new();
//            var fileInput = "C://Users//titas//Desktop//AdventOfCode//AdventOfCode//input.txt";
//            using (var reader = new StreamReader(fileInput))
//            {

//                while ((await reader.ReadLineAsync()) is { } line)
//                {
//                    gridWidth = line.Length;
//                    gridHeight++;
//                    lines.Add(line);
//                }
//            }

//            grid = new char[gridWidth, gridHeight];

//            // Find starting point and obstacles
//            for (int y = 0; y < gridHeight; y++)
//            {
//                for (int x = 0; x < gridWidth; x++)
//                {
//                    grid[x, y] = lines[y][x];
//                    if (grid[x, y] == '^')
//                    {
//                        startingPoint = new Point(x, y);
//                    }

//                }
//            }

//            var obstaclesPossible = ObstaclesPossible(startingPoint);
//            int obstaclesCount = 0;
//            foreach (var obstacle in obstaclesPossible.Except([startingPoint]))
//            {
//                if (DoesGuardLoop(startingPoint, obstacle))
//                {
//                    obstaclesCount++;
//                }
//            }
//            Console.WriteLine(obstaclesCount);
//            return obstaclesCount;


//        }
//        private static bool DoesGuardLoop(Point startingPoint, Point obstacle)
//        {
//            HashSet<(Point point, Point direction)> visited = new();
//            var currentDirection = new Point(0, -1);
//            var currentPoint = startingPoint;

//            while (true)

//            {
//                // add an obstacle and let the guard patrol if he doesnt get into a forever loop then we dont add position for the obstacle
//                if (visited.Contains((currentPoint, currentDirection)))
//                {
//                    return true;
//                }
//                visited.Add((currentPoint, currentDirection));
//                var nextPosition = new Point((currentPoint.X + currentDirection.X), (currentPoint.Y + currentDirection.Y));

//                if (OutOfBounds(nextPosition))
//                {
//                    break;
//                }
//                if (grid[nextPosition.X, nextPosition.Y] == '#' || (nextPosition.X == obstacle.X && nextPosition.Y == obstacle.Y))
//                {
//                    currentDirection = new Point(-currentDirection.Y, currentDirection.X);
//                    nextPosition = currentPoint;

//                }
//                if (OutOfBounds(nextPosition))
//                {
//                    break;
//                }

//                currentPoint = nextPosition;
//            }
//            return false;
//        }
//        public static HashSet<Point> ObstaclesPossible(Point startingPoint)
//        {
//            HashSet<Point> visited = new();

//            var currentDirection = new Point(0, -1);
//            var currentPoint = startingPoint;

//            while (true)

//            {
//                // add an obstacle and let the guard patrol if he doesnt get into a forever loop then we dont add position for the obstacle

//                visited.Add(currentPoint);
//                var nextPosition = new Point((currentPoint.X + currentDirection.X), (currentPoint.Y + currentDirection.Y));

//                if (OutOfBounds(nextPosition))
//                {
//                    break;
//                }
//                if (grid[nextPosition.X, nextPosition.Y] == '#')
//                {
//                    currentDirection = new Point(-currentDirection.Y, currentDirection.X);
//                    nextPosition = currentPoint;

//                }
//                if (OutOfBounds(nextPosition))
//                {
//                    break;
//                }

//                currentPoint = nextPosition;
//            }
//            return visited;
//        }

//        public static void InsertObstacle(Point obstacle)
//        {

//            if (obstacle.X < gridWidth && obstacle.Y < gridHeight && !obstaclesPoint.Add(obstacle))
//            {

//                if (obstacleLimit < 1)
//                {
//                    obstaclesPoint.Add(obstacle);
//                    obstacleLimit++;
//                    grid[obstacle.X, obstacle.Y] = 'O';
//                }
//                else
//                {
//                    Console.WriteLine("Obstacle limit reached");
//                }


//            }
//        }
//        private static bool OutOfBounds(Point nextPoint)
//        {
//            return nextPoint.X < 0 || nextPoint.Y < 0 || nextPoint.X >= gridWidth || nextPoint.Y >= gridHeight;
//        }
//    }
//}
