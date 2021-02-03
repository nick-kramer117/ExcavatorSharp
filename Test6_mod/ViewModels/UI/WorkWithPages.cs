using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


using System.Windows.Threading;

using Test6_mod.ViewModels.Exceptions;
using Test6_mod.ViewModels.Event;
using Test6_mod.Models;

namespace Test6_mod.ViewModels.UI
{
    public class WorkWithPages 
    {
        public event EventHandler<AddInfoEventArgs> ThreadStop;
        public event EventHandler<AddInfoEventArgs> FinalThreadsAll;

        private MultiDownload md;

        private int GetCount(int c)
        {
            switch (c)
            {
                case 0:
                    throw new MultiDownloadIsNullExeption();

                case 1:
                    return 1;

                case 2:
                    return 2;

                case 3:
                    return 3;

                default:
                    return 3;
            }
        }

        private void StartPage_StartScan(in StartScanUrlEventArgs e)
        {
            md = new MultiDownload(GetCount(e.ListURL.Count), e.ListURL);

            int j = 0;

            foreach (var i in e.ListURL)
            {
                if (!i.IsStatus)
                    j += 1;
            }

            md.StartDownloading(j);
        }

        public WorkWithPages() { }

        public WorkWithPages(StartScanUrlEventArgs e)
        {
            StartPage_StartScan(e);
            md.ThreadStopInfo += MultiDownload_ThreadStopInfo;
            md.FinalThreadInfo += Md_FinalThreadInfo;
        }

        private void Md_FinalThreadInfo(object sender, FinishScanEventArgs e)
        {
            FinalThreadsAll(this, new AddInfoEventArgs());
        }

        private void MultiDownload_ThreadStopInfo(object sender, ThreadFinishInfoEventArgs e)
        {
            ThreadStop(this, new AddInfoEventArgs(e.Msg));
        }
    }
}