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

        public void AddUrl(string url)
        {
            
            CollectionURLs.Add(new ItemCollectionURL()
            {
                IsName = Guid.NewGuid().ToString(),
                IsURL = url,
                IsStatus = false
            });
        }
    }
}
