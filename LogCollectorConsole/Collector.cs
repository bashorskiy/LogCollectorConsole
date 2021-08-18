using System;
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

        private string CreateUnicPath(string destPath)
        {
            destPath = PathSplit(destPath);
            Random r = new Random();
            string unic = r.Next().ToString();
            destPath = Path.Combine(destPath, unic + "_IncidentLogs.zip");
            return destPath;
        }
        private bool CheckSpace()
        {
            _startedDirectory = Directory.GetCurrentDirectory();
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
        private void CopyToAnotherDisk()
        {
            Printer.Warnings.Sorry();
            Console.ReadKey();
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
                    Directory.CreateDirectory(PathSplit(destDir));
                    destDir = Path.Combine(finalDir, file);
                }                
                File.Copy(startDir, destDir, true);
            }
            _newDirectory = finalDir;
            Printer.Info.CopyFinish(finalDir);
        }
        private string CreateNewDirectory()
        {
            string finalDirectory = Path.Combine(Directory.GetCurrentDirectory(), "_IncedentLogs");
            DirectoryInfo di = new DirectoryInfo(finalDirectory);
            di.Create();
            return finalDirectory;
        }
        private string PathSplit(string destDir)
        {
            string[] splittedStrings = destDir.Split('\\');
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < splittedStrings.Length - 1; i++)
            {
                sb.Append(splittedStrings[i]);
                sb.Append('\\');
            }
            return sb.ToString();
        }
        private void Archiving()
        {
            Printer.Questions.WantToArchive();
            bool isArchiving = int.TryParse(Console.ReadLine(), out int choice);
            if (isArchiving && choice > 0 && choice < 3)
            {
                switch (choice)
                {
                    case 1:
                        {
                            Printer.Info.StartingArchive();
                            string destPath = Path.Combine(Directory.GetCurrentDirectory(), "_IncidentLogs.zip");
                            while (File.Exists(destPath))
                            {
                                destPath = CreateUnicPath(destPath);
                            }
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
        private void DeleteNewDirectory()
        {
            Printer.Questions.WantToDelete();
            bool isDeleting = int.TryParse(Console.ReadLine(), out int choice);
            if (isDeleting && choice > 0 && choice < 3)
            {
                switch (choice)
                {
                    case 1:
                        {
                            Printer.Info.StartingDelete();
                            Directory.Delete(_newDirectory, true);
                            Printer.Info.DeleteFinish(_newDirectory);
                            break;
                        }
                    case 2:
                        {
                            break;
                        }
                }
            }

        }

        public void Collect(LogFilesPaths paths)
        {
            _logFiles = paths;
            if (paths.Files.Count == 0)
            {
                Printer.Errors.MissAllFiles();
            }
            else
            {
                if (paths.MissCounter > 0)
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
                DeleteNewDirectory();
            }
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
