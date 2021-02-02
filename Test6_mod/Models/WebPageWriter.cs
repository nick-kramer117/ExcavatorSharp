using Newtonsoft.Json;
using System;
using System.IO;

namespace Test6_mod.Models
{
    public class WebPageWriter
    {
        #region Сериализация
        /// <summary>
        /// Сериализация модели страници, в строку
        /// </summary>
        /// <param name="w"> Модель страници </param>
        /// <returns></returns>
        public void SaveToFileJSON(in ItemCollectionURL c, in WebPage w)
        {
            string path = c.IsName + ".json";
            File.WriteAllText(path, JsonConvert.SerializeObject(w));
        }
        #endregion
    }
}