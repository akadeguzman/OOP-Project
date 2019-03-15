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
        public List<string> transactionDetails = new List<string>();

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
            Receipt receipt = new Receipt();
            {
                receipt.data = data;
            }


            Random random = new Random();
            int randomGenerator = random.Next(10000000, 99999999);
            string randomNumber = randomGenerator.ToString();


            string[] initialDetails = new string[10];

            initialDetails[0] = cmbCustomer.Text;
            initialDetails[1] = product.GetName;
            initialDetails[2] = product.GetQuality;
            initialDetails[3] = txtCondition.Text;
            initialDetails[4] = txtWeight.Text;
            initialDetails[5] = txtdeductedWeight.Text;
            initialDetails[6] = txtAmountLoaned.Text;
            initialDetails[7] = txtDate.Text;
            initialDetails[8] = txtPrice.Text;
            initialDetails[9] = randomNumber;


            foreach (string details in initialDetails)
            {
                transactionDetails.Add(details);
            }

            data.finalDetails.Add(transactionDetails);

            receipt.txtName.Text = initialDetails[0];
            receipt.txtCondition.Text = initialDetails[3];
            receipt.txtDate.Text = initialDetails[7];
            receipt.txtDigits.Text = initialDetails[9];
            receipt.txtJewelry.Text = initialDetails[1];
            receipt.txtPriceJewelry.Text = initialDetails[8];
            receipt.txtWeight.Text = initialDetails[4];
            receipt.txtAmoutLoaned.Text = initialDetails[6];
                                    
            this.Hide();
            receipt.Show();

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
                    txtWeight.Clear();

                    break;

                case "18k":
                    product.GetQuality = "18k";
                    product.GetPrice = data.qualities[1];
                    txtWeight.Clear();

                    break;

                case "21k":
                    product.GetQuality = "21k";
                    product.GetPrice = data.qualities[2];
                    txtWeight.Clear();

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

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();

            this.Hide();
        }
    }
}
