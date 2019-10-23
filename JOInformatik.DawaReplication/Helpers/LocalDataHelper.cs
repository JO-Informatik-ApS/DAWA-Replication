using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading;

namespace JOInformatik.DawaReplication.Helpers
{
    public static class LocalDataHelper
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger("DawaReplication");

        public static void CleanUpHelper(int entityHistory, int logDays, int deleteZipAfterDays, int deleteLogsAfterDays)
        {
            var methodName = LoggingUtils.GetMethodName();
            var numberOfRecords = EntityStateHelper.CleanupOldEntityStateRecords(entityHistory);
            _logger.Info($"{methodName}: Cleaned up EntitystateHistory. Number of old entries deleted: {numberOfRecords}");

            // Archive old logs.
            var numberOfLogsArchived = ArchiveOldLogs(logDays, deleteZipAfterDays);
            _logger.Info($"{methodName}: Archived older log files. Number of logs older than {logDays} days archived: {numberOfLogsArchived}");

            // Delete old logs.
            var numberOfLogsDeleted = LocalDataHelper.DeleteOldLogs(deleteLogsAfterDays);
            _logger.Info($"{methodName}: Cleaned up Log files. Number of logs older than {deleteLogsAfterDays} days deleted: {numberOfLogsDeleted}");
        }

        public static int ArchiveOldLogs(int logDays, int zipDays)
        {
            int numberOfZipped = 0;

            // Get list of archives.
            var lastArchiveList = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "Logs\\").GetFiles()
                .Where(f => f.LastWriteTime > DateTime.Now.Subtract(TimeSpan.FromDays(logDays)) && f.Extension.ToLower() == ".zip")
                .OrderByDescending(f => f.LastWriteTime);

            // If there are no archives, or latest archive is older than the number of days for log archiving in settings, create archive.
            if (!lastArchiveList.Any() || (lastArchiveList.Any() && lastArchiveList.First().LastWriteTime <= DateTime.Now.Subtract(TimeSpan.FromDays(logDays))))
            {
                var list = (from f in new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "Logs\\").GetFiles()
                            where f.LastWriteTime < DateTime.Now.Subtract(TimeSpan.FromDays(logDays)) && f.Extension.ToLower() == ".log"
                            select f).ToList();
                numberOfZipped = list.Count;
                if (numberOfZipped > 0)
                {
                    var fromDate = list.First().Name.Split('.')[1].Substring(3);
                    var toDate = list.Last().Name.Split('.')[1].Substring(3);

                    using (FileStream zipToOpen = new FileStream(AppDomain.CurrentDomain.BaseDirectory + $"Logs\\Logs-{fromDate}-{toDate}.zip", FileMode.Create))
                    {
                        using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Update))
                        {
                            foreach (var file in list)
                            {
                                ZipArchiveEntry newEntry = archive.CreateEntry(file.Name);
                                using (StreamWriter writer = new StreamWriter(newEntry.Open()))
                                {
                                    writer.Write(file.OpenText().ReadToEnd());
                                }
                            }
                        }
                    }
                }
            }

            DeleteOldArchives(lastArchiveList, zipDays);
            return numberOfZipped;
        }

        public static void DeleteOldArchives(IOrderedEnumerable<FileInfo> lastArchiveList, int daysOld)
        {
            if (lastArchiveList == null)
            {
                throw new ArgumentNullException(nameof(lastArchiveList));
            }

            if (lastArchiveList.Any())
            {
                foreach (var zip in lastArchiveList)
                {
                    if (zip.LastWriteTime < DateTime.Now.Subtract(TimeSpan.FromDays(daysOld)))
                    {
                        zip.Delete();
                    }
                }
            }
        }

        public static int DeleteOldLogs(int deleteLogs)
        {
            int numberOfDeleted = 0;

            var list = (from f in new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "Logs\\").GetFiles()
                        where f.LastWriteTime < DateTime.Now.Subtract(TimeSpan.FromDays(deleteLogs))
                        && f.Extension.ToUpperInvariant() == ".LOG"
                        select f).ToList();

            numberOfDeleted = list.Count;
            try
            {
                list.ForEach(f => f.Delete());
            }
            catch
            {
                // HACK: Sleep if files used in ArchiveOldLogs are not released and try deleting old logs again.
                Thread.Sleep(5000);
                return DeleteOldLogs(deleteLogs);
            }

            return numberOfDeleted;
        }

        public static void MakeFolder(string path)
        {
            if (path == null)
            {
                throw new ArgumentNullException(nameof(path));
            }

            try
            {
                if (path.Equals("Temp"))
                {
                    path = AppDomain.CurrentDomain.BaseDirectory + path;
                }

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
            }
            catch
            {
                throw new Exception("Could not ensure data folders were created.");
            }
        }

        public static FileStream CreateTempFile(string filename)
        {
            var tempFileLocation = EntityManager.TempDataFolderPath + $"{filename}.~txt";
            return File.Create(tempFileLocation);
        }

        public static string RenameTempFile(string filename)
        {
            var tempFolder = EntityManager.TempDataFolderPath;
            var fileLocation = tempFolder + $"{filename}.txt";
            if (File.Exists(fileLocation))
            {
                File.Delete(fileLocation);
            }

            File.Move(tempFolder + $"{filename}.~txt", fileLocation);
            return fileLocation;
        }

        public static void RemoveTempFile(string filepath)
        {
            if (File.Exists(filepath))
            {
                File.Delete(filepath);
            }
        }
    }
}
