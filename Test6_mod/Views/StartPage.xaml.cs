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

using System.Net;
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
        private CreateCollectionURL URLs;
        private static ReaderListLoadPage Reader;
        public static event EventHandler<AddInfoEventArgs> AddLogURL;
        public static event EventHandler<AddInfoEventArgs> AddLogFaultURL;
        public static event EventHandler<AddInfoEventArgs> AddInfoReadHTML;
        public static event EventHandler<AddInfoEventArgs> AddInfoReadFinishHTML;
        public static event EventHandler<AddUrlEventArgs> AddURL;
        public static event EventHandler<StartScanUrlEventArgs> StartScan;
        public static event EventHandler<MessageScanUrlEventArgs> ScanFaultInfo;
        public static event EventHandler<QueryReadFileEventArgs> GetHTML;
        public static event EventHandler<AddInfoEventArgs> ReaderFlautInfo;
    
        public StartPage()
        {
            InitializeComponent();
            ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12;

            URLs = new CreateCollectionURL();
            CollectionURL.ItemsSource = URLs.CollectionURLs;
            URLs.CollectionURLs.ListChanged += CollectionURLs_ListChanged;

            LogTable.ItemsSource = CreateCollectionInfo.CollectionInfo;
            
            CreateCollectionInfo.CollectionInfo.ListChanged += CollectionInfo_ListChanged;

            Reader = new ReaderListLoadPage();
            Reader.SetInfo += SetContent;
        }

        private void SetContent(object sender, PathContentInViewEventArgs e)
        {
            HtmlContent.Text = e.HTML;
            AddInfoReadFinishHTML(this, new AddInfoEventArgs(e.Msg));
        }

        private void CollectionURLs_ListChanged(object sender, ListChangedEventArgs e)
        {
            switch (e.ListChangedType)
            {
                case ListChangedType.ItemChanged:
                    if (!btnScan.IsEnabled && !btnAdd.IsEnabled)
                    {
                        btnScan.IsEnabled = true;
                        btnAdd.IsEnabled = true;
                        CollectionURL.IsEnabled = true;
                    }
                    CollectionURL.Items.Refresh();
                    break;
            }
        }

        private void CollectionInfo_ListChanged(object sender, ListChangedEventArgs e)
        {
            switch (e.ListChangedType)
            {
                case ListChangedType.ItemAdded:
                    LogTable.ItemsSource = CreateCollectionInfo.CollectionInfo;
                    DataContext = this;
                    break;
            }
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
                btnScan.IsEnabled = false;
                btnAdd.IsEnabled = false;
                CollectionURL.IsEnabled = false;
                StartScan(this, new StartScanUrlEventArgs(URLs.CollectionURLs));
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

        private void CollectionURL_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                AddInfoReadHTML(this, new AddInfoEventArgs());
                GetHTML(this, new QueryReadFileEventArgs(e.AddedItems));
            }
            catch(FaultReadFileExeption ex)
            {
                ReaderFlautInfo(this, new AddInfoEventArgs(ex.Message));
            }    
        }
    }
}