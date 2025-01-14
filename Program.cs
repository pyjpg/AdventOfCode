using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AdventOfCode
{
    class Program
    {
        public static int gridWidth = 0;
        public static int gridHeight = 0;
        public static void Main(string[] args)
        {
            
            char[,] grid;
            Dictionary<char, List<(int x, int y)>> antenas = new();
            HashSet<(int x, int y)> antinode = new HashSet<(int x, int y)>();
            List<string> lines = new List<string>();
            List<(int dRow, int dCol)> directions = new List<(int dRow, int dCol)>
            {
                (-1, 1),
                (-1, 0),
                (-1, -1),
                (0, 1),
                (0, -1),
                (1, -1),
                (1, 0),
                (1, 1),
            };

            var fileInput = "C://Users//titas//Desktop//AdventOfCode//AdventOfCode//input.txt";
            foreach (var line in File.ReadAllLines(fileInput))
            {

                gridWidth = line.Length;
                gridHeight++;
                lines.Add(line);
                Console.WriteLine(line);
            }

            grid = new char[gridWidth, gridHeight];
            for (int x = 0; x < gridWidth; x++)
            {
                for (int y = 0; y < gridHeight; y++)
                {
                    grid[x, y] = lines[y][x];
                    
     
                    var character = grid[x, y];
                    if (character != '.')
                    {
                        if (!antenas.ContainsKey(grid[x, y]))
                        {
                            antenas[grid[x, y]] = new List<(int x, int y)> { (x, y) };
                        }
                        else
                        {
                            antenas[grid[x, y]].Add((x, y));
                        }

                    }

                }


            }
            
            foreach (var ants in antenas.Values.ToList())
            {
                for (int i = 0; i < ants.Count; i++)
                {
                    for (int j = 0; j < ants.Count; j++)
                    {
                        if (i == j) continue;

                        var ant1 = ants[i];
                        var ant2 = ants[j];

                        antinode.Add((2 * ant1.x - ant2.x, 2 * ant1.y - ant2.y));
                        antinode.Add((2 * ant2.x - ant1.x, 2 * ant2.y - ant1.y));

                    }
                }
                
            }

            var uniqueAntiNodes = antinode.Where(pos => pos.y >= 0 && pos.y < gridHeight && pos.x >= 0 && pos.x < gridWidth);
            Console.WriteLine(uniqueAntiNodes.Count());




      }
        
    }

}               

           