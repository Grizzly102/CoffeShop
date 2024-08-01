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
    /// Логика взаимодействия для AddProductWindow.xaml
    /// </summary>
    public partial class AddProductWindow : Window
    {
        public AddProductWindow()
        {
            InitializeComponent();
        }

        private void AddProduct_ButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Product user = new Product();

                user.Article = App.Context.Products.Count()+1;
                user.IdCategory = CategoryBox.SelectedIndex + 1;
                user.ProductName = NameBox.Text;
                user.Cost = Convert.ToInt32(PriceBox.Text);
                user.Photo = "/Image/CoffeLogo.png";
                App.Context.Products.Add(user);
                App.Context.SaveChanges();
                MessageBox.Show("Товар добален");
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
