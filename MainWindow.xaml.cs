using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

namespace pr12
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static public List<ToDo> ToDos;
        public ToDoBar toDoBar = new ToDoBar();
        
        public MainWindow()
        {
            InitializeComponent();
            ToDos = new List<ToDo>
            {
                new ToDo("Приготовить покушать", new DateTime(2024,01,15), "Нет описания"),
                new ToDo("Поработать", new DateTime(2024,01,20), "Съездить на совещаение в Москву"),
                new ToDo("Отдохнуть", new DateTime(2024,02,01), "Съездить в отпуск в сочи")
            };
            
            listToDo.ItemsSource = ToDos;
            ToDoProgressBar.Maximum = listToDo.Items.Count;
            ToDoProgressBar.Value = CountCompleted();
            ToDoProgressBarTextBlock.Text = $"{CountCompleted()}/{listToDo.Items.Count}";
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            ToDos.Remove(listToDo.SelectedItem as ToDo);
            listToDo.ItemsSource = null;
            listToDo.ItemsSource = ToDos;

            EndToDo();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {

            AddToDoWindow addToDoWindow = new AddToDoWindow();
            addToDoWindow.Owner = this;
            addToDoWindow.Show();

            EndToDo();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if ((listToDo.SelectedItem as ToDo) != null)
            {
                (listToDo.SelectedItem as ToDo).Doing = true;
            }

            EndToDo();
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            if ((listToDo.SelectedItem as ToDo) != null)
            {
                (listToDo.SelectedItem as ToDo).Doing = false;
            }

            EndToDo();
        }
        
        private int CountCompleted()
        {
            int count = 0;

            for (int i = 0; i < listToDo.Items.Count; i++)
            {
                if (ToDos[i].Doing)
                {
                    count++;
                }
            }
            return count;
        }
        
        private void EndToDo()
        {
            ToDoProgressBar.Maximum = listToDo.Items.Count;
            ToDoProgressBar.Value = CountCompleted();

            ToDoProgressBarTextBlock.Text = $"{CountCompleted()}/{listToDo.Items.Count}";
        }
    }
}
