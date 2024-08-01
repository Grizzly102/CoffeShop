using Coffe.Model;
using Coffe.UsersControl;
using Coffeeshop;
using Microsoft.EntityFrameworkCore;
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

namespace Coffe.Windows
{
    /// <summary>
    /// Логика взаимодействия для BarOrderWindow.xaml
    /// </summary>
    public partial class BarOrderWindow : Window
    {
        public BarOrderWindow()
        {
            InitializeComponent();
            string tryy = OrderInfo.OrderNum;
            var list = App.Context.Products.ToList();
            var ord = App.Context.Orders.ToList();
            CaseDateOp.Text = CaseDateOp.Text + DateTime.Now.ToString("dd.MM.yyyy");
            foreach (var lt in list)
            {
                for (int i = 0; i < tryy.Length; i++)
                {
                    if (lt.Article == int.Parse(tryy[i].ToString()))
                    {
                     
                        Order_ListBox.Items.Add(new BarOrderControl(lt));
                    }
   
                }
  
            }
            var order = App.Context.Orders.Where(a => a.OrderNumber == OrderInfo.OrderId).ToList();
            foreach (var lt in order)
            {
                StatusBox.Text = lt.OrderStatus;
                CaseNum.Text = $"{CaseNum.Text} {Convert.ToString(lt.OrderNumber)}";
                Art.Text = $"{Art.Text} {lt.UserName}";
            }
        }

        private void BackBt_Click(object sender, RoutedEventArgs e)
        {
            BaristaOrderWindow wnd = new BaristaOrderWindow();
            wnd.Show();
            this.Close();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SupName.IsHistory != 1)
            {
                var orders = App.Context.Orders.Where(a => a.OrderNumber == OrderInfo.OrderId);

                OrderInfo.OrderStatus = Convert.ToString(StatusBox.SelectedValue).Replace("System.Windows.Controls.ComboBoxItem: ", "");
                if (Convert.ToString(StatusBox.SelectedValue) == "System.Windows.Controls.ComboBoxItem: Получен")
                {
                    if (MessageBox.Show("Заказ выдан?", "Выдача заказа", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        var cases = App.Context.Orders.ToList();
                        foreach (var item in cases)
                        {
                            var CiC = App.Context.Orders.FirstOrDefault(x => x.OrderNumber == OrderInfo.OrderId);
                            if (CiC != null)
                            {
                                CiC.OrderStatus = "Получен";

                            }
                        }
                    }
                    App.Context.SaveChanges();
                    App.Context.UpdateRange();
                    BaristaOrderWindow wnd = new BaristaOrderWindow();
                    wnd.Refresh();
                    wnd.Show();
                    this.Close();

                }
                else if (Convert.ToString(StatusBox.SelectedValue) == "System.Windows.Controls.ComboBoxItem: Готов")
                {
                    string mail = "";
                    var order = App.Context.Orders.Where(a => a.OrderNumber == OrderInfo.OrderId).ToList();
                    foreach (var lt in order)
                    {
                        mail = lt.Address;
                        lt.OrderStatus = "Готов";
                    }    
                        try
                    {
                        MailAddress from = new MailAddress("trycoffeshop@mail.ru", "coffeshop");
                        // кому отправляем
                        MailAddress to = new MailAddress(mail);
                        // создаем объект сообщения
                        MailMessage m = new MailMessage(from, to);
                        // тема письма
                        m.Subject = "Чек";
                        // текст письма
                        StringBuilder sb = new StringBuilder();
                        sb.AppendLine("\t\t\t ООО \"Кофешоп\"" + Environment.NewLine);
                        sb.AppendLine("\t\t\t г.Уфа ул.Пушкина 29" + Environment.NewLine);
                        sb.AppendLine("\t\t\t Ваш заказ готов!" + Environment.NewLine);
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
                }
                else
                {
                    var CiC = App.Context.Orders.FirstOrDefault(x => x.OrderNumber == OrderInfo.OrderId);
                    if (CiC != null && CiC.OrderStatus != OrderInfo.OrderStatus)
                    {
                        CiC.OrderStatus = OrderInfo.OrderStatus;

                    }
                }
                App.Context.SaveChanges();
                App.Context.UpdateRange();
            }
        }
        private void BackHistBt_Click(object sender, RoutedEventArgs e)
        {
            OrderHistory wnd = new OrderHistory();
            wnd.Show();
            this.Close();
        }
    }
}
