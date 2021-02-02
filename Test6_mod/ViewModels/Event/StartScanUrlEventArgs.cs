using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test6_mod.Models;

namespace Test6_mod.ViewModels.Event
{
    public class StartScanUrlEventArgs : EventArgs
    {
        public ConcurrentQueue<ItemCollectionURL> ListURL { get; private set; } = new ConcurrentQueue<ItemCollectionURL>();

        public StartScanUrlEventArgs(in BindingList<ItemCollectionURL> listURL)
        {
            CreateUrlList(listURL);
        }

        private void CreateUrlList(in BindingList<ItemCollectionURL> itemCollectionURLs)
        {
            foreach(ItemCollectionURL item in itemCollectionURLs)
            {
                if (!item.IsStatus)
                {
                    ListURL.Enqueue(item);
                }                   
            }
        }
    }
}