using RestSharp;
using System;
using System.Collections.Concurrent;
using System.Threading;

namespace Test6_mod.Models
{
    public class MultiDownload : IDisposable
    {
        /// <summary>
        /// Директория для вывода результатов
        /// </summary>
        public static string OutputDirectory = "G:/";

        private int ThreadsCount { get; set; }

        private ConcurrentQueue<ItemCollectionURL> ListURL { get; set; }

        public MultiDownload(int c, in ConcurrentQueue<ItemCollectionURL> l)
        {
            ThreadsCount = c;
            ListURL = l;
        }

        public void StartDownloading()
        {
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
                }
                catch
                {

                }
                

                //Отображаем в консоли информацию о том, что мы скачали некоторый контент некоторой страницы
                //string Message = string.Format("Content downloaded from URL = {0}", page.Content);

                //Усыпляем поток на 2 секунды
                Thread.Sleep(1500);
            }
        }

        public void Dispose()
        {
            GC.Collect(0);
        }
    }
}