using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace LogCollectorConsole
{
    public abstract class Collector
    {
        protected LogFilesPaths _logFiles;
        protected string _newDirectory;
        protected string _startedDirectory;
        protected bool CheckSpace()
        {
            _startedDirectory = Directory.GetCurrentDirectory();
            Console.WriteLine();
            bool isEnough = default;
            FileInfo info = default;
            long filesSize = default;

            foreach (var path in _logFiles.Files)
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
        public void Collect(LogFilesPaths paths)
        {
            if (paths.GetMissCounter() > 0)
            {
                Printer.Warnings.MissFiles();
            }
            if (paths.Files.Count == 0)
            {
                Printer.Errors.MissAllFiles();
            }          
            else if (!CheckSpace())
            {
                Printer.Errors.NotEnoughSpace();
                _logFiles = paths;
                CopyToAnotherDisk();
            }
            else
            {
                _logFiles = paths;
                CopyToNewDirectory();              
            }

        }
        private void Archiving()
        {
            Printer.Question.WantToArchive();
            bool isArchiving = int.TryParse(Console.ReadLine(), out int choice);
            if (isArchiving && choice > 0 && choice < 3)
            {
                switch (choice)
                {
                    case 1:
                        {
                            Printer.Info.StartingArchive();
                            string destPath = Path.Combine(Directory.GetCurrentDirectory(), "_IncidentLogs.zip");
                            ZipFile.CreateFromDirectory(_newDirectory, destPath);
                            Printer.Info.ArchiveFinish(_newDirectory, destPath);
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

            foreach (var file in _logFiles.Files)
            {
                string startDir = Path.Combine(_startedDirectory, file);
                string destDir = Path.Combine(finalDir, file);
                if (!Directory.Exists(destDir))
                {                                           
                    string[] splittedStrings = destDir.Split('\\');
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < splittedStrings.Length-1; i++)
                    {
                        sb.Append(splittedStrings[i]);
                        sb.Append('\\');
                    }
                    destDir = sb.ToString();
                    Directory.CreateDirectory(destDir);
                    destDir = Path.Combine(finalDir, file);
                }
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
            Collect(paths);
        }
    }

    public class DocCollector : Collector
    {


    }
}
