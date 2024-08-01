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

using Coffe.Model;
using Coffeeshop.Windows;
using Coffeeshop.UsersControl;
using Coffe;


namespace Coffeeshop
{
    /// <summary>
    /// Логика взаимодействия для ProductsWindow.xaml
    /// </summary>
    public partial class ProductsWindow : Window
    {
        private void Refresh()
        {
            Product_ListBox.Items.Clear();
            List<Product> products = App.Context.Products.ToList();
            foreach (Product product in products)
            {
                if (product.Photo.Contains("/Image"))
                {
                    Product_ListBox.Items.Add(new ProductsControl(product));
                
                }
                else
                {
                    product.Photo = $"/Image/{product.Photo}";
                    Product_ListBox.Items.Add(new ProductsControl(product));
                }
            }
        }
        public ProductsWindow()
        {
            InitializeComponent();
            Refresh();
        }

        private void Back_ButtonClick(object sender, RoutedEventArgs e)
        {
            StartWindow win = new StartWindow();
            win.Show();
            this.Close();
        }


        private void Order_ButtonClick(object sender, RoutedEventArgs e)
        {
            if (OrderInfo.OrderItems == null || OrderInfo.OrderItems == "")
            {
                MessageBox.Show("Корзина пуста!\nДобавьте товар");
            }
            else
            {
                OrderWindow win = new OrderWindow();
                win.Show();
                this.Close();
            }
      
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Product_ListBox.Items.Clear();
            List<Product> prods = App.Context.Products.ToList();
            foreach (Product prod in prods)
            {
                if (prod.ProductName.Contains(SearchText.Text.ToLower()))
                {
                    Product_ListBox.Items.Add(new ProductsControl(prod));

                }
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Product_ListBox.Items.Clear();
           
            if (PriceBox.SelectedIndex == 0)
            {
                List<Product> prods = App.Context.Products.OrderByDescending(s => s.Cost).ToList();
                foreach (Product prod in prods)
                {

                    Product_ListBox.Items.Add(new ProductsControl(prod));
                }
            }
            else if (PriceBox.SelectedIndex == 1)
            {
                List<Product> prods = App.Context.Products.OrderBy(s => s.Cost).ToList();
                foreach (Product prod in prods)
                {

                    Product_ListBox.Items.Add(new ProductsControl(prod));
                }
            }
            else if (PriceBox.SelectedIndex == 2)
            {
                List<Product> prods = App.Context.Products.ToList();
                foreach (Product prod in prods)
                {

                    Product_ListBox.Items.Add(new ProductsControl(prod));
                }
            }
        }

        private void CategoryBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Product_ListBox.Items.Clear();

            if (CategoryBox.SelectedIndex == 0)
            {
                List<Product> prods = App.Context.Products.Where(s => s.IdCategory == 1).ToList();
                foreach (Product prod in prods)
                {

                    Product_ListBox.Items.Add(new ProductsControl(prod));
                }
            }
            else if (CategoryBox.SelectedIndex == 1)
            {
                List<Product> prods = App.Context.Products.Where(s => s.IdCategory == 2).ToList();
                foreach (Product prod in prods)
                {

                    Product_ListBox.Items.Add(new ProductsControl(prod));
                }
            }
            else if (CategoryBox.SelectedIndex == 2)
            {
                List<Product> prods = App.Context.Products.Where(s => s.IdCategory == 3).ToList();
                foreach (Product prod in prods)
                {

                    Product_ListBox.Items.Add(new ProductsControl(prod));
                }
            }
            else if (CategoryBox.SelectedIndex == 3)
            {
                List<Product> prods = App.Context.Products.ToList();
                foreach (Product prod in prods)
                {

                    Product_ListBox.Items.Add(new ProductsControl(prod));
                }
            }
        }
    }
}

