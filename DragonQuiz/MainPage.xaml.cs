using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace DragonQuiz
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>

    public sealed partial class MainPage : Page
    {
        List<int> comboBoxItems = new List<int>();
        public MainPage()
        {
            this.InitializeComponent();
            // this.ApplicationTheme.Light;
            for (int i = 1; i <= 10; ++i)
            {
                comboBoxItems.Add(i);
            }

            numberBox.DataContext = this;
            numberBox.ItemsSource = comboBoxItems;
            numberBox.SelectedIndex = 2;

        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        void setQList(List<Integration.DQuestion> list)
        {
            QList.ItemsSource = list;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Integration.Request request = new Integration.Request();
            request.setRequest((int)numberBox.SelectedItem, tagBox.Text);
            var response = Integration.getPackage(request);
            setQList(response);
        }

        private void QList_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void QList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Question.Visibility = Windows.UI.Xaml.Visibility.Visible;
            Answer.Visibility = Windows.UI.Xaml.Visibility.Visible;
            Comment.Visibility = Windows.UI.Xaml.Visibility.Visible;
            FeedBack.IsEnabled = true;

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            FeedBack.IsEnabled = false;
        }
    }
}
