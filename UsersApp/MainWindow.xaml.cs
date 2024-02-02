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
using Курсач;
using static System.Net.Mime.MediaTypeNames;

namespace UsersApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ApplicationContext db;
        public string b { get; set; } = "";

        public MainWindow()
        {
            InitializeComponent();
            db = new ApplicationContext();  
    
        }


        public void Зарегистрироватья(object sender, RoutedEventArgs e)
        {
            string login = Login.Text.Trim();
            string password = Password.Password.Trim();
            string password2 = Password2.Password.Trim();
            
            User authUser = null;
            using (ApplicationContext db = new ApplicationContext())
            {
                authUser = db.Users.Where(b => b.Login == login).FirstOrDefault();
            }
            if (authUser != null)
            {
                MessageBox.Show("Пользователь с таким именем уже зарегистрирован!");
            }
            else
            {
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

                        if (password != password2)
                        {
                            Password2.ToolTip = "Это поле введено не корректно";
                            Password2.Background = Brushes.DarkRed;
                        }
                        else
                        {

                            Password2.ToolTip = "";
                            Password2.Background = Brushes.Transparent;

                            MessageBox.Show("Вы успешно зарегистрировались");
                            User user = new User(login, password);
                            db.Users.Add(user);
                            db.SaveChanges();
                            auth auth = new auth();
                            auth.Show();
                            Hide();
                        }
                    }
                }
            }
        }
        private void Войти(object sender, RoutedEventArgs e)
        {
            auth auth = new auth();
            auth.Show();
            Hide();
        }

        private void Login_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
