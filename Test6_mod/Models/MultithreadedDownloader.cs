using RestSharp;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Test6_mod.Models
{
    public class MultiDownloader
    {            
        /// <summary>
        /// Класс для параллельного скачивания данных
        /// </summary>
        public class ParallelDataDownloader
        {
            /// <summary>
            /// Директория для вывода результатов
            /// </summary>
            public static string OutputDirectory = "G:/OtherData/Demo1";

            /// <summary>
            /// Количество параллельных потоков, которые одновременно будут выполнять скачивание данных
            /// </summary>
            private int ParallelThreadsCount { get; set; }

            /// <summary>
            /// Список ссылок, HTML-код по которым надо скачать
            /// </summary>
            private ConcurrentQueue<string> LinksToDownload { get; set; }

            /// <summary>
            /// Создаёт новый объект класса ParallelDataDownloader
            /// </summary>
            /// <param name="ThreadsCount"></param>
            /// <param name="LinksToDownload"></param>
            public ParallelDataDownloader(int ThreadsCount, ConcurrentQueue<string> LinksToDownload)
            {
                this.ParallelThreadsCount = ThreadsCount;
                this.LinksToDownload = LinksToDownload;
            }

            /// <summary>
            /// Запускаем параллельное скачивание данных
            /// </summary>
            public void StartDownloading()
            {
                for (int i = 0; i < this.ParallelThreadsCount; i++)
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
                while (LinksToDownload.TryDequeue(out NextLinkToDownload))
                {
                    //Подготавливаем GET-запрос на скачивание страницы и выполняем скачивание
                    RestRequest request = new RestRequest(NextLinkToDownload);
                    IRestResponse DownloadResult = client.Execute(request);
                    string PageSourceCode = DownloadResult.Content;

                    //Создаём объект с результатами скачивания
                    WebsiteDownloadResult NextDownloadResult = new WebsiteDownloadResult();
                    NextDownloadResult.PageUrl = NextLinkToDownload;
                    NextDownloadResult.PageContent = PageSourceCode;
                    NextDownloadResult.SaveToFile();

                    //Отображаем в консоли информацию о том, что мы скачали некоторый контент некоторой страницы
                    string ConsoleMessage = string.Format("Content downloaded from URL = {0}", NextLinkToDownload);

                    //Усыпляем поток на 2 секунды
                    Thread.Sleep(1500);
                }
            }

        }

        /// <summary>
        /// Результат загрузки страницы с некоторого сайта
        /// </summary>
        class WebsiteDownloadResult
        {
            /// <summary>
            /// Ссылка на результат скачивания страницы
            /// </summary>
            public string PageUrl { get; set; }

            /// <summary>
            /// HTML-код скачанной страницы
            /// </summary>
            public string PageContent { get; set; }

            /// <summary>
            /// Сохраняет информацию в файл
            /// </summary>
            public void SaveToFile()
            {
                //Создаём случайное имя для файла
                string FileName = Guid.NewGuid().ToString();

                //Формируем полный путь к новому файлу для сохранения результатов
                string NewFileFullSavingPath = string.Format("{0}/{1}.txt", ParallelDataDownloader.OutputDirectory, FileName);

                //Записываем все данные в файл
                string ResultsToWrite = string.Format("URL:\r\n{0}\r\n\r\nContent:\r\n{1}", this.PageUrl, this.PageContent);
                System.IO.File.WriteAllText(NewFileFullSavingPath, ResultsToWrite);
            }
        }

    }
}
