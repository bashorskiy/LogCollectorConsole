using System.Collections.Generic;
using System.IO;

namespace LogCollectorConsole
{
    public class LogFilesPaths
    {
        public int Key { get; set; }
        public int MissCounter { get; private set; }
        public List<string> Files { get; set; }
        private void LoginCheck()
        {
            if (Key > 5 && Key < 8)
            {               
                while (true)
                {

                    Printer.Info.EnterLogin();
                    string login = System.Console.ReadLine();
                    Files[0] = Files[0] + login + ".log";
                    if (!File.Exists(Files[0]))
                    {
                        Printer.Errors.IncorrectLogin();
                        bool isChoice = int.TryParse(System.Console.ReadLine(), out int key);
                        if (isChoice && key > 0 && key < 3)
                        {                           
                            break;
                        }
                        else
                        {
                            continue;
                        }                        
                    }
                }
            }
        }
        public void CheckFiles()
        {
            List<string> files = new List<string>();
            LoginCheck();           
            foreach (var filepath in Files)
            {
                if (File.Exists(filepath) || Directory.Exists(filepath))
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

