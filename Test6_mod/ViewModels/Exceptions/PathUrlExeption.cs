using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test6_mod.ViewModels.Exceptions
{
    public class PathUrlExeption : Exception
    {
        public PathUrlExeption(string msg) 
            : base(msg) { }

        public PathUrlExeption()
           : base("Ссылка некорректная! Проверьте правильный ввод ссылки...") { }
    }
}
