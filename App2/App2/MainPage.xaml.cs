using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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

namespace App2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        DojoLib.MagicNumberCreator creator;
        
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
            creator = new DojoLib.MagicNumberCreator();
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

        private async void Create_New(object sender, RoutedEventArgs e)
        {
            btCreate.Visibility = Visibility.Collapsed;
            btCancel.Visibility = Visibility.Visible;
            ProgressBar.Visibility = Visibility.Visible;

            int magicNumber = await createMagicNumberTask();
           
            /*
            ProgressBar.Visibility = Visibility.Collapsed;
            btCancel.Visibility = Visibility.Collapsed;
            btCreate.Visibility = Visibility.Visible;
            */

            numberBox.Text = "" + magicNumber;
        }

        private void Cancel_Number(object sender, RoutedEventArgs e)
        {
            ProgressBar.Visibility = Visibility.Collapsed;
            btCreate.Visibility = Visibility.Visible;
            btCancel.Visibility = Visibility.Collapsed;
        }

        async Task<int> createMagicNumberTask()
        {
            return creator.CreateMagicNumber();

            //return creator.CreateMagicNumber();  
            
        }
    }
}
