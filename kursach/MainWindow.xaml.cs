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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace kursach
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public user user1 { get; set; }
        public MainWindow(user user2)
        {
            InitializeComponent();
            user1 = user2;
            view.ItemsSource = App.napominatel.task.Where(t=> t.user_id == user1.user_id && t.status_id == 2).ToList();
            view2.ItemsSource = App.napominatel.task.Where(t => t.user_id == user1.user_id && t.status_id == 1).ToList();
            view3.ItemsSource = App.napominatel.task.Where(t => t.user_id == user1.user_id).ToList();
            view4.ItemsSource = App.napominatel.task.Where(t => t.user_id == user1.user_id).ToList();
            view5.ItemsSource = App.napominatel.task.Where(t => t.user_id == user1.user_id).ToList();
        }

        

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            TaskAdd taskAdd = new TaskAdd(user1);
            taskAdd.ShowDialog();
            view.ItemsSource = App.napominatel.task.Where(t => t.user_id == user1.user_id && t.status_id == 1).ToList();
            view.UpdateLayout();
            view2.ItemsSource = App.napominatel.task.Where(t => t.user_id == user1.user_id && t.status_id == 2).ToList();
            view2.UpdateLayout();

        }
    }
}
