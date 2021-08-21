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
					//Криптография
					1, new List<string>
                    {
                        "log\\Referent\\ref_crypto_",
                        "CPCrypto.ini",
                        "referent.ini",
                        "log\\Referent\\Referent.log",
                        "Referent_Setup.ini",
                        "Referent0.ini",
                    }
                },
                {
                    //Транспорт писем
                    2, new List<string>
                    {
                        "log\\Referent\\protocol_",
                        "log\\FormatCheck\\FormatCheck.log",
                        "log\\Referent\\Reftransport.log",
                        "referent.ini",
                        "log\\Referent\\Referent.log",
                        "Referent_Setup.ini",
                        "Referent0.ini"
                    }
                },

                {
                    //Обработка писем/Визуализация ЭДО
                    3, new List<string>
                    {
                        "log\\Referent\\ref_crypto_",
                        "referent.ini",
                        "log\\Referent\\Referent.log",
                        "Referent_Setup.ini",
                        "Referent0.ini",
                        "log\\FormatCheck\\FormatCheck.log",
                        "CPCrypto.ini",
                        "DocEngineError.log"
                    }
                },

                {
                    //Ошибки ЭДО
                    4, new List<string>
                    {
                        "log\\Referent\\ref_crypto_",
                        "referent.ini",
                        "log\\Referent\\Referent.log",
                        "Referent_Setup.ini",
                        "Referent0.ini",                       
                        "CPCrypto.ini"
                    }
                },
                {
					//Обновление
					5, new List<string>
                    {
                        "referent.ini",
                        "log\\Referent\\Referent.log",
                        "Referent_Setup.ini",
                        "Referent0.ini",                        
                    }
                },
                {
					//Выходной контроль
					6, new List<string>
                    {
                        "log\\FormatCheck\\FormatCheck.log",
                        "Referent0.ini",
                        "referent.ini",
                        "log\\Referent\\Referent.log"
                    }
                },
                {
					//Импорт файлов в базу данных 
					7, new List<string>
                    {
                        "referent.ini",
                        "log\\Referent\\Referent.log",
                        "Referent_Setup.ini",
                        "Referent0.ini",
                    }
                },
                
                {
					//Подключение по сети
					8, new List<string>
                    {
                        "referent.ini",
                        "log\\Referent\\Referent.log",
                        "Referent_Setup.ini",
                        "Referent0.ini",
                        "dbconnection.ini"
                    }
                },
                {
                    //Обновление базы данных 
                    9, new List<string>
                    {
                        "referent.ini",
                        "log\\Referent\\Referent.log",
                        "Referent_Setup.ini",
                        "Referent0.ini",
                        "DB\\dover.fdb",
                        "DB\\Backup"
                    }
                },
                {
                    //Ошибка базы данных
                    10, new List<string>
                    {                       
                        "referent.ini",
                        "log\\Referent\\Referent.log",
                        "Referent_Setup.ini",
                        "Referent0.ini",
                        "DB\\Backup"
                    }
                },
                {
                    // Остальные случаи
                    11, new List<string>
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


