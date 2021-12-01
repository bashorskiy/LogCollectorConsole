using System.Collections.Generic;
using System.IO;

namespace LogCollectorConsole
{
    public class LogFilesPaths
    {
        public int DepKey { get; set; }
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
                isCorrect = IsLoginCorrect(login);
            }
        }

        private bool IsLoginCorrect(string login)
        {
            bool isCorrect = false;
            if (!File.Exists(Files[0] + login + ".log"))
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
                if (DepKey == 1)
                {
                    Files[0] = Files[0] + login + ".log";
                    isCorrect = true;
                }
                if (DepKey == 2)
                {
                    Files[0] = Files[0] + login + ".log";

                }
            }
            return isCorrect;
        }

        private List<string> PathSplit(string[] pathsList)
        {          
            List<string> list = new List<string>();
            foreach (var item in pathsList)
            {
                string[] splittedStrings = item.Split('\\');
                int counter = 0;
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                while (!sb.ToString().Equals(Directory.GetCurrentDirectory()+"\\"))
                {
                    sb.Append(splittedStrings[counter]);
                    sb.Append("\\");
                    counter++;
                }
                sb.Clear();
                for (; counter < splittedStrings.Length; counter++)
                {
                    sb.Append(splittedStrings[counter]);
                    if (counter!=splittedStrings.Length-1)
                    {
                        sb.Append("\\");
                    }                   
                }
                list.Add(sb.ToString());
            }                     
            return list;
        }

        private List<string> FilesWithPatternCheck(string checkingPath, string pattern)
        {
            List<string> formatList = new List<string>();           
            if (Directory.Exists(checkingPath))
            {
                formatList.AddRange(PathSplit(Directory.GetFiles(checkingPath, pattern, SearchOption.AllDirectories)));
            }
            return formatList;
        }

        public void CheckFiles()
        {
            List<string> files = new List<string>();
            if (Key > 0 && Key < 5)
            {
                EnterLogin();
            }
            if (Key == 5)
            {
                files.AddRange(FilesWithPatternCheck(Directory.GetCurrentDirectory(), "TXUpdater_*.log"));
            }
            if (Key == 10)
            {
                files.AddRange(FilesWithPatternCheck(Path.Combine(Directory.GetCurrentDirectory(),"DB"),"Referent.~f*"));
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

