using System.Collections.Generic;
using System.IO;

namespace LogCollectorConsole
{
    public class LogFilesPaths
    {
        public int Key { get; set; }
        public int MissCounter { get; private set; }
        public List<string> Files { get; set; }

        private void EnterLogin()
        {
            bool isCorrect = false;
            while (!isCorrect)
            {
                Printer.Info.EnterLogin();
                string login = System.Console.ReadLine();
                Files[0] = Files[0] + login + ".log";

                isCorrect = IsLoginCorrect();
            }
        }

        private bool IsLoginCorrect()
        {
            bool isCorrect = false;
            if (!File.Exists(Files[0]))
            {
                Printer.Errors.IncorrectLogin();
                bool isChoice = int.TryParse(System.Console.ReadLine(), out int key);
                if (isChoice && key == 1)
                {
                    isCorrect = false;
                }
                if (isChoice && key == 2)
                {
                    isCorrect = true;
                }
            }
            else
            {
                isCorrect = true;
            }
            return isCorrect;
        }

        private List<string> TildaPathSplit(IEnumerable<string> tildaList)
        {
            List<string> list = new List<string>();
            foreach (var item in tildaList)
            {
                string[] splittedStrings = item.Split('\\');               
                string[] temp = new string[2];                
                for (int i = 0; i < 2; i++)
                {
                    temp[i] = splittedStrings[splittedStrings.Length-2+i];                    
                }               
                list.Add(Path.Combine(temp));
            }
            return list;
        }

        private List<string> TildaFilesCheck()
        {
            List<string> tildaList = new List<string>();
            string tildaPath = Path.Combine(Directory.GetCurrentDirectory(), "DB");
            if (Directory.Exists(tildaPath))
            {
                tildaList.AddRange(TildaPathSplit(Directory.GetFiles(tildaPath, "Referent.~f*", SearchOption.AllDirectories)));
            }
            return tildaList;
        }

        public void CheckFiles()
        {
            List<string> files = new List<string>();
            if (Key > 0 && Key < 5)
            {
                EnterLogin();
            }
            if (Key == 11)
            {
                files.AddRange(TildaFilesCheck());
            }
            foreach (var filepath in Files)
            {
                if (File.Exists(filepath) || Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), filepath)))
                {
                    System.Console.WriteLine($@"Найден {filepath}");                    
                    files.Add(filepath);
                }
                else
                {
                    System.Console.WriteLine($@"Не обнаружен {filepath}");
                    MissCounter++;
                }
            }
            Files = files;
        }
    }
}

