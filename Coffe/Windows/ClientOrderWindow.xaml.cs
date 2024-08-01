using Coffe.Model;
using Coffe.UsersControl;
using Coffeeshop;
using Coffeeshop.Windows;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Coffe.Windows
{
    /// <summary>
    /// Логика взаимодействия для ClientOrderWindow.xaml
    /// </summary>
    public partial class ClientOrderWindow : Window
    {
        int ordnum;
        string orderit = "";
        int point = 0;
        public ClientOrderWindow()
        {
          
            InitializeComponent();
            var order = App.Context.Orders.Where(a => a.UserName == SupName.name).ToList();
            foreach (var lt in order)
            {
                StatBlock.Text = "Статус заказа: " + lt.OrderStatus;
                ordnum = lt.OrderNumber;
                orderit = lt.OrderList;
                point += 1;
            }

            string tryy = orderit;
            var list = App.Context.Products.ToList();
            if (point > 0)
            {
                foreach (var lt in list)
                {
                    for (int i = 0; i < tryy.Length; i++)
                    {
                        if (lt.Article == int.Parse(tryy[i].ToString()))
                        {

                            Order_ListBox.Items.Add(new BarOrderControl(lt));

                        }
                        int rez = Convert.ToInt32(tryy[i]);
                    }
                }
            }
            else
            {
                  
            }
        }

        private void ObnButton_Click(object sender, RoutedEventArgs e)
        {
                StatBlock.Text = $"Статус заказа: Готов";
        }

        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            StartWindow wnd = new StartWindow();
            wnd.Show();
            this.Close();
        }
    }
}
