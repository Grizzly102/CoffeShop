using Coffe.Model;
using Coffeeshop;
using Coffeeshop.Windows;
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

namespace Coffe.Windows
{
    /// <summary>
    /// Логика взаимодействия для OrderHistory.xaml
    /// </summary>
    public partial class OrderHistory : Window
    {
        public void Refresh()
        {
            List<Order> newitems = App.Context.Orders.Where(x => x.UserName == SupName.name & x.OrderStatus == "Получен").ToList();
            if (newitems == null)
            {
                MessageBox.Show("История заказов пуста");
            }
            else
            {
                List.ItemsSource = null;
                List.ItemsSource = newitems;
                List.Items.Refresh();
            }
           
        }
        public OrderHistory()
        {
            InitializeComponent();
            Refresh();
        }

        private void infoBTN_Click(object sender, RoutedEventArgs e)
        {
            var items = (dynamic)List.SelectedItem;
            OrderInfo.OrderNum = items.OrderList;
            OrderInfo.OrderId = items.OrderNumber;
            SupName.IsHistory = 1;
            BarOrderWindow di = new BarOrderWindow();
            di.BackBtn.Visibility = Visibility.Hidden;
            di.StatusBox.Visibility = Visibility.Hidden;
            di.BackHistBt.Visibility = Visibility.Visible;
            di.Conduct.Text = "Статус: Получен";
            di.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StartWindow wnd = new StartWindow();
            wnd.Show();
            this.Close();
        }
    }
}
