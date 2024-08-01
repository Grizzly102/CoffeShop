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
using System.Windows.Shapes;

namespace Coffe.Windows
{
    /// <summary>
    /// Логика взаимодействия для ProductWindow.xaml
    /// </summary>
    public partial class ProductWindow : Window
    {
        public void Refresh()
        {
            List<Product> newitems = App.Context.Products.ToList();
            List.ItemsSource = null;
            List.ItemsSource = newitems;
            List.Items.Refresh();
        }
        public ProductWindow()
        {
            InitializeComponent();
            Refresh();
        }

        private void delBTN_Click(object sender, RoutedEventArgs e)

        {
            if (MessageBox.Show("Вы точно хотите удалить ", "Удаление товара", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                var items = (dynamic)List.SelectedItem;
                int art = items.Article;
                var itemsDelete = App.Context.Products.FirstOrDefault(x => x.Article == art);
                App.Context.Products.Remove(itemsDelete);
                App.Context.SaveChanges();
                MessageBox.Show("товар удалён");
                Refresh();
            }
        }
    }
}
