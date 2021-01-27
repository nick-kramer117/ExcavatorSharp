using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Test5_mod.ViewModels
{
    public static class JsonDatasViewModel
    {
        private static void WriteFile(string j)
        {
            File.WriteAllText("QurysModel.json", j);
        }

        public static string GetJsonString(this string url, bool w = false)
        {
            try
            {
                string j = JsonConvert.SerializeObject(new DatasQuerysViewModel(url));

                if (w) WriteFile(j);
                return j;
            }
            catch
            {
                return "Невозможно считать: Модель представления запросов данных! Что-то пошло не так.";
            }
        }
    }
}
