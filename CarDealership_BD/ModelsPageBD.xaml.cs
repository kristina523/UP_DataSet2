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
    /// Логика взаимодействия для ModelsPageBD.xaml
    /// </summary>
    public partial class ModelsPageBD : Page
    {
        ModelsTableAdapter models = new ModelsTableAdapter();
        public ModelsPageBD()
        {
            InitializeComponent();
            BD_Models.ItemsSource = models.GetData();
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            models.InsertQuery(text1.Text);
            BD_Models.ItemsSource = models.GetData();
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            object id = (BD_Models.SelectedItem as DataRowView).Row[0];
            models.UpdateQuery(text1.Text, Convert.ToInt32(id));
            BD_Models.ItemsSource = models.GetData();
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            object id = (BD_Models.SelectedItem as DataRowView).Row[0];
            models.DeleteQuery(Convert.ToInt32(id));
            BD_Models.ItemsSource = models.GetData();
        }

        private void BD_Models_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BD_Models.SelectedItem != null)
            {
                DataRowView row = BD_Models.SelectedItem as DataRowView;
                if (row != null)
                {
                    text1.Text = row.Row["ModelName"].ToString();
                }
            }
        }
    }
}