using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using System.Reflection;
using PathFinder.Helpers;

namespace PathFinder
{
    public class Grid
    {
        public Grid()
        {
            this.GridData = this.LoadData();
            this.XAxis = GridData.GetUpperBound(0);
            this.YAxis = GridData.GetUpperBound(1);
        }
        public int XAxis { get; set; }

        public int YAxis { get; set; }
        
        public char[,] GridData { get; set; }

        /// <summary>
        /// Load data from a txt file
        /// </summary>
        /// <returns></returns>
        private char[,] LoadData()
        {
            string fileContent = File.ReadAllText(FileHelper.GetFilePath());

            string[] rows = fileContent.Split('\n');

            int rowLength = rows.Length;

            int columnLength = rows.First().Split(' ').Length;


            char[,] data = new char[rowLength, columnLength];

            int count = 0;
            foreach (string row in rows)
            {
                string[] columns = row.Split(' ');
                
                for (int y = 0; y <= columnLength - 1; y++)
                {
                    data[count, y] = columns[y][0];
                }
                count++;
            }
            return data;
        }
    }
}
