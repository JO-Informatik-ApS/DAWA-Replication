namespace JOInformatik.DawaReplication.Helpers
{
    public static class SettingsHelper
    {
        public static string SettingsAsString()
        {
            return
                $"DawaApiUri={Properties.Settings.Default.DawaApiUri}, " +
                $"DawaApiReadTimeoutInSeconds={Properties.Settings.Default.DawaApiReadTimeoutInSeconds}, " +
                $"TableInfoFile={Properties.Settings.Default.TableInfoFile}, " +
                $"UdtraekBulkSize={Properties.Settings.Default.UdtraekBulkSize}, " +
                $"UdtraekRowsMax={Properties.Settings.Default.UdtraekRowsMax}, " +
                $"WaitForUserInput={Properties.Settings.Default.WaitForUserInput}, " +
                $"DKStedBulkSize={Properties.Settings.Default.DKStedBulkSize}, " +
                $"DKStedDataStartPos={Properties.Settings.Default.DKStedDataStartPos}, " +
                $"DBCommandTimeoutInSeconds={Properties.Settings.Default.DBCommandTimeoutInSeconds}, " +
                $"TxidOverride={Properties.Settings.Default.TxidOverride}, " +
                $"RetryCount={Properties.Settings.Default.RetryCount}, " +
                $"RetryTimerInMinutes={Properties.Settings.Default.RetryTimerInMinutes}," +
                $"TempDataFolder={Properties.Settings.Default.TempDataFolderPath}," +
                $"DeleteLogsAfterDays={Properties.Settings.Default.DeleteLogsAfterDays}," +
                $"ArchiveLogsAfterDays={Properties.Settings.Default.ArchiveLogsAfterDays}," +
                $"DeleteOldArchivesAfterDays={Properties.Settings.Default.DeleteOldArchivesAfterDays}," +
                $"ActiveFixes={Properties.Settings.Default.ActiveFixes}," +
                $"ActiveFixes={Properties.Settings.Default.ActiveFixesListFileLocation}";
        }

    }
}
