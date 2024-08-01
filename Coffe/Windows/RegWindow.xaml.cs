
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
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
using Coffe;
using Coffe.Model;

namespace Coffeeshop
{
    /// <summary>
    /// Логика взаимодействия для RegWindow.xaml
    /// </summary>
    public partial class RegWindow : Window
    {
        public RegWindow()
        {
            InitializeComponent();
        }

        private void Reg_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                User user = new User();

                user.FullName = Full_name_TextBox.Text;
                user.Login = Login_TextBox.Text;
                user.Password = Password_TextBox.Text;
                user.IdUser = App.Context.Users.Count() + 1;
                user.IdRole = 3;
                App.Context.Users.Add(user);
                App.Context.SaveChanges();
                MessageBox.Show("Регистрация прошла успешно");
                MainWindow wnd = new MainWindow();
                wnd.Show();
                this.Close();
            }
            catch (Exception)
            {

                MessageBox.Show("Заполните все поля");
            }
           
        }

        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow b = new MainWindow();
            b.Show();
            this.Close();
        }
    }
}
