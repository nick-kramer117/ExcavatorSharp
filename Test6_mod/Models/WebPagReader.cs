using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test6_mod.Models
{
    public class WebPagReader
    {
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
                throw new Exception();
            }
            catch (JsonReaderException ex)
            {
                throw new Exception();
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
                return t.Content;
            }
            catch (JsonReaderException ex)
            {
                throw new Exception();
            }
        }
        #endregion
    }
}
