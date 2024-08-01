using Coffe.Windows;
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
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
        }

        private void AddProd_ButtonClick(object sender, RoutedEventArgs e)
        {
            AddProductWindow win = new AddProductWindow();
            win.Show();
            this.Close();
        }

        private void AddEmplo_ButtonClick(object sender, RoutedEventArgs e)
        {
            AddEmployeeWindow win1 = new AddEmployeeWindow();
            win1.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ProductWindow win = new ProductWindow();
            win.Show();
            this.Close();
        }
    }
}
