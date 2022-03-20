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
using kursach.Models;

namespace kursach
{
    /// <summary>
    /// Логика взаимодействия для TaskAdd.xaml
    /// </summary>
    public partial class TaskAdd : Window
    {
        public user user3 { get; set; }
        public TaskAdd(user user2)
        {
            
            
            
            InitializeComponent();
            user3 = user2;
        }

        private void pas_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void TextBox_TextChanged1(object sender, TextChangedEventArgs e)
        {
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int stat = 0;
            if (Convert.ToDateTime(start.Text) > DateTime.Now)
            {
                stat = 1;
            }
            else if (Convert.ToDateTime(start.Text) <= DateTime.Now)
            {
                stat = 2;
            }
            DateTime now = DateTime.Now;
            task task = new task()
            {
                title = tas.Text.ToString(),
                start_time = Convert.ToDateTime(start.Text),
                end_time = Convert.ToDateTime(end.Text),
                annotation = annotation.Text.ToString(),
                purpose_time = now,
                user_id = user3.user_id,
                status_id = stat


            };
            Connection.Connect1on.task.Add(task);
            Connection.Connect1on.SaveChanges();
            MessageBox.Show("Задача успешно создана");
            this.Close();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void start_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
               
            }
            catch (System.FormatException)
            {

                    MessageBox.Show("Дата должна быть заполнена в формате \"ГГГГ-ММ-ДД ЧЧ:мм:CC\"");
            }
            
        }

        private void end_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Convert.ToDateTime(end.Text) <= Convert.ToDateTime(start.Text))
                {
                    MessageBox.Show("Дата конца должна быть позже даты начала");
                }
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Дата должна быть заполнена в формате \"ГГГГ-ММ-ДД ЧЧ:мм:CC\"");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
