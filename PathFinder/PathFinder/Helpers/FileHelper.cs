using System;
using System.IO;
using System.Reflection;

namespace PathFinder.Helpers
{
    public class FileHelper
    {
        public static string GetFilePath()
        { 
            return Path.Combine(Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())), "Files","inputdata.txt");
        }
    }
}
