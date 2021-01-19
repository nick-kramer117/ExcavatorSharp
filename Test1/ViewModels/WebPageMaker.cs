using Test1.Models;

namespace Test1.ViewModels
{
    public class WebPageMaker : WebPage
    {
        /// <summary>
        /// Сумма всех сделанных страниц
        /// </summary>
        public static int SumPage = 0;

        public WebPageMaker()
        {
            SumPage++;
        }
    }
}