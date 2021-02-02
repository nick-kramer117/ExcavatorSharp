using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test6_mod.ViewModels.Event
{
    public class AddInfoEventArgs : EventArgs 
    {
        public string Msg { get; private set; }

        public string Status { get; private set; }

        public AddInfoEventArgs()
        {

        }

        public AddInfoEventArgs(string msg, string status = "")
        {
            if(Msg != "") Msg = msg;
            if (status != "") Status = "";
        }
    }
}