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
        //private bool CheckSpace()
        //{
        //    
        //    bool isEnough = default;
        //    FileInfo info = default;
        //    long filesSize = default;

        //    if (Directory.Exists(Path.Combine(_startedDirectory, "DB\\Backup")))
        //    {
        //        _logFiles.Files.Remove("DB\\Backup");

        //        DirectoryInfo info1 = new DirectoryInfo("DB");
        //        info1.
        //    }
        //    else
        //    {
        //        foreach (var path in _logFiles.Files)
        //        {
        //            info = new FileInfo(Path.Combine(Directory.GetCurrentDirectory(), path));
        //            filesSize += info.Length;
        //        }
        //    }
        //    DriveInfo[] drives = DriveInfo.GetDrives();
        //    foreach (var drive in drives)
        //    {
        //        if (Directory.GetDirectoryRoot(info.FullName).Equals(drive.Name))
        //        {
        //            isEnough = filesSize < drive.AvailableFreeSpace;
        //            break;
        //        }
        //    }
        //    return isEnough;
        //}
        private void CopyToAnotherDisk()
        {
            Printer.Warnings.Sorry();
            Console.ReadKey();
        }
        private void BackupCopy(string sourceDirectory, string targetDirectory)
        {
            DirectoryInfo diSource = new DirectoryInfo(sourceDirectory);
            DirectoryInfo diTarget = new DirectoryInfo(targetDirectory);

            CopyAll(diSource, diTarget);
        }

        private void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            Directory.CreateDirectory(target.FullName);
            foreach (FileInfo fi in source.GetFiles())
            {
                fi.CopyTo(Path.Combine(target.FullName, fi.Name), true);
            }

            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir =
                    target.CreateSubdirectory(diSourceSubDir.Name);
                CopyAll(diSourceSubDir, nextTargetSubDir);
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
                    Directory.CreateDirectory(PathSplit(destDir));
                    destDir = Path.Combine(finalDir, file);
                }
                if (file.Equals("DB\\Backup"))
                {
                    BackupCopy(startDir, destDir);
                }
                else
                {
                    File.Copy(startDir, destDir, true);
                }
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
                CopyToNewDirectory();
                Archiving();
                DeleteNewDirectory();
            }
        }
    }

    public class RefCollector : Collector
    {
        public RefCollector(LogFilesPaths paths)
        {
            _startedDirectory = Directory.GetCurrentDirectory();
            Collect(paths);
        }
    }

    public class DocCollector : Collector
    {


    }
}
