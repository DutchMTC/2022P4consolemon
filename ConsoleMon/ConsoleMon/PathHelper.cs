using System.IO;

namespace ConsoleMonsters.Tools
{
    public static class PathHelper
    {
        public static string ExeDir()
        {
            return new FileInfo(typeof(PathHelper).Assembly.Location).DirectoryName;
        }
    }
}


