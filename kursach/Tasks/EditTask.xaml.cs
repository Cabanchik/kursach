using kursach.Models;
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

namespace kursach
{
    /// <summary>
    /// Логика взаимодействия для EditTask.xaml
    /// </summary>
    public partial class EditTask : Window
    {
      
        public EditTask(task task)
        {
            this.DataContext = task;
            InitializeComponent();
            string[] vs = new string[] { "Выполнена", "Начата", "Не выполнена",};
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
