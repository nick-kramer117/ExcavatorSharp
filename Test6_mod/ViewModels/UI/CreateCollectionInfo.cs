using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using Test6_mod.Models;
using Test6_mod.ViewModels.Event;

namespace Test6_mod.ViewModels.UI
{
    public static class CreateCollectionInfo
    {
        public static bool isWork { get; set; }

        public static BindingList<ItemCollectionInfo> CollectionInfo { get; private set; } = new BindingList<ItemCollectionInfo>();

        private static long id = 0;

        private static void AddLog(string msg, string status)
        {
            id += 1;
            CollectionInfo.Add(new ItemCollectionInfo()
            {
                IsId = id,
                IsComent = msg,
                IsStatus = status
            });
        }

        private static readonly List<string> StatusList = new List<string>()
        {
            "Ошибка!",
            "Предуприждение.",
            "Информация..."
        };

        static CreateCollectionInfo()
        {
            StartPage.AddLogURL += StartPage_AddURL;
            StartPage.AddLogFaultURL += StartPage_FaultAddURL;
            StartPage.ScanFaultInfo += StartPage_ScanFaultInfo;
            StartPage.AddLogClicked_Scan += StartPage_AddLogClicked_Scan;
            MultiDownload.FinalThreadInfo += MultiDownload_FinalThreadInfo;
            MultiDownload.ThreadStopInfo += MultiDownload_ThreadStopInfo;
        }

        private static void StartPage_AddLogClicked_Scan(object sender, AddInfoEventArgs e)
        {
            AddLog("Сканирование сайтов запущенно...", StatusList[2]);
        }

        private static void MultiDownload_ThreadStopInfo(object sender, ThreadFinishInfoEventArgs e)
        {
            AddLog(e.Msg, StatusList[2]);
        }

        private static void MultiDownload_FinalThreadInfo(object sender, FinishScanEventArgs e)
        {
            AddLog("Все ссылки скаченны!", StatusList[2]);
        }

        private static void StartPage_ScanFaultInfo(object sender, MessageScanUrlEventArgs e)
        {
            AddLog(e.Msg, StatusList[0]);
        }

        private static void StartPage_FaultAddURL(object sender, AddInfoEventArgs e)
        {
            AddLog(e.Msg, StatusList[0]);
        }

        private static void StartPage_AddURL(object sender, AddInfoEventArgs e)
        {
            AddLog("Ссылка была добавлена.", StatusList[2]);
        }
    }
}