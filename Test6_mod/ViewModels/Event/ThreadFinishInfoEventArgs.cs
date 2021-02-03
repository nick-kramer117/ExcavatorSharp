using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test6_mod.ViewModels.Event
{
    public class ThreadFinishInfoEventArgs : EventArgs
    {
        public string Msg { get; private set; }

        public ThreadFinishInfoEventArgs(string namePage)
        {
            Msg = "Скачена страница: " + namePage;
        }
    }
}
