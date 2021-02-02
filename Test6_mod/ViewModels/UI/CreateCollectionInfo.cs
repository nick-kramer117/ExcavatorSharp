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
            StartPage.AddURL += StartPage_AddURL;
            StartPage.FaultAddURL += StartPage_FaultAddURL;
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

        private static void StartPage_FaultAddURL(object sender, AddInfoEventArg e)
        {
            AddLog("Ошибка при добавление URL!", StatusList[0]);
        }

        private static void StartPage_AddURL(object sender, AddInfoEventArg e)
        {
            AddLog("Добавлен URL адресс", StatusList[2]);
        }
    }
}