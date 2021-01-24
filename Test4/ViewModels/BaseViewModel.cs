using System;
using Test4.Models;

namespace Test4.ViewModels
{
    public class BaseViewModel
    {
        public string Result { get; set; }

        public BaseViewModel(string u)
        {
            PageModel p = new PageModel() { URL = u };
            Result = new ParsModel(p.URL).Info;
        }
    }
}