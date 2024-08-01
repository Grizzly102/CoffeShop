using Coffe;
using Coffe.Model;
using Coffeeshop.UsersControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
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
using System.Windows.Interop;
using static System.Net.Mime.MediaTypeNames;
using Coffeeshop.Model;
using Coffe.Windows;
using Microsoft.EntityFrameworkCore;
using System.Printing;

namespace Coffeeshop.Windows
{
    /// <summary>
    /// Логика взаимодействия для OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : Window
    {
        public string prodart;
        public string forbill;
        public string fullprice;
        public int PrCost;
        public int Ordnum;
        public string PrName;
        public string name;
        public string ordval;
        public OrderWindow()
        {
            InitializeComponent();
            Random rnd = new Random();
            int value = rnd.Next(10000, 99999);
            int ordvalue = rnd.Next(1000, 9999);
            ordval = "A" + Convert.ToString(ordvalue);
            OrderNumber.Text = OrderNumber.Text + ordval;
            if (SupName.name != null)
            {
                name = SupName.name;
                Ordnum = value;
            }
            else
            {
                Ordnum = value;
                string OrdNum = "Гость"+Convert.ToString(value);
                name = OrdNum;
                SupName.name = OrdNum;
            }
            string[] ProductMas = OrderInfo.OrderItems.TrimEnd(',').Split(',');
            int price = 0;

            for (int i = 0; i < ProductMas.Length; i++)
            {
                List<Coffe.Model.Product> products = App.Context.Products.Where(x => x.Article == Convert.ToInt32(ProductMas[i])).ToList();
                int cnt = 0;
                foreach (Coffe.Model.Product product in products)
                {
                    cnt += 1;
                    Order_ListBox.Items.Add(new OrdersControl(product));
                    price = (int)product.Cost + price;
                    prodart = ProductMas[i] + prodart;
                    Order_Cost.Text = "Сумма заказа: " + Convert.ToString(price) + "р.";
                    PrName = product.ProductName;
                    PrCost = (Int32)product.Cost;
                }
                if (products.Count == 1)
                {
                    forbill = forbill + $"{PrName}:\t\t {Convert.ToInt32(PrCost)}р\n\n";
                }
                else if (products.Count > 1)
                {
                    forbill = forbill + $"{PrName} x2:\t\t {Convert.ToInt32(PrCost * cnt)}р\n\n";
                }
                fullprice = Order_Cost.Text;
                products.Clear();
            }

        }

        private void Back_ButtonClick(object sender, RoutedEventArgs e)
        {

            ProductsWindow wnd = new ProductsWindow();
            wnd.Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {


        }

        private void PayOrder_ButtonClick(object sender, RoutedEventArgs e)
        {
            string email;
            if (mailbox.Text == null)
            {
                email = ".";
            }
            else
            {
                email = mailbox.Text;
            }
                int point = 0;


                var order = App.Context.Orders.Where(a => a.UserName == SupName.name & a.OrderStatus != "Получен").ToList();

                foreach (var lt in order)
                {
                    point += 1;
                }

                if (point > 0)
                {
                    MessageBox.Show("Вы уже оформили заказ");
                }
                else
                {
                    DateTime date = DateTime.Now;
                    DateOnly now = new DateOnly(date.Year, date.Month, date.Day);
                    App.Context.Orders.ToList();
                    var cs = App.Context.Orders.ToList();
                    int kol = cs.Count;
                    long pass = 0;
                    Order or = new Order
                    {

                        OrderList = Convert.ToString(prodart),
                        OrderDate = now,
                        Address = email,
                        OrderStatus = "Оформлен",
                        UserName = name,
     
                    };
                    App.Context.Orders.Add(or);
                    App.Context.SaveChanges();

                    MessageBox.Show("Заказ оформлен! Следите за статусом заказа, когда заказ будет готов вы сможете его забрать");
                    try
                    {
                        MailAddress from = new MailAddress("trycoffeshop@mail.ru", "coffeshop");
                        // кому отправляем
                        MailAddress to = new MailAddress(mailbox.Text);
                        // создаем объект сообщения
                        MailMessage m = new MailMessage(from, to);
                        // тема письма
                        m.Subject = "Чек";
                        // текст письма
                        StringBuilder sb = new StringBuilder();
                        sb.AppendLine("\t\t\t ООО \"Кофешоп\"" + Environment.NewLine);
                        sb.AppendLine("\t\t\t ИНН 462845201" + Environment.NewLine);
                        sb.AppendLine("\t\t\t г.Уфа ул.Пушкина 29" + Environment.NewLine);
                        sb.AppendLine("\t\t\t КАССОВЫЙ ЧЕК" + Environment.NewLine);
                        sb.AppendLine("Номер заказа:" + ordval);
                        sb.AppendLine("Дата: " + Convert.ToString(DateTime.Now));
                        sb.AppendLine("--------------------------------------------");
                        sb.AppendLine(forbill);
                        sb.AppendLine("--------------------------------------------");
                        sb.AppendLine("ИТОГ:\t\t\t" + fullprice);
                        m.Body = sb.ToString();
                        m.IsBodyHtml = false;

                        // адрес smtp-сервера и порт, с которого будем отправлять письмо
                        SmtpClient smtp = new SmtpClient("smtp.mail.ru", 587);
                        // логин и пароль
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new NetworkCredential("trycoffeshop@mail.ru", "VKdqsijjy3juBniyrWWT");
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtp.EnableSsl = true;
                        smtp.Send(m);
                        smtp.Dispose();
                    }
                    catch (Exception)
                    {

             
                    }
                   

                    StartWindow wnd = new StartWindow();
                    wnd.Visibility = Visibility.Visible;
                    this.Close();
                }
         }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены?", "Очистка корзины", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                OrderInfo.OrderItems = null;
                ProductsWindow wnd = new ProductsWindow();
                wnd.Show();
                this.Close();
            }

        }
    }
}
