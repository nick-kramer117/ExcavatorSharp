using System;

namespace Test6_mod.ViewModels.Event
{
    public class AddInfoEventArgs : EventArgs 
    {
        public string Msg { get; private set; }

        public string Status { get; private set; }

        public AddInfoEventArgs() { }

        public AddInfoEventArgs(in string msg, in string status = "")
        {
            if(Msg != "") Msg = msg;
            if (status != "") Status = "";
        }
    }
}