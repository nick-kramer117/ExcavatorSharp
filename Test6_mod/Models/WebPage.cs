using System;
using System.IO;

namespace Test6_mod.Models
{
    public class WebPage
    {
        /// <summary>
        /// Статус скачинной страницы (true = страница скачена)
        /// </summary>
        public bool Satus { get; set; }
        
        /// <summary>
        /// Ссылка на результат скачивания страницы
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// HTML-код скачанной страницы
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Сохраняет информацию в файл
        /// </summary>
        public void SaveToFile()
        {
            //Создаём случайное имя для файла
            //string name = Guid.NewGuid().ToString();

            //Формируем полный путь к новому файлу для сохранения результатов
            //string path = string.Format("{0}/{1}.", MultiDownloader.OutputDirectory, name);

            //Записываем все данные в файл
            //string conten = string.Format("URL:\r\n{0}\r\n\r\nContent:\r\n{1}", Url, Content);
            
            //File.WriteAllText(path, conten);
        }
    }
}