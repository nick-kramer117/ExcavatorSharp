using System;
using Test4.ViewModels;

namespace Test4
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "https://nick-kramer117.github.io";

            Console.Write(new BaseViewModel(url).Result);

            Console.ReadKey();
        }
    }
}