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
    /// Логика взаимодействия для UserPageWindow.xaml
    /// </summary>
    public partial class UserPageWindow : Window
    {
        ApplicationContext db;
        public string a { get; set; } = "";
        

            public UserPageWindow()
            {
            InitializeComponent();
            db = new ApplicationContext();
            }
        // Ввод
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }
        // Вывод
        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }
        // Ключ
        private void TextBox_TextChanged_2(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string text = message.Text.Trim();
            string key = keys.Text.Trim();
            string encryptedText = VigenereEncrypt(message.Text, keys.Text);
            message2.Text = encryptedText;
            string shifr = message2.Text.Trim();
            Work work = new Work(shifr, text, key);
            db.works.Add(work);
            db.SaveChanges();
        }
        private string VigenereEncrypt(string message, string key)
        {
           string alphabet = a;
            if (alphabet == "")
            {
                MessageBox.Show("Выберите язык");
                return(null);
            }
            else
            {
                var table = new char[alphabet.Length, alphabet.Length];
                for (int i = 0; i < alphabet.Length; i++)
                {
                    for (int j = 0; j < alphabet.Length; j++)
                    {
                        int shift = (i + j) % alphabet.Length;
                        table[i, j] = alphabet[shift];
                    }
                }
                int para1 = 1, para2 = 0, perem = 1;
                string result = "";

                message = message.ToLower();
                key = key.ToLower();
                for (int i = 0; i < message.Length; i++)
                {
                    if (char.IsLetter(message[i]))
                    {
                        for (int row = 0; row < alphabet.Length; row++)
                        {
                            if (table[row, 0] == message[i])
                            {
                                para1 = row;
                                break;
                            }
                        }
                        for (int column = 0; column < alphabet.Length; column++)
                        {
                            if (table[0, column] == key[perem - 1])
                            {
                                para2 = column;
                                break;
                            }
                        }
                        result += table[para1, para2];
                    }
                    else
                    {
                        result += message[i];
                        perem--;
                    }
                    if (perem % key.Length == 0)
                    {
                        perem = 0;
                    }
                    perem++;
                }
                return result;
            }
        }


        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (ComboBox.SelectedItem is "Ru")
            {
                  a = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя"; // Алфавит русского языка
            }
            else if (ComboBox.SelectedItem is "Eng")
            {
                   a = "abcdefghijklmnopqrstuvwxyz";// Алфавит английского языка
            }
            else 
            {
                  a = "" ; 
            }

        }

        private void menu(object sender, RoutedEventArgs e)
        {
            Histor histor = new Histor();
            histor.Show();
            Hide();
        }
    }
}
