using System.Collections.Generic;
using System.Linq;
using DragonQuiz;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

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
            CancelButton.IsEnabled = false;
            AddButton.IsEnabled = true;
            EditButton.IsEnabled = true;
            DeleteBotton.IsEnabled = true;
            SyncBotton.IsEnabled = true;
            PushBotton.IsEnabled = true;
            QList.IsEnabled = true;
        }

        private void OnForm_OffButtons()
        {
            txtTag.IsEnabled = true;
            txtContent.IsEnabled = true;
            txtAnswer.IsEnabled = true;
            txtComment.IsEnabled = true;
            OkButton.IsEnabled = true;
            CancelButton.IsEnabled = true;
            AddButton.IsEnabled = false;
            EditButton.IsEnabled = false;
            DeleteBotton.IsEnabled = false;
            SyncBotton.IsEnabled = false;
            PushBotton.IsEnabled = false;
            QList.IsEnabled = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Status.Text = "Add";
            OnForm_OffButtons();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (CheckOfIdiot())
            {
                var newQuestion = new DQuestion(0, txtContent.Text, txtAnswer.Text, txtComment.Text, txtTag.Text);
                switch (Status.Text)
                {
                    case "Add":
                        _listQuestions.Add(newQuestion);
                        break;
                    case "Edit":
                        _listQuestions[QList.SelectedIndex] = newQuestion;
                        break;
                    case "Sync":
                        foreach (var quest in DatabaseIO.GetPack(new DRequest(0, txtTag.Text)))
                        {
                            _listQuestions.Add(quest);
                        }
                        break;
                }

                QList.ItemsSource = _listQuestions;
                txtContent.Text = "";
                txtAnswer.Text = "";
                txtComment.Text = "";
                Status.Text = "";
                OffForm_OnButtons();
            }
            else
            {
                MessageBox.Show("You must full graphs: Tags, Content and Answer");
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (QList.SelectedIndex != -1)
            {
                Status.Text = "Edit";
                OnForm_OffButtons();

                txtTag.Text = _listQuestions[QList.SelectedIndex].Tags;
                txtContent.Text = _listQuestions[QList.SelectedIndex].Content;
                txtAnswer.Text = _listQuestions[QList.SelectedIndex].Answer;
                txtComment.Text = _listQuestions[QList.SelectedIndex].Comment;
            }
        }

        private void QList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void DeleteBotton_Click(object sender, RoutedEventArgs e)
        {
            if (QList.SelectedIndex != -1)
            {
                _listQuestions.RemoveAt(QList.SelectedIndex);
                QList.ItemsSource = _listQuestions;
            }
        }

        private bool CheckOfIdiot()
        {
            if ((txtTag.Text != "" && Status.Text == "Sync" )|| (txtContent.Text != "" && txtAnswer.Text != "" && txtTag.Text != ""))
            {
                return true;
            }

            return false;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            txtTag.Text = "";
            txtContent.Text = "";
            txtAnswer.Text = "";
            txtComment.Text = "";
            Status.Text = "";
            OffForm_OnButtons();
        }

        private void PushBotton_Click(object sender, RoutedEventArgs e)
        {
            if (_listQuestions.Count != 0)
            {
                DatabaseIO.PushQuestions(_listQuestions.ToList());
                _listQuestions.Clear();
                QList.ItemsSource = _listQuestions;
            }
        }

        private void SyncBotton_Click(object sender, RoutedEventArgs e)
        {
            txtTag.IsEnabled = true;
            Status.Text = "Sync";
            OkButton.IsEnabled = true;
            CancelButton.IsEnabled = true;
        }
    }
}
