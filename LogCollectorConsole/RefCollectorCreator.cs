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
                },
                {
                    //DatabaseConnection
                    5, new List<string>
                    {
                    "referent.ini",
                    "log\\Referent\\Referent.log",
                    "Referent_Setup.ini",
                    "Referent0.ini",
                    "dbconnection.ini"
                    }
                },
                {
                    //Cryptography
                    6, new List<string>
                    {
                    "log\\Referent\\ref_crypto_.log",
                    "referent.ini",
                    "log\\Referent\\Referent.log",
                    "Referent_Setup.ini",
                    "Referent0.ini",                    
                    "CPCrypto.ini",                   
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
            LogFilesPaths paths = new LogFilesPaths
            {
                Files = GetValue(key),
                Key = key
            };
            paths.CheckFiles();
            new RefCollector(paths);
        }
    }
}


