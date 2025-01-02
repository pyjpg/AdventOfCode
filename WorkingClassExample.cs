//using System;
//using System.Collections.Generic;
//using System.Drawing;
//using System.IO;
//using System.Linq;

//namespace AdventOfCode
//{
//    public partial class AoC2024Day6Part1
//    {
//        private int _width;
//        private int _height;
//        private char[,] _map;
//        private Point _startingPoint;

//        public async Task<string> SolveAsync(StreamReader inputReader)
//        {
//            List<string> lines = new();
//            while (await inputReader.ReadLineAsync() is { } line)
//            {
//                _width = line.Length;
//                _height++;

//                lines.Add(line);
//            }

//            _map = new char[_width, _height];
//            for (int y = 0; y < _height; y++)
//            {
//                for (int x = 0; x < _width; x++)
//                {
//                    _map[x, y] = lines[y][x];
//                    if (_map[x, y] == '^')
//                    {
//                        _startingPoint = new Point(x, y);
//                    }
//                }
//            }

//            return CountSteps(_startingPoint).ToString();
//        }

//        private int CountSteps(Point start)
//        {
//            HashSet<Point> visited = new();

//            var currentDirection = new Point(0, -1);
//            var currentPoint = start;
//            while (true)
//            {
//                visited.Add(currentPoint);
//                var nextPosition = new Point(currentPoint.X + currentDirection.X, currentPoint.Y + currentDirection.Y);
//                if (IsOutOfBounds(nextPosition))
//                {
//                    break;
//                }

//                if (_map[nextPosition.X, nextPosition.Y] == '#')
//                {
//                    // Turn right
//                    currentDirection = new Point(-currentDirection.Y, currentDirection.X);
//                    nextPosition = new Point(currentPoint.X + currentDirection.X, currentPoint.Y + currentDirection.Y);
//                }

//                if (IsOutOfBounds(nextPosition))
//                {
//                    break;
//                }

//                currentPoint = nextPosition;
//            }

//            return visited.Count;
//        }

//        private bool IsOutOfBounds(Point position)
//        {
//            return position.X < 0 || position.Y < 0 || position.X >= _width || position.Y >= _height;
//        }
//        public static async Task Main(string[] args)
//        {
//            try
//            {
//                var filePath = "C://Users//titas//Desktop//AdventOfCode//AdventOfCode//input.txt";

//                if (!File.Exists(filePath))
//                {
//                    Console.WriteLine("Input file not found.");
//                    return;
//                }

//                using var inputReader = new StreamReader(filePath);
//                var solver = new AoC2024Day6Part1();
//                var result = await solver.SolveAsync(inputReader);
//                Console.WriteLine($"Result: {result}");
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"An error occurred: {ex.Message}");
//            }
//        }
//    }
//}