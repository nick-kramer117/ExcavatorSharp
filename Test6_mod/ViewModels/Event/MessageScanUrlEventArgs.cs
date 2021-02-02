using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test6_mod.ViewModels.Event
{
    public class MessageScanUrlEventArgs
    {
        public string Msg { get; private set; }

        public MessageScanUrlEventArgs(in string msg)
        {
            Msg = msg;
        }
    }
}
