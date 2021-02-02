using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test6_mod.ViewModels.Exceptions
{
    public class MultiDownloadIsNullExeption : Exception
    {
        public MultiDownloadIsNullExeption(string msg)
            : base(msg) { }

        public MultiDownloadIsNullExeption()
           : base("Отсутствуют ссылки для сканирования.") { }
    }
}
