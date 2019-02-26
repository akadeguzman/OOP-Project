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
using OOP_Project;

namespace OOP_Project_Updated
{
    /// <summary>
    /// Interaction logic for AddTransaction.xaml
    /// </summary>
    public partial class AddTransaction : Window
    {
       
        public MainWindow main;
        public Person Customer;
        public Product product;

        List<string> JewelryType = new List<string> { "Bracelet", "Necklace", "Earrings", "Ring" };
        List<string> Condition = new List<string> { "Scratched", "Broken Locks", "Missing Stones", "Dented" };
        List<string> Quality = new List<string> { "10k", "18k", "21k" };
        public DataStorage data;

        public AddTransaction()
        {
            InitializeComponent();
            foreach (string type in JewelryType)
                cmbJewelry.Items.Add(type);

            foreach (string conditions in Condition)
                cmbCondition.Items.Add(conditions);
            
            foreach (string quality in Quality)
                cmbQuality.Items.Add(quality);


            cmbJewelry.SelectedItem = "choose";

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow transaction = new MainWindow();

            this.Hide();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();

            AddCustomer addCustomer = new AddCustomer();

            addCustomer.Show();
        }

        private void cmbJewelry_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //switch (cmbJewelry.SelectedItem.ToString())
            //{
            //    case "Bracelet":
            //        txtPrice.Text = Convert.ToString(5000);
            //        break;
            //    case "Earrings":
            //        txtPrice.Text = Convert.ToString(2000);
            //        break;
            //    case "Ring":
            //        txtPrice.Text = Convert.ToString(3000);
            //        break;
            //    case "Necklace":
            //        txtPrice.Text = Convert.ToString(4000);
            //        break;
            //}
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            foreach (Person customer in data.customers)
                cmbCustomer.Items.Add(customer.GetFullName());
        }
    }
}
