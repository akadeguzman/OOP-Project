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
        public Product product = new Product();
        public Settings Settings;
        public DataStorage data = new DataStorage();

        List<string> JewelryType = new List<string> { "Bracelet", "Necklace", "Earrings", "Ring" };
        List<string> Condition = new List<string> { "Scratched", "Broken Locks", "Missing Stones", "Dented" };
        List<string> Quality = new List<string> { "10k", "18k", "21k" };

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
            MainWindow loanTransaction = new MainWindow();

            //-------------------------------------------------------------------

            

            


            this.Hide();
            loanTransaction.Show();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Hide();

            AddCustomer addCustomer = new AddCustomer();
            
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
                    
                    break;

                case "18k":
                    product.GetQuality = "18k";
                    
                    break;

                case "21k":
                    product.GetQuality = "21k";
                   
                    break;

            }
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            foreach (Person person in data.customers)
                txtDisplay.Text = person.GetFullName();
        }
    }
}
