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
using System.IO;

namespace OOP_Project_Updated
{
    /// <summary>
    /// Interaction logic for AddTransaction.xaml
    /// </summary>
    public partial class AddTransaction : Window
    {     

        public MainWindow main;
        public Person Customer;
        public Settings Settings;
        public Product product = new Product();
        public DataStorage data;

        List<string> JewelryType = new List<string> { "Bracelet", "Necklace", "Earrings", "Ring" };
        List<string> Quality = new List<string> { "10k", "18k", "21k" };

        public AddTransaction()
        {
            InitializeComponent();
            foreach (string type in JewelryType)
                cmbJewelry.Items.Add(type);
                        
            foreach (string quality in Quality)
                cmbQuality.Items.Add(quality);

            cmbJewelry.SelectedItem = "choose";            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            {
                main.data = data;
            }

            string[] initialDetails = new string[8];

            cmbCustomer.Text = initialDetails[0];
            cmbJewelry.Text = initialDetails[1];
            cmbQuality.Text = initialDetails[2];
            txtCondition.Text = initialDetails[3];
            txtWeight.Text = initialDetails[4];
            txtdeductedWeight.Text = initialDetails[5];
            txtAmountLoaned.Text = initialDetails[6];
            txtDate.Text = initialDetails[7];
            txtPrice.Text = initialDetails[8];

            foreach (string details in initialDetails)
                data.transactionDetails.Add(details);
            
            this.Hide();
            main.Show();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AddCustomer addCustomer = new AddCustomer();
            {
                addCustomer.data = data;
            }
            
            addCustomer.Show();
        }

        private void CmbJewelry_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (cmbJewelry.SelectedItem.ToString())
            {
                case "Bracelet":
                    product.GetName = "Bracelet";
                    break;

                case "Earrings":
                    product.GetName = "Earrings";
                    break;

                case "Ring":
                    product.GetName = "Ring";
                    break;

                case "Necklace":
                    product.GetName = "Necklace";
                    break;
            }
        }

        private void CmbQuality_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (cmbQuality.SelectedItem.ToString())
            {
                case "10k":
                    product.GetQuality = "10k";
                    product.GetPrice = data.qualities[0];                   

                    break;

                case "18k":
                    product.GetQuality = "18k";
                    product.GetPrice = data.qualities[1];

                    break;

                case "21k":
                    product.GetQuality = "21k";
                    product.GetPrice = data.qualities[2];

                    break;

            }
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            cmbCustomer.Items.Clear();
            foreach (Person person in data.customers)
                cmbCustomer.Items.Add(person.GetFullName());

                                      
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                decimal initialWeight = Convert.ToDecimal(txtWeight.Text);
                decimal deductedWeight = Convert.ToDecimal(txtdeductedWeight.Text);

                decimal finalWeight = (initialWeight - deductedWeight);

                txtWeight.Text = finalWeight.ToString();

                decimal compute = product.GetPrice * Convert.ToDecimal(txtWeight.Text);
                txtPrice.Text = compute.ToString();

                                
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Weight field is required. Please input weight", "Missing Details", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
            }

        }
                
    }
}
