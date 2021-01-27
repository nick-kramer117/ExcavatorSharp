using System;
using HtmlAgilityPack;
using Test5_mod.Models;

namespace Test5_mod.ViewModels
{
    public class DatasQuerysViewModel
    {
        public QuerysModel Querys { get; private set; }

        private HtmlDocument doc = new HtmlDocument();

        public DatasQuerysViewModel(string url)
        {
            doc.LoadHtml(new HtmlSourceViewModel(url).DOC);

            Querys = new QuerysModel()
            {
                ItemName = doc.QuerySelector("h1.heading-5").InnerText,
                ItemPrice = doc.QuerySelector("div.price-box.pricing-lib-price-8-2104-2").InnerText
            };
        }
    }
}