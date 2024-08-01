using Coffe.Model;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Coffe.UsersControl
{
    /// <summary>
    /// Логика взаимодействия для BarOrderControl.xaml
    /// </summary>
    public partial class BarOrderControl : UserControl
    {
        public BarOrderControl(Product product)
        {
            InitializeComponent();
            Order_Grid.DataContext = product;
        }
    }
}
