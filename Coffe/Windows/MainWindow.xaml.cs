
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Policy;
using System.Text;
using System.Text.Json.Serialization;
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
using Coffe;
using Coffe.Model;
using Coffe.Windows;
using Coffeeshop.Windows;

namespace Coffeeshop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public bool point = false;
        public bool logpoint = false;
        public bool passpoint = false;
        private void Autorez_Button_Click(object sender, RoutedEventArgs e)
        {
            List<User> sups = App.Context.Users.ToList();
           
            foreach (User sup in sups)
            {
                if (Login_TextBox.Text == sup.Login && Password_PasswordBox.Password == sup.Password)
                {
                    if (sup.IdRole == 3)
                    {
                        SupName.name = sup.FullName;
                      
                        StartWindow win1 = new StartWindow();
                        win1.LogButton.Visibility = Visibility.Hidden;
                        win1.OrderHistory.Visibility = Visibility.Visible;
                        win1.Show();      
                        this.Close();
                        SupName.LogStatus = 1;
                        point = true;
                    }
                    else if (sup.IdRole == 1)
                    {
                        BaristaOrderWindow win1 = new BaristaOrderWindow();
                        win1.Show();
                        this.Close();
                        SupName.namebar = sup.FullName;
                        point = true;
                    }
                    else
                    {
                        MessageBox.Show("Успешный вход");
                        StartWindow win2 = new StartWindow();
                        win2.Show();
                        this.Close();
                        SupName.name = sup.FullName;
                        point = true;
                    }
                }
                else if (Login_TextBox.Text != sup.Login && Password_PasswordBox.Password == sup.Password)
                {
                    logpoint = true;
                }
                else if (Login_TextBox.Text == sup.Login && Password_PasswordBox.Password != sup.Password)
                {
                    passpoint = true;
                }

            }
            if (point == false)
            {
                if (Login_TextBox.Text == "adm" && Password_PasswordBox.Password == "adm")
                {
                    AdminWindow win1 = new AdminWindow();
                    win1.Show();
                    this.Close();

                }
                else if(String.IsNullOrEmpty(Login_TextBox.Text) && !String.IsNullOrEmpty(Password_PasswordBox.Password))
                {
                    MessageBox.Show("Поле логин должно быть заполнено!", "Ошибка");
                }
                else if (String.IsNullOrEmpty(Password_PasswordBox.Password) && !String.IsNullOrEmpty(Login_TextBox.Text))
                {
                    MessageBox.Show("Поле пароль должно быть заполнено!", "Ошибка");
                }
                else if (String.IsNullOrEmpty(Password_PasswordBox.Password) && String.IsNullOrEmpty(Login_TextBox.Text))
                {
                    MessageBox.Show("Все поля должны быть заполнены!", "Ошибка");
                }
                else if (logpoint == true)
                {
                    MessageBox.Show("Пользователя с таким логином не существует!", "Ошибка");
                    logpoint = false;
                }

                else
                {
                    MessageBox.Show("Неверные данные", "Ошибка");
                }
            }

        }

        private void Reg_Button_Click(object sender, RoutedEventArgs e)
        {
            RegWindow reg = new RegWindow();
            reg.Show();
            this.Close();
        }

        private void Admin_ButtonClick(object sender, RoutedEventArgs e)
        {
            AdminWindow win = new AdminWindow();
            win.Show();
            this.Close();
        }

        private void BackBt_Click(object sender, RoutedEventArgs e)
        {
            StartWindow win = new StartWindow();
            win.Show();
            this.Close();
        }
    }
}
