﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
    /// Логика взаимодействия для EditUser.xaml
    /// </summary>
    public partial class EditUser : Window
    {
        
        public user user1 { get; set; }
        public EditUser(user user)
        {
            InitializeComponent();
            user1 = user;
            this.DataContext = user1;
            if (user1.gender_id == 1)
            {
                sex.IsChecked = true;
                sex2.IsChecked = false;
            }
            else
            {
                sex.IsChecked = false;
                sex2.IsChecked = true;
            }
           
            
        }

        private void surname_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void sex_Checked(object sender, RoutedEventArgs e)
        {
            if (sex.IsChecked == true)
            {               
                sex2.IsChecked = false;
            }
         
            
        }

        

        private void edit1_Click(object sender, RoutedEventArgs e)
        {
            pic.AllowDrop = true;
            edit1.Visibility = Visibility.Collapsed;
            sussy.Visibility = Visibility.Visible;
           
            name.IsReadOnly = false;
            surname.IsReadOnly = false;
            sex.IsEnabled = true;
            sex2.IsEnabled = true;
            dr.IsEnabled = true;
            log.IsReadOnly = false;
            pas.IsReadOnly = false;
            //lbl.Visibility = Visibility.Visible;
            pas.Text = Convert.ToString(user1.password);
        }
        private void sex2_Checked(object sender, RoutedEventArgs e)
        {
            if (sex2.IsChecked == true)
            {
               
                sex.IsChecked = false;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void sussy_Click(object sender, RoutedEventArgs e)
        {
            pic.AllowDrop = false;
            edit1.Visibility = Visibility.Visible;
            sussy.Visibility = Visibility.Collapsed;
           
            name.IsReadOnly = true;
            surname.IsReadOnly = true;
            sex.IsEnabled = false;
            sex2.IsEnabled = false;
            dr.IsEnabled = false;
            log.IsReadOnly = true;
            pas.IsReadOnly = true;
            lbl.Visibility = Visibility.Collapsed;

            if (sex2.IsChecked == true)
            {
                user1.gender_id = 2;
            }
            else if (sex.IsChecked == true)
            {
                user1.gender_id = 1;

            }
            user1.name = name.Text.ToString();
            user1.surname = surname.Text.ToString();
            user1.birth_date = Convert.ToDateTime(dr.Text);
            user1.login = log.Text.ToString();
            user1.password = pas.Text.ToString();
            Connection.DBcontext.SaveChanges();
            pas.Text = "***";
        }
    }
}
