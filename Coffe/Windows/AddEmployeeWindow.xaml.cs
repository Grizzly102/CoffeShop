using Coffe.Model;
using Coffe;
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

namespace Coffeeshop.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddEmployeeWindow.xaml
    /// </summary>
    public partial class AddEmployeeWindow : Window
    {
        public AddEmployeeWindow()
        {
            InitializeComponent();
        }

        private void AddEmployee_ButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                User user = new User();

                user.FullName = Full_name_TextBox.Text;
                user.Login = Login_TextBox.Text;
                user.Password = Password_TextBox.Text;
                user.IdUser = App.Context.Users.Count() + 1;
                user.IdRole = 2;
                App.Context.Users.Add(user);
                App.Context.SaveChanges();
                MessageBox.Show("Сотрудник добален");
                AdminWindow wnd = new AdminWindow();
                wnd.Show();
                this.Close();
            }
            catch (Exception)
            {

                MessageBox.Show("Заполните все поля");
            }
        }

        private void BackBt_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow wnd = new AdminWindow();
            wnd.Show();
            this.Close();
        }
    }
}
