using System;
using System.IO;
using System.IO.Compression;

namespace LogCollectorConsole
{
    public abstract class Collector
    {
        protected LogFilesPaths _paths;
        protected string _newDirectory;
        protected string _startedDirectory;
        protected bool CheckSpace()
        {
            _startedDirectory = Directory.GetCurrentDirectory();
            Console.WriteLine();
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
            CheckSpace();
            if (_paths.GetMissCounter() > 0)
            {
                Printer.Warnings.MissFiles();
            }
            if (!CheckSpace())
            {
                Printer.Errors.NotEnoughSpace();
                CopyToAnotherDisk();                                
            }
            else
            {
                CopyToNewDirectory();               
            }
            Archiving();
        }
        private void Archiving()
        {
            Printer.Question.WantToArchive();
            bool isArchiving = int.TryParse(Console.ReadLine(), out int choice);
            if (isArchiving&& choice>0 && choice <3)
            {
                switch (choice)
                {
                    case 1:
                        {
                            Printer.Info.StartingArchive();
                            string destPath = Path.Combine(Directory.GetCurrentDirectory(), "_IncidentLogs.zip");
                            ZipFile.CreateFromDirectory(_newDirectory, destPath);
                            Printer.Info.ArchiveFinish(_newDirectory,destPath);
                            break;
                        }
                    case 2:
                        {
                            break;
                        }                   
                }
            }
                     
        }
        private void CopyToNewDirectory()
        {
            Printer.Info.StartingCopy();
            string finalDir = CreateNewDirectory();            
            foreach (var file in _paths.GetFiles())
            {
                string startDir = Path.Combine(_startedDirectory, file);
                string destDir = Path.Combine(finalDir, file);
                File.Copy(startDir, destDir, true);
            }
            _newDirectory = finalDir;
            Printer.Info.CopyFinish(finalDir);
        }
        private void CopyToAnotherDisk()
        {

        }
        private string CreateNewDirectory()
        {
            string finalDirectory = Path.Combine(Directory.GetCurrentDirectory(), "_IncedentLogs");
            DirectoryInfo di = new DirectoryInfo(finalDirectory);
            di.Create();
            return finalDirectory;
        }
    }

    public class RefCollector : Collector
    {
        public RefCollector(LogFilesPaths paths)
        {
            _paths = paths;
            Collect();
        }
    }

    public class DocCollector : Collector
    {


    }
}
