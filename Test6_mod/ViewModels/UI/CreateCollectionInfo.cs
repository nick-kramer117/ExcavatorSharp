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
        public static event EventHandler<FinishScanEventArgs> CreateListIsUrlTrue;
        public static bool isWork { get; set; }

        public static BindingList<ItemCollectionInfo> CollectionInfo { get; private set; } = new BindingList<ItemCollectionInfo>();

        private static long id = 0;

        private static WorkWithPages Worker = new WorkWithPages();

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
            StartPage.StartScan += StartPage_StartScan;
            StartPage.ReaderFlautInfo += StartPage_ReaderFlautInfo;
            StartPage.AddInfoReadHTML += StartPage_AddInfoReadHTML;
            StartPage.AddInfoReadFinishHTML += StartPage_AddInfoReadFinishHTML;
        }

        private static void StartPage_AddInfoReadFinishHTML(object sender, AddInfoEventArgs e)
        {
            AddLog(e.Msg, StatusList[2]);
        }

        private static void StartPage_AddInfoReadHTML(object sender, AddInfoEventArgs e)
        {
            AddLog("Чтение файла...", StatusList[2]);
        }

        private static void StartPage_ReaderFlautInfo(object sender, AddInfoEventArgs e)
        {
            AddLog(e.Msg, StatusList[1]);
        }

        private static void Worker_ThreadStop(object sender, AddInfoEventArgs e)
        {
            AddLog("Страница просканированна: " + e.Msg, StatusList[2]);
        }

        private static void Worker_FinalThreadsAll(object sender, AddInfoEventArgs e)
        {
            AddLog("Сканирование завершено", StatusList[2]);
            Worker.ThreadStop -= Worker_ThreadStop;
            Worker.FinalThreadsAll -= Worker_FinalThreadsAll;
            CreateListIsUrlTrue(sender, new FinishScanEventArgs());
        }

        private static void StartPage_StartScan(object sender, StartScanUrlEventArgs e)
        {
            AddLog("Сканирование запущенно...", StatusList[2]);
            Worker = new WorkWithPages(e);
            Worker.ThreadStop += Worker_ThreadStop;
            Worker.FinalThreadsAll += Worker_FinalThreadsAll;
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