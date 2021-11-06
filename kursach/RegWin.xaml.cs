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
    /// Логика взаимодействия для RegWin.xaml
    /// </summary>
    public partial class RegWin : Window
    {
        public RegWin()
        {
            InitializeComponent();
            var genda = App.napominatel.gender.Select(g => g.title).ToList();
            
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_2(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int ass = 0;
            if (sex2.IsChecked == true)
            {
               ass = 2;
            }
            else if (sex.IsChecked == true)
            {
                ass = 1;
            }
            user user = new user()
            {
                name = name.Text.ToString(),
                surname = surname.Text.ToString(),
                gender_id = ass,
                login = log.Text.ToString(),
                password = pas.Text.ToString(),
                birth_date = dr.SelectedDate

            };
            try
            {
                
                App.napominatel.user.Add(user);
                App.napominatel.SaveChanges();
                MessageBox.Show("РЕГИСТРАЦИЯ ПРОШЛА УСПЕШНО");
                this.Close();

            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException)
            {

                MessageBox.Show("Данный логин уже занят");
            }
            
            
        }

        private void sex_Checked(object sender, RoutedEventArgs e)
        {
            if (sex.IsChecked == true)
            {
                sex2.IsChecked = false;
            }
            
        }

        private void sex2_Checked(object sender, RoutedEventArgs e)
        {
            if (sex2.IsChecked == true)
            {
                sex.IsChecked = false;
            }
        }
    }
}
