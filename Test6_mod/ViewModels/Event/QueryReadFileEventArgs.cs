using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Controls;

using Test6_mod.Models;

namespace Test6_mod.ViewModels.Event
{
    public class QueryReadFileEventArgs : EventArgs
    {
        private ItemCollectionURL test = new ItemCollectionURL();

        public ItemCollectionURL itemCollection { get; private set; }
        public string PathName { get; private set; }

        public QueryReadFileEventArgs(IList addedItems)
        {
            try
            {
                test = (ItemCollectionURL)addedItems[0];
                itemCollection = test;
                PathName = test.IsName;
            }
            catch(Exception ex)
            {
                throw new Exception("Оштбка приобразования типов!", ex);
            }
        }
    }
}