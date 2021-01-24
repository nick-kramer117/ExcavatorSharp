using RestSharp;
using System.Net;
using System;

namespace Test4
{
    class Program
    {
        static void Main(string[] args)
        {
            ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12; // <-- В коде ни где не используеться.

            RestClient Client = new RestClient();
            RestRequest Request = new RestRequest("https://nick-kramer117.github.io");
            IRestResponse Result = Client.Execute(Request);
            string PageHTMLSourceCode = Result.Content;

            if (Result.StatusCode != HttpStatusCode.OK)
            {
                Console.WriteLine("Невозможно скачать страницу. Что-то пошло не так.");
                return;
            }

            Console.Write(PageHTMLSourceCode);
            Console.ReadKey();
        }
    }
}