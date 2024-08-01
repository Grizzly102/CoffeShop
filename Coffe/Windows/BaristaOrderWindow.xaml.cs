using Coffe.Model;
using Coffeeshop;
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
    /// Логика взаимодействия для BaristaOrderWindow.xaml
    /// </summary>
    public partial class BaristaOrderWindow : Window
    {
        public void Refresh()
        {
            List<Order> newitems = App.Context.Orders.Where(x => x.OrderStatus != "Получен").ToList();
            newitems.OrderByDescending(x => x.OrderNumber).ToList();
            List.ItemsSource = null;
            List.ItemsSource = newitems;
            List.Items.Refresh();
        }
        public BaristaOrderWindow()
        {
            InitializeComponent();
            
        }

        private void infoBTN_Click(object sender, RoutedEventArgs e)
        {
            var items = (dynamic)List.SelectedItem;                
                OrderInfo.OrderNum = items.OrderList;
                OrderInfo.OrderId = items.OrderNumber;
                BarOrderWindow di = new BarOrderWindow();
                di.Show();
                this.Close();


        }

        private void UpdButton_Click(object sender, RoutedEventArgs e)
        {
            List<Order> newitems = App.Context.Orders.Where(x => x.OrderStatus != "Получен").ToList();
            List.ItemsSource = null;
            List.ItemsSource = newitems;
            List.Items.Refresh();
        }

        private void Window_Activated(object sender, EventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();
        }
    }
}
