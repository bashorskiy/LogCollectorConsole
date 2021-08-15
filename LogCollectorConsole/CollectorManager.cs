using System;
using System.IO;

namespace LogCollectorConsole
{
    public class CollectorManager
    {
        private bool _isRef;
        private bool _isExist = true;

        public CollectorManager()
        {
            CheckingProgram();
            DistributeObjects();
        }

        private void CheckingProgram()
        {
            string refPath = Path.Combine(Directory.GetCurrentDirectory(), "Referent.exe");
            string docPath = Path.Combine(Directory.GetCurrentDirectory(), "Client\\DoclinerSingle.exe");
            if (File.Exists(refPath))
            {
                Console.WriteLine("Найден Референт");
                _isRef = true;
            }
            else if (File.Exists(docPath))
            {
                Console.WriteLine("Найден Доклайнер");
                _isRef = false;
            }
            else
            {
                _isExist = false;
            }
        }

        private void DistributeObjects()
        {
            if (!_isExist)
            {
                Console.WriteLine("Не найдена программа! \n" +
                   "Пожалуйста, переместите данную программу в папку с Референтом(в ней должен быть файл Referent.exe) \n" +
                   "Или в корневую папку Доклайнера (в ней должны быть папки Client, DB и Server) \n" +
                   "И перезапустите LogCollector");
                Console.ReadLine();
            }
            else if (_isRef)
            {
                RefLogs reflogs = new RefLogs();
                while (true)
                {
                    Printer.PrintRefMenu();
                    bool isChoice = int.TryParse(Console.ReadLine(), out int key);
                    if (isChoice && key > 0 && key < reflogs.GetChildrenCount())
                    {
                        reflogs = null;
                        RefCollectorCreator creator = new RefCollectorCreator(key);
                        break;
                    }
                    else
                    {
                        Printer.ErrorPrintRefMenu();
                    }
                }
            }
            else if (!_isRef)
            {

            }
        }
    }

    public class RefCollectorCreator
    {
        public RefCollectorCreator(int key)
        {
            LogFilesPaths paths = null;
            switch (key)
            {
                case 1:
                    {
                        paths = new LogUpdateError();                        
                        break;
                    }
                case 2:
                    {
                        paths = new LogReportControl();
                        break;
                    }
                case 3:
                    {
                        paths = new LogImportInDB();
                        break;
                    }
                case 4:
                    {
                        paths = new LogOther();
                        break;
                    }                   
            }
            RefCollector refCollector = new RefCollector(paths);
        }
    }


    public abstract class Collector
    {
        protected LogFilesPaths _paths;

    }


    public class RefCollector : Collector
    {       
        public RefCollector(LogFilesPaths paths)
        {
            _paths = paths;           
        }

        private bool CheckSpace()
        {
            bool isEnough = default;
            FileInfo info = default;
            long filesSize = default;

            foreach (var path in _paths.GetFiles())
            {              
                info = new FileInfo(Path.Combine(Directory.GetCurrentDirectory(), path));
                filesSize += info.Length;
            }          

            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (var drive in drives)
            {
                if (Directory.GetDirectoryRoot(info.FullName).Equals(drive.Name))
                {
                    isEnough = filesSize < drive.AvailableFreeSpace;
                    break;
                }
            }
            return isEnough;
        }

        public void Collect()
        {
            string finalDirectory = Directory.GetCurrentDirectory();
            if(!CheckSpace())
            {
                Printer.ErrorNotEnoughSpace();

            }
        }

        private void Archiving()
        {

        }

        private void CopyToAnotherDisk()
        {

        }

    }

    public class DocCollector : Collector
    {


    }


}
