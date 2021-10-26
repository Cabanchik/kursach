using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
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
            DateTime sosi = DateTime.Now.AddDays(2);
            view.ItemsSource = App.napominatel.task.Where(t=> t.user_id == user1.user_id && t.status_id == 2).ToList();
            view2.ItemsSource = App.napominatel.task.Where(t => t.user_id == user1.user_id && t.status_id == 1).ToList();
            view3.ItemsSource = App.napominatel.task.Where(t => t.user_id == user1.user_id && t.end_time <= sosi && t.end_time >= DateTime.Now).ToList();
            view4.ItemsSource = App.napominatel.task.Where(t => t.user_id == user1.user_id && t.status_id == 5).ToList();
            view5.ItemsSource = App.napominatel.task.Where(t => t.user_id == user1.user_id && t.status_id == 3).ToList();
            foreach (var item in App.napominatel.task)
            {
                if (item.end_time <= DateTime.Now)
                {
                    item.status_id = 5;
                }
            } 
        }

        public static int DTime(DateTime date)
        {
            TimeSpan dii = DateTime.Now - date;
            return dii.Days;
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var message = MessageBox.Show("Are you sure ?", "Alarm", MessageBoxButton.OKCancel);
            if (message == MessageBoxResult.OK)
            {
                Button delete = sender as Button;
                task deltask = delete.DataContext as task;
                App.napominatel.task.Remove(deltask);
                App.napominatel.SaveChanges();
            }
            DateTime sosi = DateTime.Now.AddDays(2);
            view.ItemsSource = App.napominatel.task.Where(t => t.user_id == user1.user_id && t.status_id == 2).ToList();
            view.UpdateLayout();
            view2.ItemsSource = App.napominatel.task.Where(t => t.user_id == user1.user_id && t.status_id == 1).ToList();
            view2.UpdateLayout();
            view3.ItemsSource = App.napominatel.task.Where(t => t.user_id == user1.user_id && t.end_time <= sosi && t.end_time >= DateTime.Now).ToList();
            view3.UpdateLayout();
            view4.ItemsSource = App.napominatel.task.Where(t => t.user_id == user1.user_id && t.status_id == 5).ToList();
            view4.UpdateLayout();
            view5.ItemsSource = App.napominatel.task.Where(t => t.user_id == user1.user_id && t.status_id == 3).ToList();
            view5.UpdateLayout();


        }
    }
}
