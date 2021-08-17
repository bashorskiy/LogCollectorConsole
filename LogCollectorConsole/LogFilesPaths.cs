using System.Collections.Generic;
using System.IO;

namespace LogCollectorConsole
{
    public class LogFilesPaths
    {
        public int MissCounter { get; private set; }
        public List<string> Files { get; set; }
        public void CheckFiles()
        {
            List<string> files = new List<string>();
            foreach (var filepath in Files)
            {
                if (File.Exists(filepath)||Directory.Exists(filepath))
                {
                    System.Console.WriteLine($@"Найден файл {filepath}");
                    files.Add(filepath);
                }
                else
                {
                    System.Console.WriteLine($@"Не обнаружен файл {filepath}");
                    MissCounter++;
                }
            }
            Files = files;
        }     
    }
}
