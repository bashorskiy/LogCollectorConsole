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
        
        private void BackupCopy(string sourceDirectory, string destDirectory)
        {
            DirectoryInfo source = new DirectoryInfo(sourceDirectory);
            DirectoryInfo dest = new DirectoryInfo(destDirectory);
            CopyAll(source, dest);
        }

        private void CopyAll(DirectoryInfo source, DirectoryInfo dest)
        {
            Directory.CreateDirectory(dest.FullName);
            foreach (FileInfo fi in source.GetFiles())
            {
                fi.CopyTo(Path.Combine(dest.FullName, fi.Name), true);
            }

            foreach (DirectoryInfo sourceSubDirectory in source.GetDirectories())
            {
                DirectoryInfo nextDestSubDirectory = dest.CreateSubdirectory(sourceSubDirectory.Name);
                CopyAll(sourceSubDirectory, nextDestSubDirectory);
            }
        }

        private void CopyToNewDirectory()
        {
            Printer.Info.StartingCopy();
            string finalDir = CreateNewDirectory();
            foreach (string file in _logFiles.Files)
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
