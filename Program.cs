using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
    class Program
    {

        static void Main(string[] args)
        {
            int gridWidth = 0;
            int gridHeight = 0;
            char[,] grid;
            HashSet<Point> antinode= new HashSet<Point>();
            HashSet<Point> frequency = new HashSet<Point>();
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
                        if (grid[x, y] == '#')
                        {
                            antinode.Add(new Point(x,y));
                        }
                        // check for frequency
                        if (grid[x,y] != '.' && grid[x, y] != '#')
                        {
                            Console.WriteLine(grid[x, y]);
                            frequency.Add(new Point(x, y));

                        }
                        // add the direction and if it matches then its true and add to possible antinode creations
                        // check for inline with other frequency
                        
                      
                    }
                    
                    
                }
                foreach (var p1 in frequency)
                {
                    foreach (var p2 in frequency)
                    {
                     if (p1.Equals(p2))
                     {
                        continue;
                     }
                    foreach (var (dRow, dCol) in directions)
                    {
                        
                        int rowDiff = p2.X - p1.X;
                        int colDiff = p2.Y - p1.Y;

                      
                        if (rowDiff == dRow && colDiff == dCol )
                        {
                            Console.WriteLine($"Points {p1} and {p2} are aligned in direction ({dRow}, {dCol})");
                        }
                        // detect all possible areas of antinodes.
                    }
                }
               }
                
                

           
        }
    }
}
