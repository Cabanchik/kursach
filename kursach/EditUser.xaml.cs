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
            
        }

        private void surname_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void sex_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Ellipse_Drop(object sender, DragEventArgs e)
        {
            System.Drawing.Image ii;
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // Note that you can have more than one file.
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                string fin = System.IO.Path.GetFullPath(files[0]);

                dicpic.ImageSource = new BitmapImage(new Uri(fin));
                ii = new System.Drawing.Bitmap(fin);
                user1.user_pic = ImageToByte(ii);
                App.napominatel.SaveChanges();
            }
        }
        public static byte[] ImageToByte(System.Drawing.Image image)
        {
            System.Drawing.ImageConverter ic = new System.Drawing.ImageConverter();
            return (byte[])ic.ConvertTo(image, typeof(byte[]));
        }

        private void edit1_Click(object sender, RoutedEventArgs e)
        {
            if (edit1.Visibility == Visibility.Visible)
            {
                edit1.Visibility = Visibility.Collapsed;
                sussy.Visibility = Visibility.Visible;
                edit.Visibility = Visibility.Visible;
            }
            else if (edit1.Visibility == Visibility.Collapsed)
            {
                edit1.Visibility = Visibility.Visible;
                sussy.Visibility = Visibility.Collapsed;
            }
        }
    }
}
