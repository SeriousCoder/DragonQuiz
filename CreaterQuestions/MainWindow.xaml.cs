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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Status.Text = "Add";
            txtTag.IsEnabled = true;
            txtContent.IsEnabled = true;
            txtAnswer.IsEnabled = true;
            txtComment.IsEnabled = true;
            OkButton.IsEnabled = true;
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
            }

            txtContent.Text = "";
            txtAnswer.Text = "";
            txtComment.Text = "";
            Status.Text = "";
            txtTag.IsEnabled = false;
            txtContent.IsEnabled = false;
            txtAnswer.IsEnabled = false;
            txtComment.IsEnabled = false;
            OkButton.IsEnabled = false;
        }


    }
}
