using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _7dtd_HELP
{
    public class WebHelper
    {
        public string Message { get; set; }

        public WebHelper(string message)
        {
            this.Message = message;
        }

        public Task DownloadFileAsync(string url, string savePath, string message = "")
        {
            var task = Task.Run(async () =>
            {
                if (message != "")
                    Message = message;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

                var request = HttpWebRequest.CreateHttp(url);
                request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:40.0) Gecko/20100101 Firefox/40.1";
                var response = (HttpWebResponse)(await request.GetResponseAsync());
                fileTotalSize = response.ContentLength;
                
                var webClient = new WebClient();
                webClient.DownloadProgressChanged += webClient_DownloadProgressChanged;
                await webClient.DownloadFileTaskAsync(new Uri(url), savePath);
            });

            return task;
        }

        private long fileTotalSize = -2;
        private long previewPercentage = -1;
        void webClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            if (previewPercentage != e.BytesReceived)
            {
                var percentage = (double)e.BytesReceived / fileTotalSize * 100.0;
                previewPercentage = e.BytesReceived;
                if(percentage > 0 && percentage < 100)
                    GlobalHelper.UpdateStatus?.Invoke(this, $"{Message} ({percentage:0.00}%)", (int)percentage);
            }
        }
    }
}