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

using Test6_mod.ViewModels.UI;
using Test6_mod.ViewModels.Event;

namespace Test6_mod
{
    public partial class StartPage : Window
    {
        private CreateCollectionURL URLs = new CreateCollectionURL();

        public static event EventHandler<AddInfoEventArg> AddURL;
        public static event EventHandler<AddInfoEventArg> FaultAddURL;

        public string HtmlContent { get; set; }

        public StartPage()
        {
            InitializeComponent();

            CollectionURL.ItemsSource = URLs.CollectionURLs;
            LogTable.ItemsSource = CreateCollectionInfo.CollectionInfo;
        }

        private void CollectionInfo_ListChanged(object sender, ListChangedEventArgs e)
        {
            switch (e.ListChangedType)
            {
                case ListChangedType.ItemAdded:
                    
                    break;
            }
        }

        private void AddUrlPage(object sender, MouseButtonEventArgs e)
        {
            if (txtURL.Text != "")
            {
                try
                {
                    URLs.AddUrl(txtURL.Text);
                    AddURL(this, new AddInfoEventArg());
                }
                catch(Exception ex)
                {
                    FaultAddURL(this, new AddInfoEventArg());
                }
            }
            txtURL.Text = "";
        }

        private void StartScanning(object sender, MouseButtonEventArgs e)
        {
            txtURL.Text = "";
        }
    }
}