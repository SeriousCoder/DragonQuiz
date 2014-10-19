using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Newtonsoft.Json;
using System.Reflection;
using System.IO;
using WPClient.ViewModels;

namespace WPClient
{
    public partial class QuestionPage : PhoneApplicationPage
    {
        public QuestionPage()
        {
            InitializeComponent();
            Assembly ass = Assembly.GetExecutingAssembly();
            StreamReader ifile = new StreamReader(ass.GetManifestResourceStream("ololo.txt"), false);
            string s = ifile.ReadToEnd();
            var list = JsonConvert.DeserializeObject<List<DragonQuiz.DQuestion>>(s);
            ifile.Close();
            ifile.Dispose();
        }

        public void setList(List<DragonQuiz.DQuestion> list)
        {
            QList.DataContext = list;
            QList.ItemsSource = list;
        }

        private void MainLongListSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/DetailsPage.xaml?selectedItem=" + (QList.SelectedItem as ItemViewModel).ID, UriKind.Relative));
        }

    }
}