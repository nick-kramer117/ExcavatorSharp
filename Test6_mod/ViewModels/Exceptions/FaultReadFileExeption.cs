using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test6_mod.ViewModels.Exceptions
{
    public class FaultReadFileExeption : Exception
    {
        public FaultReadFileExeption(string msg)
            : base(msg) { }

        public FaultReadFileExeption()
           : base("Файл с таким именем, не существует") { }
    }
}
