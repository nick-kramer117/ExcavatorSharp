using System;
using Test1.ViewModels;

namespace Test1
{
    class Program
    {
        #region Создание переменных
        //Создаю страницу 1
        static WebPageMaker wp1 = new WebPageMaker()
        {
            PageUrl = "https://google.com",
            PageContent = "<html>Hello world! I am Google!</html>"
        };
        //Создаю страницу 2
        static WebPageMaker wp2 = new WebPageMaker()
        {
            PageUrl = "https://habr.com",
            PageContent = "<html>Hello world! I am habr!</html>"
        };
        //Рандомный текст
        static string Test = "gfjdhfjwnjdne";
        #endregion

        static void Main(string[] args)
        {
            //Объект класса WebPage → Newtonsoft.JSON → Текстовая строка 
            string txt1 = PageWorker.Ser(wp1);
            string txt2 = PageWorker.Ser(wp2);

            Console.WriteLine("Страница1 txt1: " + txt1); 
            Console.WriteLine("Страница2 txt2: " + txt2);

            //Текстовая строка → Newtonsoft.JSON → Объект класса WebPage
            Console.WriteLine("Взятие контента из переменной txt1 - " + PageWorker.GetContent(txt1));
            Console.WriteLine("Взятие URL из переменной txt2 - " + PageWorker.GetURL(txt2));
            Console.WriteLine("Взятие URL из переменной Test - " + PageWorker.GetURL(Test));

            Console.WriteLine("Всего сделанно страниц - " + WebPageMaker.SumPage);

            Console.ReadLine();
        }
    }
}