using System;
using System.Collections.Generic;
using System.Text;

namespace PathFinder.Helpers
{
    public class GridHelper
    {
        /// <summary>
        /// Finds index of a value
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Tuple<int?, int?> FindIndex(Grid grid, char value)
        {
            for (int x = 0; x <= grid.XAxis; x++)
            {
                for (int y = 0; y <= grid.YAxis; y++)
                {
                    if (grid.GridData[x, y] == value)
                    {
                        return new Tuple<int?, int?>(x, y);
                    }
                }
            }
            return new Tuple<int?, int?>(null, null); ;
        }

        /// <summary>
        /// Finds paths from start to end 
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <param name="wasOnTop"></param>
        /// <returns></returns>
        public static char[,] FindPath(Grid grid, Tuple<int, int> startIndex, Tuple<int, int> endIndex, bool wasOnTop)
        {
            if (startIndex.Item1 > 0)
            {
                Tuple<int, int> lastIndex = new Tuple<int, int>(startIndex.Item1 , startIndex.Item2);

                //Check if it is safe to move, and flag if moved
                if (grid.GridData[startIndex.Item1 , startIndex.Item2-1] == '.')
                {
                    lastIndex = new Tuple<int, int>(startIndex.Item1, startIndex.Item2 - 1);

                    if(startIndex.Item2 == 1)
                    {
                        return grid.GridData;
                    }

                    grid.GridData[lastIndex.Item1, lastIndex.Item2] = '*';

                    FindPath(grid, lastIndex, endIndex, wasOnTop);
                }
                
                //check for wall
                if(grid.GridData[startIndex.Item1, startIndex.Item2 - 1] == 'W')
                {
                    if(!wasOnTop)
                    {
                        wasOnTop = startIndex.Item1 == 1;
                        lastIndex = new Tuple<int, int>(wasOnTop? startIndex.Item1 : startIndex.Item1 - 1, startIndex.Item2);
                        
                    }
                    else
                    {
                        wasOnTop = !(startIndex.Item1 == grid.XAxis);
                        lastIndex = new Tuple<int, int>(!wasOnTop? startIndex.Item1 : startIndex.Item1 + 1, startIndex.Item2);
                    }

                    grid.GridData[lastIndex.Item1, lastIndex.Item2] = '*';

                    FindPath(grid, lastIndex, endIndex, wasOnTop);
                }

                //check for destination.
                if (grid.GridData[startIndex.Item1, startIndex.Item2 - 1] != 'S' && lastIndex.Item2 == 1 )
                {
                    
                    lastIndex = new Tuple<int, int>(wasOnTop ? startIndex.Item1 : startIndex.Item1 - 1, startIndex.Item2);


                    grid.GridData[lastIndex.Item1, lastIndex.Item2] = '*';

                    FindPath(grid, lastIndex, endIndex, wasOnTop);
                }
            }
            return grid.GridData;
        }
    }
}
