using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using Test6_mod.Models;

namespace Test6_mod.ViewModels.UI
{
    public static class CreateCollectionURL
    {
        public static BindingList<ItemCollectionURL> CollectionURLs { get; private set; } = new BindingList<ItemCollectionURL>();

        private static void Add(string url)
        {
            CollectionURLs.Add(new ItemCollectionURL()
            {
                IsName = Guid.NewGuid().ToString(),
                IsURL = url,
                IsStatus = false
            });
        }

        static CreateCollectionURL()
        {
            StartPage.AddURL += StartPage_AddURL;
        }

        private static void StartPage_AddURL(object sender, Event.AddUrlEventArgs e)
        {
            Add(e.URL);
        }
    }
}