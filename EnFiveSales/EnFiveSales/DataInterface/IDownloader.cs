using System;
namespace EnFiveSales.DataService
{
    public interface IDownloader
    {
        void DownloadFile(string url, string folder);
        event EventHandler<DownloadEventArgs> OnFileDownloaded;
        event EventHandler<DownloadProgressEventArgs> OnFileDownloadProgress;
    }

    public class DownloadEventArgs : EventArgs
    {
        public bool FileSaved = false;
        public string DownloadFilePath = "";
        public DownloadEventArgs(bool fileSaved,string downloadFilePath)
        {
            FileSaved = fileSaved;
            DownloadFilePath = downloadFilePath;
        }
    }

    public class DownloadProgressEventArgs : EventArgs
    {
        public int ProgressPercentage = 0;
        public long ReceivedBytes = 0;
        public long TotalBytes = 0;
        public DownloadProgressEventArgs(int progressPercentage,long receivedBytes,long totalBytes)
        {
            ProgressPercentage = progressPercentage;
            ReceivedBytes = receivedBytes;
            TotalBytes = totalBytes;
        }
    }
}
