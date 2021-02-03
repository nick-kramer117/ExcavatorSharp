using RestSharp;
using System;
using System.Collections.Concurrent;
using System.Threading;

using Test6_mod.ViewModels.Event;
using Test6_mod.ViewModels;
using System.Windows;
using Test6_mod.ViewModels.UI;

namespace Test6_mod.Models
{
    public class MultiDownload : IDisposable
    {
        public static event EventHandler<FinishScanEventArgs> FinalThreadInfo;
        public static event EventHandler<ThreadFinishInfoEventArgs> ThreadStopInfo;
        private static int fc = 0;
        private static int max = 0;
        private static object _key = new object();

        private int ThreadsCount { get; set; }

        private ConcurrentQueue<ItemCollectionURL> ListURL { get; set; }

        public MultiDownload(int c, in ConcurrentQueue<ItemCollectionURL> l)
        {
            ThreadsCount = c;
            ListURL = l;
            CreateCollectionInfo.isWork = true;
        }

        public void StartDownloading(int m)
        {
            max = m;

            for (int i = 0; i < ThreadsCount; i++)
            {
                ThreadStart threadStarter = new ThreadStart(ThreadBody);
                Thread threadObject = new Thread(threadStarter);
                threadObject.Start();
            }
        }

        private void ThreadBody()
        {      
            RestClient client = new RestClient();

            ItemCollectionURL page = new ItemCollectionURL();

            while (ListURL.TryDequeue(out page))
            {
                RestRequest request = new RestRequest(page.IsURL);
                IRestResponse DownloadResult = client.Execute(request);

                try
                {
                    WebPageWriter pw = new WebPageWriter();
                    WebPage w = new WebPage()
                    {
                        Satus = true,
                        Content = DownloadResult.Content
                    };

                    pw.SaveToFileJSON(page, w);

                    Thread.Sleep(1500);
                }
                catch
                {

                }
            }

            lock (_key)
            {
                fc += 1;

               // ThreadStopInfo(this, new ThreadFinishInfoEventArgs(page.IsName));

                if (max == fc)
                {
                    max = 0;
                    fc = 0;
                  //  FinalThreadInfo(this, new FinishScanEventArgs());
                }
            }
        }

        public void Dispose()
        {
            GC.Collect(0);
        }
    }
}