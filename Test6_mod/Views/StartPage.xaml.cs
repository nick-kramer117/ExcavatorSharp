using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Windows;
using System.Windows.Input;
using System.ComponentModel;
using System.Xaml;

namespace Test6_mod
{
    public partial class StartPage : Window
    {
        public string HtmlContent { get; set; }

        public StartPage()
        {
            InitializeComponent();

            HtmlContent = "Test";

            DataContext = this;
        }
    }
}
