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
using Курсач;

namespace UsersApp
{
    /// <summary>
    /// Логика взаимодействия для Histor.xaml
    /// </summary>
    public partial class Histor : Window
    {
        public Histor()
        {
            InitializeComponent();

            ApplicationContext db = new ApplicationContext();
            List<Work> works = db.works.ToList();
            list.ItemsSource = works;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UserPageWindow userPageWindow = new UserPageWindow();
            userPageWindow.Show();
            Hide();
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            UserPageWindow2 userPageWindow2 = new UserPageWindow2();
            userPageWindow2.Show();
            Hide();
        }
    }
}
