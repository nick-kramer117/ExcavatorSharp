using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Test6_mod.Models;
using Test6_mod.ViewModels.Event;

namespace Test6_mod.ViewModels.UI
{
    public class ReaderListLoadPage
    {
        public EventHandler<PathContentInViewEventArgs> SetInfo;

        private string SourcHTML;

        private WebPage Web;

        public ReaderListLoadPage()
        {
            StartPage.GetHTML += StartPage_GetHTML;
        }

        private void StartPage_GetHTML(object sender, QueryReadFileEventArgs e)
        {
            SourcHTML = e.PathName.GetContentJSON();
            SetInfo(this, new PathContentInViewEventArgs("Файл:" + e.PathName + " был успешно прочитан...", SourcHTML));
        }
    }
}