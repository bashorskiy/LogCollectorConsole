using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Resources;
using System.Linq;

namespace LogCollectorConsole
{
    public abstract class LogFilesPaths
    {
        protected ResourceSet _resSet;
        protected int _missCounter = default;
        protected List<string> _files = new List<string>();
        protected List<string> CheckFiles()
        {
            List<string> files = new List<string>();
            foreach (var filepath in _files)
            {
                if (Directory.Exists(filepath))
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

        public List<string> GetFiles()
        {
            return _files;
        }

        public int GetMissCounter()
        {
            return _missCounter;
        }

        protected List<string> SetFiles(ResourceSet resSet)
        {
            List<string> files = new List<string>();
            foreach (DictionaryEntry entry in resSet)
            {
                object value = entry.Value;
                files.Add(value.ToString());
            }
            return files;
        }

        protected void Intialize()
        {
            _files = SetFiles(_resSet);
            CheckFiles();
        }

        public virtual int GetChildrenCount()
        {
            System.Type thisType = GetType();
            var allDerivedTypes = thisType.Assembly.ExportedTypes.Where(t => thisType.IsAssignableFrom(t));
            return allDerivedTypes.Count();
        }
    }

   

}
