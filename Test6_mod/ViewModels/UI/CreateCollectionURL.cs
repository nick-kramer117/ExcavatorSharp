using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using Test6_mod.Models;

namespace Test6_mod.ViewModels.UI
{
    public class CreateCollectionURL
    {
        public BindingList<ItemCollectionURL> CollectionURLs { get; private set; } = new BindingList<ItemCollectionURL>();

        private void Add(string url)
        {
            CollectionURLs.Add(new ItemCollectionURL()
            {
                IsName = Guid.NewGuid().ToString(),
                IsURL = url,
                IsStatus = false
            });
        }

        private void SetStatusTrue()
        {
            int i = -1;
            foreach (var item in CollectionURLs)
            {
                i += 1;
                if (!item.IsStatus)
                {
                    CollectionURLs[i].IsStatus = true;
                }
            }
        }

        public CreateCollectionURL()
        {
            StartPage.AddURL += StartPage_AddURL;
            CreateCollectionInfo.CreateListIsUrlTrue += CreateCollectionInfo_CreateListIsUrlTrue;
        }

        private void CreateCollectionInfo_CreateListIsUrlTrue(object sender, Event.FinishScanEventArgs e)
        {
            SetStatusTrue();
        }

        private void StartPage_AddURL(object sender, Event.AddUrlEventArgs e)
        {
            Add(e.URL);
        }
    }
}