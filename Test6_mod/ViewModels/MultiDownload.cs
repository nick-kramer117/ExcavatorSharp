using RestSharp;
using System.Collections.Concurrent;
using System.Threading;

using Test6_mod.Models;

namespace Test6_mod.ViewModels
{
    public class MultiDownload
    {
        /// <summary>
        /// Директория для вывода результатов
        /// </summary>
        public static string OutputDirectory = "G:/";

        /// <summary>
        /// Количество параллельных потоков, которые одновременно будут выполнять скачивание данных
        /// </summary>
        private int ThreadsCount { get; set; }

        /// <summary>
        /// Список ссылок, HTML-код по которым надо скачать
        /// </summary>
        private ConcurrentQueue<string> ListURL { get; set; }

        /// <summary>
        /// Создаёт новый объект класса ParallelDataDownloader
        /// </summary>
        /// <param name="c"></param>
        /// <param name="l"></param>
        public MultiDownload(int c, ConcurrentQueue<string> l)
        {
            ThreadsCount = c;
            ListURL = l;
        }

        /// <summary>
        /// Запускаем параллельное скачивание данных
        /// </summary>
        public void StartDownloading()
        {
            for (int i = 0; i < this.ThreadsCount; i++)
            {
                ThreadStart threadStarter = new ThreadStart(this.ThreadBody);
                Thread threadObject = new Thread(threadStarter);
                threadObject.Start();
            }
        }

        /// <summary>
        /// Тело потока, которое будет выполняться внутри каждого из потоков
        /// </summary>
        private void ThreadBody()
        {
            //Готовим клиент для скачивания веб-страниц и контейнер под ссылку, по которой в момент
            //будем производить скачивание
            RestClient client = new RestClient();
            
            string NextLinkToDownload = string.Empty;

            //Пока в буффере LinksToDownload есть ссылки, мы извлекаем их и скачиваем контент
            while (ListURL.TryDequeue(out NextLinkToDownload))
            {
                //Подготавливаем GET-запрос на скачивание страницы и выполняем скачивание
                RestRequest request = new RestRequest(NextLinkToDownload);
                IRestResponse DownloadResult = client.Execute(request);
                string PageSourceCode = DownloadResult.Content;

                //Создаём объект с результатами скачивания
                WebPage Page = new WebPage();
                Page.Url = NextLinkToDownload;
                Page.Content = PageSourceCode;
                Page.SaveToFile();

                //Отображаем в консоли информацию о том, что мы скачали некоторый контент некоторой страницы
                string Message = string.Format("Content downloaded from URL = {0}", NextLinkToDownload);

                //Усыпляем поток на 2 секунды
                Thread.Sleep(1500);
            }
        }
    }
}