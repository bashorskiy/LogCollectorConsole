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
            while (true)
            {
                Printer.Info.EnterLogin();
                string login = System.Console.ReadLine();
                Files[0] = Path.Combine(Files[0], login, ".log");
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
        private List<string> TildaFilesCheck()
        {
            List<string> tildaList = new List<string>();
            string tildaPath = Path.Combine(Directory.GetCurrentDirectory(), "DB");
            if (Directory.Exists(tildaPath))
            {
                tildaList.AddRange(Directory.GetFiles(tildaPath, "Referent.~f*", SearchOption.AllDirectories));
            }
            return tildaList;
        }
        public void CheckFiles()
        {
            List<string> files = new List<string>();
            if (Key > 0 && Key < 5)
            {
                LoginCheck();
            }
            if (Key == 11)
            {
                files.AddRange(TildaFilesCheck());
            }
            foreach (var filepath in Files)
            {
                if (File.Exists(filepath) || Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(),filepath)))
                {
                    System.Console.WriteLine($@"Найден {filepath}");
                    if (filepath.Equals("DB\\Backup"))
                    {
                        files.AddRange(Directory.GetFiles(filepath));
                    }
                    else
                    {
                        files.Add(filepath);
                    }
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

