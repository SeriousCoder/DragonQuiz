using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DragonQuiz;

namespace CreaterQuestions
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<DQuestion> _listQuestions;

        public MainWindow()
        {
            InitializeComponent();

            _listQuestions = new ObservableCollection<DQuestion>();

            QList.DataContext = this._listQuestions;
            QList.ItemsSource = _listQuestions;
        }

        private void OffForm_OnButtons()
        {
            txtTag.IsEnabled = false;
            txtContent.IsEnabled = false;
            txtAnswer.IsEnabled = false;
            txtComment.IsEnabled = false;
            OkButton.IsEnabled = false;
            AddBotton.IsEnabled = true;
            EditButton.IsEnabled = true;
            DeleteBotton.IsEnabled = true;
            SyncBotton.IsEnabled = true;
            PushBotton.IsEnabled = true;
        }

        private void OnForm_OffButtons()
        {
            txtTag.IsEnabled = true;
            txtContent.IsEnabled = true;
            txtAnswer.IsEnabled = true;
            txtComment.IsEnabled = true;
            OkButton.IsEnabled = true;
            AddBotton.IsEnabled = false;
            EditButton.IsEnabled = false;
            DeleteBotton.IsEnabled = false;
            SyncBotton.IsEnabled = false;
            PushBotton.IsEnabled = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Status.Text = "Add";
            OnForm_OffButtons();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            switch (Status.Text)
            {
                case "Add":
                    var newQuestion = new DQuestion(0, txtContent.Text, txtAnswer.Text, txtComment.Text, txtTag.Text);
                    _listQuestions.Add(newQuestion);
                    QList.ItemsSource = _listQuestions;
                    break;
                //case "Edit":

            }

            txtContent.Text = "";
            txtAnswer.Text = "";
            txtComment.Text = "";
            Status.Text = "";
            OffForm_OnButtons();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Status.Text = "Edit";
            OnForm_OffButtons();
        }


    }
}
