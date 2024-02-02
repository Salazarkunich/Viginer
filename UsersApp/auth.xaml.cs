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
    /// Логика взаимодействия для auth.xaml
    /// </summary>
    public partial class auth : Window
    {
        public auth()
        {
            InitializeComponent();

        }

        public void Login_TextChanged(object sender, TextChangedEventArgs e)
        {
                
        }

        private void Авторизоваться(object sender, RoutedEventArgs e)
        {
            string login = Login.Text.Trim();
            string password = Password.Password.Trim();
            if (login.Length < 5)
            {
                Login.ToolTip = "Это поле введено не корректно";
                Login.Background = Brushes.DarkRed;

            }
            else
            {
                Login.ToolTip = "";
                Login.Background = Brushes.Transparent;

                if (password.Length < 5)
                {
                    Password.ToolTip = "Это поле введено не корректно";
                    Password.Background = Brushes.DarkRed;
                }
                else
                {
                    Password.ToolTip = "";
                    Password.Background = Brushes.Transparent;

                    User authUser = null;
                    using (ApplicationContext db = new ApplicationContext())
                    {
                        authUser = db.Users.Where(b => b.Login == login && b.Password == password).FirstOrDefault();
                    }

                    if (authUser != null)
                    {
                        Histor histor = new Histor();
                        histor.Show();
                        Hide();
                    }
                    else
                        MessageBox.Show("Вы ввели что-то некорректно");
                }
            }
        }

        private void Регистрация(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            Hide();
        }
    }
}
