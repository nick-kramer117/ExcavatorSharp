using Test5_mod.Models;

namespace Test5_mod.ViewModels
{
    class HtmlSourceViewModel
    {
        public string DOC { get; set; }

        public HtmlSourceViewModel(string u)
        {
            PageModel p = new PageModel() { URL = u };
            DOC = new ParsModel(p.URL).Info;
        }
    }
}