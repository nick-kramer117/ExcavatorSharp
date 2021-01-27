using System;
using Test5_mod.ViewModels;

namespace Test5_mod
{
    public class Program
    {
        static void Main(string[] args)
        {
            string url = "https://www.bestbuy.com/site/macbook-air-13-3-laptop-apple-m1-chip-8gb-memory-256gb-ssd-latest-model-gold/6418599.p?skuId=6418599&intl=nosplash";

            Console.WriteLine(url.GetJsonString()); // <-- Простое чтение Json объекта

            //Console.WriteLine(url.GetJsonString(true)); <-- Чтение в консоль Json объекта с записью в файл QuerysModel 

            Console.ReadKey();
        }
    }
}