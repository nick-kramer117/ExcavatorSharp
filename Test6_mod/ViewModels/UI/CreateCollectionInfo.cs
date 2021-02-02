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
        public static BindingList<ItemCollectionInfo> CollectionInfo { get; private set; } = new BindingList<ItemCollectionInfo>();

        static CreateCollectionInfo()
        {
            StartPage.AddLogURL += StartPage_AddURL;
            StartPage.AddLogFaultURL += StartPage_FaultAddURL;
        }

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