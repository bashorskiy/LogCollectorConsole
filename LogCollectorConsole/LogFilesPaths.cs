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
                Files[0] = Files[0]+login+".log";
                if (!File.Exists(Files[0]))
                {
                    Printer.Errors.IncorrectLogin();
                    bool isChoice = int.TryParse(System.Console.ReadLine(), out int key);
                    if (isChoice)
                    {
                        if (key == 1)
                        {

                        }           
                        else if (key == 2)
                        {

                        }
                        else
                        {
                            continue;
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }

        private List<string> TildaPathSplit(IEnumerable<string> tildaList)
        {
            List<string> list = new List<string>();
            foreach (var item in tildaList)
            {
                string[] splittedStrings = item.Split('\\');
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                for (int i = splittedStrings.Length-2; i < splittedStrings.Length; i++)
                {
                    sb.Append(splittedStrings[i]);
                    if (i != splittedStrings.Length -1)
                    {
                        sb.Append('\\');
                    }
                }
                list.Add(sb.ToString());
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
                LoginCheck();
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
                    //if (filepath.Equals("DB\\Backup"))
                    //{
                    //    files.AddRange(Directory.GetFiles(filepath));
                    //}
                    //else
                    //{
                        files.Add(filepath);
                   // }
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

