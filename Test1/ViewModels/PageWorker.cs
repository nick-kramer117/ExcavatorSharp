using Newtonsoft.Json;
using Test1.Models;

namespace Test1.ViewModels
{
    public class PageWorker
    {
        #region Сериализация
        /// <summary>
        /// Сериализация модели страници, в строку
        /// </summary>
        /// <param name="w"> Модель страници </param>
        /// <returns></returns>
        public static string Ser (WebPage w) 
        {
            return JsonConvert.SerializeObject(w);
        }
        #endregion

        #region Десериализация
        /// <summary>
        /// Десериализация строки в модель страници со взятием контента
        /// </summary>
        /// <param name="w"> Строка модели страници </param>
        /// <returns></returns>
        public static string GetContent(string w)
        {
            try
            {
                WebPage t = JsonConvert.DeserializeObject<WebPage>(w);
                return t.PageContent;
            }
            catch(JsonReaderException ex)
            {
                return ExeptionInfo();
            }
        }

        /// <summary>
        /// Десериализация строки в модель страници со взятием URL-адреса
        /// </summary>
        /// <param name="w"> Строка модели страници </param>
        /// <returns></returns>
        public static string GetURL(string w)
        {
            try
            {
                WebPage t = JsonConvert.DeserializeObject<WebPage>(w);
                return t.PageUrl;
            }
            catch (JsonReaderException ex)
            {
                return ExeptionInfo();
            }
        }
        #endregion

        #region Текст ошибки
        /// <summary>
        /// Текст ошибки
        /// </summary>
        /// <returns></returns>
        private static string ExeptionInfo()
        {
            return "Неизвестная модель страницы!";
        }
        #endregion
    }
}