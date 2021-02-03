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
    public class MultiDownload
    {
        public event EventHandler<FinishScanEventArgs> FinalThreadInfo;
        public event EventHandler<ThreadFinishInfoEventArgs> ThreadStopInfo;

        private SynchronizationContext sync;

        private int fc = 1;
        private int max = 0;
        private object _key = new object();

        private int ThreadsCount { get; set; }

        private ConcurrentQueue<ItemCollectionURL> ListURL { get; set; }

        public MultiDownload(int c, in ConcurrentQueue<ItemCollectionURL> l)
        {
            sync = SynchronizationContext.Current;
            ThreadsCount = c;
            ListURL = l;
            CreateCollectionInfo.isWork = true;
        }

        public void StartDownloading(int m)
        {
            max = m;

            for (int i = 0; i < ThreadsCount; i++)
            {
                //ThreadStart threadStarter = new ThreadStart(ThreadBody);
                //Thread threadObject = new Thread(threadStarter);
                //threadObject.Start();

                Thread threadObject = new Thread(ThreadBody);
                threadObject.Start(sync);
            }
        }

        private void ThreadBody(object param)
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
                    
                    sync.Send(SendEndDownloadPage, page.IsName);

                    Thread.Sleep(1500);
                }
                catch
                {

                }
            }

            lock (_key)
            {
                fc += 1;

                if (max == fc)
                {
                    max = 0;
                    fc = 1;

                    sync.Send(SendFinishAllDownload, this);
                }
            }
        }

        private void SendEndDownloadPage(object i)
        {
            ThreadStopInfo(this, new ThreadFinishInfoEventArgs(i.ToString()));
        }

        private void SendFinishAllDownload(object i)
        {
            FinalThreadInfo(this, new FinishScanEventArgs());
        }
    }
}