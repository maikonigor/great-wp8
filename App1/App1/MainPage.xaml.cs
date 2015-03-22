using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            // retrieve an avatar image from the Web
            string url = UrlTextBox.Text;
            HttpWebRequest request =
                (HttpWebRequest)HttpWebRequest.Create(url);
            request.BeginGetResponse(GetPageResponseCallBack, request);
            ContentGrid.Opacity = 0.5;
            ProgressBar.Visibility = Visibility.Visible;
        }

        void GetPageResponseCallBack(IAsyncResult result)
        {
            HttpWebRequest request = result.AsyncState as HttpWebRequest;
            if (request != null)
            {
                try
                {
                    WebResponse response = request.EndGetResponse(result);
                    Stream  receiveStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(receiveStream);
                    string page = reader.ReadToEnd();
                   Dispatcher.RunAsync(CoreDispatcherPriority.Normal, async () =>
                    {
                        BodyTextBlock.Text = page;
                        ProgressBar.Visibility = Visibility.Collapsed;
                        ContentGrid.Opacity = 1;
                    });
                    
                }
                catch (WebException e)
                {
                    Dispatcher.RunAsync(CoreDispatcherPriority.Normal, async () =>
                    {
                        BodyTextBlock.Text = "HResult: " + e.HResult + "\nMessage:" + e.Message;
                        ProgressBar.Visibility = Visibility.Collapsed;
                        ContentGrid.Opacity = 1;
                    });
                }

               
            }
        }
    }
}
