using System.Collections.Generic;

namespace LogCollectorConsole
{
    public class RefCollectorCreator
    {
        private Dictionary<int, List<string>> _cases;

        private void InitializePaths()
        {
            _cases = new Dictionary<int, List<string>>
            {
                {
                    //UpdateError
                    1, new List<string> 
                    {
                    "referent.ini",
                    "log\\Referent\\Referent.log",
                    "Referent_Setup.ini",
                    "Referent0.ini",
                    "TXUpdater_ggggmmnnhhmmss.log"
                    }
                },
                {
                    //ReportControl
                    2, new List<string> 
                    {
                    "log\\FormatCheck\\FormatCheck.log",
                    "Referent0.ini",
                    "referent.ini",
                    "log\\Referent\\Referent.log"
                    }
                },
                {
                    //ImportInDB
                    3, new List<string>
                    {
                    "referent.ini",
                    "log\\Referent\\Referent.log",
                    "Referent_Setup.ini",
                    "Referent0.ini",
                    }
                },
                {
                    //Other
                    4, new List<string>
                    {
                    "referent.ini",
                    "log\\Referent\\Referent.log",
                    "Referent_Setup.ini",
                    "Referent0.ini",
                    }
                }
            };
        }

        private List<string> GetValue(int key)
        {
            _cases.TryGetValue(key, out List<string> result);
            return result;
        }




        public RefCollectorCreator(int key)
        {
            InitializePaths();
            LogFilesPaths paths = default;
            paths.Files = GetValue(key);
            RefCollector refCollector = new RefCollector(paths);
        }

        public RefCollectorCreator()
        {

        }
    }
}


