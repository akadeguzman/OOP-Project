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
using OOP_Project;
using System.IO;

namespace OOP_Project_Updated
{
    /// <summary>
    /// Interaction logic for AddCustomer.xaml
    /// </summary>
    public partial class AddCustomer : Window
    {
        
        public MainWindow main;
        public string CustomerFullName;
        public Person Customer;
        public AddCustomer()
        {
            InitializeComponent();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

            string filePath = @"C:\Users\Adrian\Documents\GitHub\OOP-Project\OOP-Project-update-master\OOP Project Updated\OOP Project Updated\TextFiles\Customers.txt";

            List<string> customer = File.ReadAllLines(filePath).ToList();
            AddTransaction Add = new AddTransaction();

            Add.Customer = new Person(this.txtFirstName.Text, this.txtMiddleInitial.Text, this.txtLastName.Text);
            CustomerFullName = Add.Customer.GetFullName();
            Add.Customer.Address = txtAddress.Text;
            Add.Customer.ContactNumber = txtContactNumber.Text;
                        
            customer.Add(CustomerFullName);
            customer.Add(Add.Customer.Address);
            customer.Add(Add.Customer.ContactNumber);

            File.WriteAllLines(filePath, customer);

                   
            //---------------------------------------------------

            List<string> output = new List<string>();

            foreach (var info in customer)
            {
                output.Add($"{CustomerFullName},{Add.Customer.Address},{Add.Customer.ContactNumber}");
            }

            File.WriteAllLines(filePath, output);

            //---------------------------------------------------

            List<string> lines = File.ReadAllLines(filePath).ToList();

            foreach (var line in lines)
            {
                string[] entries = line.Split(',');

                CustomerFullName = entries[0];
            }
            Add.cmbCustomer.Items.Add(CustomerFullName);

            Add.Show();
        }
    }
}
