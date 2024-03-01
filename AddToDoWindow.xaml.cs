using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace pr12
{

    /// <summary>
    /// Логика взаимодействия для AddToDo.xaml
    /// </summary>
    public partial class AddToDoWindow : Window
    {
        public AddToDoWindow()
        {
            InitializeComponent();

            descriptionToDo.Text = "Описания нет";
            dateToDo.SelectedDate = new DateTime(2024, 01, 10);
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.ToDos.Add(new ToDo(titleToDo.Text, dateToDo.DisplayDate, descriptionToDo.Text));
            titleToDo.Text = null;
            dateToDo.SelectedDate = new DateTime(2024, 01, 10);
            descriptionToDo.Text = "Описания нет";
            (this.Owner as MainWindow).listToDo.ItemsSource = null;
            (this.Owner as MainWindow).listToDo.ItemsSource = MainWindow.ToDos;
            this.Close();
        }
    }
}
