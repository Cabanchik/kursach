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
    /// Логика взаимодействия для LogWin.xaml
    /// </summary>
    public partial class LogWin : Window
    {
        public LogWin()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RegWin regWin = new RegWin();
            regWin.ShowDialog();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (stack.Visibility == Visibility.Hidden)
            {
                stack.Visibility = Visibility.Visible;
                
            }
            else
            {
                stack.Visibility = Visibility.Hidden;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                var user = Connection.Connect1on.user.Where(u => u.login == log.Text && u.password == pas.Text).FirstOrDefault();
                if (user != null)
                {

                    MainWindow mainWindow = new MainWindow(user);
                    mainWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Логин или пароль введен неверно!");
                }
            }
            catch (System.Data.Entity.Core.EntityException)
            {
                MessageBox.Show("Отсутсвует интернет соединение");                
            }
            
            
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                Connection.OffConnection.status123.Select(s => s);
            }
            catch (System.Data.Entity.Core.EntityException)
            {

                MessageBox.Show("Невозмонжо подключиться к базе");
            }
            offMainWin offMainWin = new offMainWin();
            offMainWin.ShowDialog();
            this.Close();
        }
    }
}
