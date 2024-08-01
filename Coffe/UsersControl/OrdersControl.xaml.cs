using Coffe;
using Coffe.Model;
using System;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Controls;

namespace Coffeeshop
{
    /// <summary>
    /// Логика взаимодействия для OrdersControl.xaml
    /// </summary>
    public partial class OrdersControl : UserControl
    {

        public OrdersControl(Product product)
        {
            InitializeComponent();
            Order_Grid.DataContext = product;
            //MinusButton.IsEnabled = false;
            //PlusButton.IsEnabled = false;
        
        }

        //private void MinusButton_Click(object sender, System.Windows.RoutedEventArgs e)
        //{
            
        //    if (Convert.ToInt32(CountText.Text) <=1)     
        //    {
        //        MinusButton.IsEnabled = false;
        //    }
        //    else
        //    {
        //        MinusButton.IsEnabled = true;
        //        CountText.Text = Convert.ToString(Convert.ToInt32(CountText.Text) - 1);
        //        CostText.Text = Convert.ToString(Convert.ToInt32(CostText.Text ) / 2);
        //        StaticPrice.price = Convert.ToInt32(CostText.Text);
        //    }
        //}

        //private void PlusButton_Click(object sender, System.Windows.RoutedEventArgs e)
        //{
        //    MinusButton.IsEnabled = true;
        //    CountText.Text = Convert.ToString(Convert.ToInt32(CountText.Text) + 1);
        //    CostText.Text = Convert.ToString(Convert.ToInt32(CostText.Text) + Convert.ToInt32(StatPrice.Text));
        //    StaticPrice.price = Convert.ToInt32(CostText.Text);
        //}
       
        //private void CountText_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    try
        //    {
                
        //        Convert.ToInt32(CountText.Text);
        //        //CostText.Text = Convert.ToString(Convert.ToInt32(CountText.Text) * price);
        //    }
        //    catch (Exception)
        //    {

        //    }

        //}
    }
}
