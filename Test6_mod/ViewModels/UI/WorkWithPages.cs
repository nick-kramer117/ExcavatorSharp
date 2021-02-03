using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Test6_mod.ViewModels.Exceptions;
using Test6_mod.Models;

namespace Test6_mod.ViewModels.UI
{
    public static class WorkWithPages
    {
        public static bool inWork { get; set; }

        static WorkWithPages()
        {
            ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12;
            StartPage.StartScan += StartPage_StartScan;
        }

        private static void StartPage_StartScan(object sender, Event.StartScanUrlEventArgs e)
        {
            using(MultiDownload md = new MultiDownload(e.ListURL.Count.GetCount(), e.ListURL))
            {
                int j = 0;
                foreach(var i in e.ListURL)
                {
                    if (!i.IsStatus)
                        j += 1;
                }

                md.StartDownloading(j);
            }
        }

        private static int GetCount(this int c)
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
    }
}