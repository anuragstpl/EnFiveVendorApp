using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using EnFiveSales.DataService;
using Xamarin.Forms;

[assembly: Dependency(typeof(EnFiveSales.Droid.DependencyServices.AndroidDownloader))]
namespace EnFiveSales.Droid.DependencyServices
{
    public class AndroidDownloader : IDownloader
    {
        public event EventHandler<DownloadEventArgs> OnFileDownloaded;

        public event EventHandler<DownloadProgressEventArgs> OnFileDownloadProgress;

        string pathToNewFile;

        public void DownloadFile(string url, string folder)
        {
            string pathToNewFolder = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.AbsolutePath, folder);
            Directory.CreateDirectory(pathToNewFolder);
            int count = 1;

            try
            {
                WebClient webClient = new WebClient();
                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChange);
                pathToNewFile = Path.Combine(pathToNewFolder, Path.GetFileName(url));
                while (File.Exists(pathToNewFile))
                {
                    string tempFileName = string.Format("{0}({1})", Path.GetFileNameWithoutExtension(url), count++);
                    pathToNewFile = Path.Combine(pathToNewFolder, tempFileName + Path.GetExtension(url));
                }
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
            if(OnFileDownloadProgress != null)
            {
                OnFileDownloadProgress.Invoke(this, new DownloadProgressEventArgs(e.ProgressPercentage, e.BytesReceived, e.TotalBytesToReceive));
            }
        }
    }
}