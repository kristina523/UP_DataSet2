using CarDealership_BD.CarDealershipDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace CarDealership_BD
{
    /// <summary>
    /// Логика взаимодействия для OrdersPageBD.xaml
    /// </summary>
    public partial class OrdersPageBD : Page
    {
        OrdersTableAdapter orders = new OrdersTableAdapter();
        public OrdersPageBD()
        {
            InitializeComponent();
            BD_Orders.ItemsSource = orders.GetData();
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            orders.InsertQuery(Convert.ToInt32(text1.Text), Convert.ToInt32(text2.Text), text3.Text, Convert.ToInt32(text4.Text));
            BD_Orders.ItemsSource = orders.GetData();
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            object id = (BD_Orders.SelectedItem as DataRowView).Row[0];
            orders.UpdateQuery(Convert.ToInt32(text1.Text), Convert.ToInt32(text2.Text), text3.Text, Convert.ToInt32(text4.Text), Convert.ToInt32(id));
            BD_Orders.ItemsSource = orders.GetData();
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            object id = (BD_Orders.SelectedItem as DataRowView).Row[0];
            orders.DeleteQuery(Convert.ToInt32(id));
            BD_Orders.ItemsSource = orders.GetData();
        }

        private void BD_Orders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BD_Orders.SelectedItem != null)
            {
                DataRowView row = BD_Orders.SelectedItem as DataRowView;
                if (row != null)
                {
                    text1.Text = row.Row["Customer_ID"].ToString();
                    text2.Text = row.Row["Vehicle_ID"].ToString();
                    text3.Text = row.Row["OrderDate"].ToString();
                    text4.Text = row.Row["Amount"].ToString();
                }
            }
        }
    }
}