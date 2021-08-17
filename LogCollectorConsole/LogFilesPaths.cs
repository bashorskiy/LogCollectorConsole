using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Resources;
using System.Linq;

namespace LogCollectorConsole
{
    public class LogFilesPaths
    {
        protected int _missCounter = default;
        public List<string> Files { get; set; }
        protected List<string> CheckFiles()
        {
            List<string> files = new List<string>();
            foreach (var filepath in Files)
            {
                if (File.Exists(filepath))
                {
                    System.Console.WriteLine($@"Найден файл {filepath}");
                    files.Add(filepath);
                }
                else
                {
                    System.Console.WriteLine($@"Не обнаружен файл {filepath}");
                    _missCounter++;
                }
            }
            return files;
        }
       
        public int GetMissCounter()
        {
            return _missCounter;
        }
        
        protected void Intialize()
        {           
            Files = CheckFiles();
        }        
    }



}
