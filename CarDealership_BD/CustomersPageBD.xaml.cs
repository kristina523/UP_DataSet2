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
    /// Логика взаимодействия для CustomersPageBD.xaml
    /// </summary>
    public partial class CustomersPageBD : Page
    {
        CustomersTableAdapter customers = new CustomersTableAdapter();
        public CustomersPageBD()
        {
            InitializeComponent();
            BD_Customers.ItemsSource = customers.GetData();
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            customers.InsertQuery(text1.Text, text2.Text, text3.Text, text4.Text, text5.Text);
            BD_Customers.ItemsSource = customers.GetData();
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            object id = (BD_Customers.SelectedItem as DataRowView).Row[0];
            customers.UpdateQuery(text1.Text, text2.Text, text3.Text, text4.Text, text5.Text, Convert.ToInt32(id));
            BD_Customers.ItemsSource = customers.GetData();
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object id = (BD_Customers.SelectedItem as DataRowView).Row[0];
                customers.DeleteQuery(Convert.ToInt32(id));
                BD_Customers.ItemsSource = customers.GetData();
            }
            catch
            {
                MessageBox.Show("Невозможно удалить клиента, так как с ним связаны другие таблицы!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void BD_Customers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BD_Customers.SelectedItem != null)
            {
                DataRowView row = BD_Customers.SelectedItem as DataRowView;
                if (row != null)
                {
                    text1.Text = row.Row["CustomerSurname"].ToString();
                    text2.Text = row.Row["CustomerName"].ToString();
                    text3.Text = row.Row["CustomerMiddleName"].ToString();
                    text4.Text = row.Row["PhoneNumber"].ToString();
                    text5.Text = row.Row["Email"].ToString();
                }
            }
        }
    }
}