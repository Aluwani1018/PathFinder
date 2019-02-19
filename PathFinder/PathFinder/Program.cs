using PathFinder.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PathFinder
{
    /// <summary>
    /// Author : Aluwani Mathode
    /// Summary : Main purpose of this application is to find a path from E to S throw walls. 
    ///         , as plagirism is not allowed, I should have used the Dijkstra path finding library to do this.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Grid grid = new Grid();

            //get start indexes
            Tuple<int?, int?> startIndex = GridHelper.FindIndex(grid, 'E');
            
            //get end indexes
            Tuple<int?, int?> endIndex = GridHelper.FindIndex(grid, 'S');

            //Find Path to "S"
            var results = GridHelper.FindPath(
                grid, 
                new Tuple<int, int>((int)startIndex.Item1, (int)startIndex.Item2), 
                new Tuple<int, int>((int)endIndex.Item1, (int)endIndex.Item2), false);

            //print grid results
            PrintResult(grid);

            Console.Read();
        }


        /// <summary>
        /// Prints grid results
        /// </summary>
        /// <param name="grid"></param>
        static void PrintResult(Grid grid)
        {
            for (int x = 0; x <= grid.XAxis; x++)
            {
                for (int y = 0; y <= grid.YAxis; y++)
                {
                    Console.Write(grid.GridData[x, y] + " ");
                }
                Console.WriteLine("\n");
            }
        }
    }
}
