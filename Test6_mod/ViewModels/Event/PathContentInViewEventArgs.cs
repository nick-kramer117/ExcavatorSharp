using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test6_mod.ViewModels.Event
{
    public class PathContentInViewEventArgs : EventArgs
    {
        public string Msg { get; private set; }
        public string HTML { get; private set; }

        public PathContentInViewEventArgs(string m, string h)
        {
            Msg = m;
            HTML = h;
        }
    }
}
