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
using Test6_mod.ViewModels.Exceptions;

namespace Test6_mod
{
    public partial class StartPage : Window
    {
        public static event EventHandler<AddInfoEventArgs> AddLogURL;
        public static event EventHandler<AddInfoEventArgs> AddLogFaultURL;
        public static event EventHandler<AddUrlEventArgs> AddURL;
        public static event EventHandler<StartScanUrlEventArgs> StartScan;
        public static event EventHandler<MessageScanUrlEventArgs> ScanFaultInfo;
        
        public string HtmlContent { get; set; }

        public StartPage()
        {
            InitializeComponent();

            CollectionURL.ItemsSource = CreateCollectionURL.CollectionURLs;
            LogTable.ItemsSource = CreateCollectionInfo.CollectionInfo;
            WorkWithPages.inWork = true;
        }

        private void AddUrlPage(object sender, MouseButtonEventArgs e)
        {
            if (txtURL.Text != "")
            {
                try
                {
                    AddURL(this, new AddUrlEventArgs(txtURL.Text));
                    AddLogURL(this, new AddInfoEventArgs());
                }
                catch(PathUrlExeption ex)
                {
                    AddLogFaultURL(this, new AddInfoEventArgs(ex.Message));
                }
                catch(Exception ex)
                {
                    AddLogFaultURL(this, new AddInfoEventArgs(ex.Message));
                }
            }
            txtURL.Text = "";
        }

        private void StartScanning(object sender, MouseButtonEventArgs e)
        {
            try
            {
                StartScan(this, new StartScanUrlEventArgs(CreateCollectionURL.CollectionURLs));
            }
            catch(MultiDownloadIsNullExeption ex)
            {
                ScanFaultInfo(this, new MessageScanUrlEventArgs(ex.Message));
            }
            catch(Exception ex)
            {
                ScanFaultInfo(this, new MessageScanUrlEventArgs(ex.Message));
            }
            txtURL.Text = "";
        }
    }
}