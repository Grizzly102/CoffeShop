using Coffe.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Coffeeshop.UsersControl
{
    /// <summary>
    /// Логика взаимодействия для ProductsControl.xaml
    /// </summary>
    public partial class ProductsControl : UserControl
    {
        public ProductsControl(Product product)
        {
            InitializeComponent();
            int count = Convert.ToInt32(CountLabel.Content);
            Order_Grid.DataContext = product;
    
            if (OrderInfo.OrderItems != null)
            {
                string[] ProductMas = OrderInfo.OrderItems.TrimEnd(',').Split(',');
                for (int i = 0; i < ProductMas.Length; i++)
                {
                    if (ProductMas[i] == Convert.ToString(product.Article))
                    {
                        CountLabel.Content = Convert.ToString(cnt += 1);
                    }
                }
            }
        }
        int cnt = 0;
        private void Add_ButtonClick(object sender, RoutedEventArgs e)
        {
         

            if (cnt < 5)
            {
                if (OrderInfo.OrderItems != null)
                {
                    OrderInfo.OrderItems = OrderInfo.OrderItems + Art.Text + ",";
                }
                else
                {
                    OrderInfo.OrderItems = Art.Text + ",";
                }
                cnt += 1;
            }
            else
            {
                 AddButton.IsEnabled = false;

               
            }
            DelButton.IsEnabled = true;
            CountLabel.Content = Convert.ToString(cnt);
        }

        private void DelButton_Click(object sender, RoutedEventArgs e)
        {

            AddButton.IsEnabled = true;

            if (cnt > 0)
            {
                cnt -= 1;
                Regex reg = new Regex(Art.Text + ",");
                OrderInfo.OrderItems = reg.Replace(OrderInfo.OrderItems, "", 1);
            }
            else
            {
             
               
            }
            CountLabel.Content = Convert.ToString(cnt);
        }
    }
}
