using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

using Foundation;
using UIKit;
using EnFiveSales.DataService;
using Xamarin.Forms;

[assembly: Dependency(typeof(EnFiveSales.iOS.DependencyServices.IosDownloader))]
namespace EnFiveSales.iOS.DependencyServices
{
    public class IosDownloader : IDownloader
    {
        public event EventHandler<DownloadEventArgs> OnFileDownloaded;

        public event EventHandler<DownloadProgressEventArgs> OnFileDownloadProgress;

        string pathToNewFile;

        public void DownloadFile(string url, string folder)
        {
            string pathToNewFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), folder);
            Directory.CreateDirectory(pathToNewFolder);

            try
            {
                WebClient webClient = new WebClient();
                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                pathToNewFile = Path.Combine(pathToNewFolder, Path.GetFileName(url));
                webClient.DownloadFileAsync(new Uri(url), pathToNewFile);
            }
            catch (Exception ex)
            {
                if (OnFileDownloaded != null)
                    OnFileDownloaded.Invoke(this, new DownloadEventArgs(false, pathToNewFile));
            }
        }

        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                if (OnFileDownloaded != null)
                    OnFileDownloaded.Invoke(this, new DownloadEventArgs(false, pathToNewFile));
            }
            else
            {
                if (OnFileDownloaded != null)
                    OnFileDownloaded.Invoke(this, new DownloadEventArgs(true, pathToNewFile));
            }
        }

        private void ProgressChange(object sender, DownloadProgressChangedEventArgs e)
        {
            if (OnFileDownloadProgress != null)
            {
                OnFileDownloadProgress.Invoke(this, new DownloadProgressEventArgs(e.ProgressPercentage, e.BytesReceived, e.TotalBytesToReceive));
            }
        }
    }
}