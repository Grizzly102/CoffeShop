using Coffe.Model;
using Coffe;
using Coffe.Windows;
using System;
using System.Collections.Generic;
using System.Drawing;
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
    /// Логика взаимодействия для StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        public StartWindow()
        {
            InitializeComponent();
            if (SupName.LogStatus == 1)
            {
                LogButton.Visibility = Visibility.Hidden;
                OrderHistory.Visibility = Visibility.Visible;
            }
        }

        private void Menu_Button_Click(object sender, RoutedEventArgs e)
        {
            ProductsWindow win = new ProductsWindow();
            win.Show();
            this.Close();
        }

        private void Basket_ButtonClick(object sender, RoutedEventArgs e)
        {
            if (OrderInfo.OrderItems == null)
            {
                MessageBox.Show("Корзина пуста!\nДобавьте товар");
            }
            else
            {
                OrderWindow win1 = new OrderWindow();
                win1.Show();
                this.Close();
            }
        }

        private void Order_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int point = 0;
                var order = App.Context.Orders.Where(a => a.UserName == SupName.name & a.OrderStatus != "Получен").ToList();
                foreach (var lt in order)
                {
                    point += 1;
                }
                if (point > 0)
                {
                    ClientOrderWindow wnd = new ClientOrderWindow();
                    wnd.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Заказов не найдено");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Заказов не найдено");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow wnd = new MainWindow();
            wnd.Show();
            this.Close();
        }

        private void OrderHistory_Click(object sender, RoutedEventArgs e)
        {
            OrderHistory hs = new OrderHistory();
            hs.Show();
            this.Close();
        }

    }
}
