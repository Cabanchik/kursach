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
    /// Логика взаимодействия для offMainWin.xaml
    /// </summary>
    public partial class offMainWin : Window
    {
       
        public offMainWin()
        {
            InitializeComponent();
            
            
            DateTime sosi = DateTime.Now.AddDays(1);
            foreach (var item in App.napominatelOff.task123)
            {
                if (item.end_time <= DateTime.Now)
                {
                    item.status_id = 5;
                }
            }
            App.napominatelOff.SaveChanges();
            view.ItemsSource = App.napominatelOff.task123.Where(t => t.status_id == 2).ToList();
            view2.ItemsSource = App.napominatelOff.task123.Where(t =>  t.status_id == 1).ToList();
            view3.ItemsSource = App.napominatelOff.task123.Where(t => t.status_id == 2 && t.end_time <= sosi && t.end_time >= DateTime.Now).ToList();
            view4.ItemsSource = App.napominatelOff.task123.Where(t => t.status_id == 5).ToList();
            view5.ItemsSource = App.napominatelOff.task123.Where(t => t.status_id == 3).ToList();


        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            offTaskAdd taskAdd = new offTaskAdd();
            taskAdd.ShowDialog();
            DateTime sosi = DateTime.Now.AddDays(1);
            view.ItemsSource = App.napominatelOff.task123.Where(t => t.status_id == 2).ToList();
            view.UpdateLayout();
            view2.ItemsSource = App.napominatelOff.task123.Where(t => t.status_id == 1).ToList();
            view2.UpdateLayout();
            view3.ItemsSource = App.napominatelOff.task123.Where(t => t.status_id == 2 && t.end_time <= sosi && t.end_time >= DateTime.Now).ToList();
            view3.UpdateLayout();
            view4.ItemsSource = App.napominatelOff.task123.Where(t => t.status_id == 5).ToList();
            view4.UpdateLayout();
            view5.ItemsSource = App.napominatelOff.task123.Where(t => t.status_id == 3).ToList();
            view5.UpdateLayout();

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var message = MessageBox.Show("Вы точно хотите удалить задачу?", "аЛерт", MessageBoxButton.OKCancel);
            if (message == MessageBoxResult.OK)
            {
                Button delete = sender as Button;
                task deltask = delete.DataContext as task;
                App.napominatel.task.Remove(deltask);
                App.napominatel.SaveChanges();
            }
            DateTime sosi = DateTime.Now.AddDays(1);
            view.ItemsSource = App.napominatelOff.task123.Where(t => t.status_id == 2).ToList();
            view.UpdateLayout();
            view2.ItemsSource = App.napominatelOff.task123.Where(t => t.status_id == 1).ToList();
            view2.UpdateLayout();
            view3.ItemsSource = App.napominatelOff.task123.Where(t => t.status_id == 2 && t.end_time <= sosi && t.end_time >= DateTime.Now).ToList();
            view3.UpdateLayout();
            view4.ItemsSource = App.napominatelOff.task123.Where(t => t.status_id == 5).ToList();
            view4.UpdateLayout();
            view5.ItemsSource = App.napominatelOff.task123.Where(t => t.status_id == 3).ToList();
            view5.UpdateLayout();


        }
        private void view_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var task123 = (sender as ListView).SelectedItem as task;

            EditTask editTask = new EditTask(task123);
            editTask.Show();

        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var s = MessageBox.Show("Вы точно хотите переместить задачу в выполненные?", "аЛерт", MessageBoxButton.OKCancel);
            if (s == MessageBoxResult.OK)
            {
                Button cont = sender as Button;
                task curr = cont.DataContext as task;
                curr.status_id = 3;
                App.napominatel.SaveChanges();
            }
            DateTime sosi = DateTime.Now.AddDays(1);
           
            view.ItemsSource = App.napominatelOff.task123.Where(t => t.status_id == 2).ToList();
            view.UpdateLayout();
            view2.ItemsSource = App.napominatelOff.task123.Where(t => t.status_id == 1).ToList();
            view2.UpdateLayout();
            view3.ItemsSource = App.napominatelOff.task123.Where(t => t.status_id == 2 && t.end_time <= sosi && t.end_time >= DateTime.Now).ToList();
            view3.UpdateLayout();
            view4.ItemsSource = App.napominatelOff.task123.Where(t => t.status_id == 5).ToList();
            view4.UpdateLayout();
            view5.ItemsSource = App.napominatelOff.task123.Where(t => t.status_id == 3).ToList();
            view5.UpdateLayout();

            
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            LogWin log = new LogWin();
            log.ShowDialog();
            this.Close();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            RegWin regWin = new RegWin();
            regWin.ShowDialog();
        }
    }
}
