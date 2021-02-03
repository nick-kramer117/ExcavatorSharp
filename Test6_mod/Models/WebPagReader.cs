using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using Test6_mod.ViewModels.Exceptions;

namespace Test6_mod.Models
{
    public static class WebPagReader
    {
        #region Десериализация
        public static string GetContentJSON(this string w)
        {
            try
            {
                w = w + ".json";
                WebPage t = JsonConvert.DeserializeObject<WebPage>(File.ReadAllText(w));      
                if (t.Satus)
                    return t.Content;
                else throw new FaultReadFileExeption("Ошибка чтения файл!");
            }
            catch (Exception)
            {
                throw new FaultReadFileExeption();
            }
        }
        #endregion
    }
}