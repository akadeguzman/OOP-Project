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
        public DataStorage data;

        public AddCustomer()
        {
            InitializeComponent();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {

            //string filePath = @"C:\Users\Adrian\Documents\GitHub\OOP-Project\OOP-Project-update-master\OOP Project Updated\OOP Project Updated\TextFiles\Customers.txt";
            //string CustName = @"C:\Users\Adrian\Documents\GitHub\OOP-Project\OOP-Project-update-master\OOP Project Updated\OOP Project Updated\TextFiles\CustomerName.txt";
                                        
            Person customer = new Person(txtFirstName.Text, txtMiddleInitial.Text, txtLastName.Text, txtAddress.Text, txtContactNumber.Text);

            bool exist = false;

            
            foreach (Person person in data.customers)
            {
                if (customer.GetFullName() == person.GetFullName())
                {
                    exist = true;
                }
                else
                    exist = false;
            }

            if (txtFirstName.Text == "" && txtLastName.Text == "" && txtMiddleInitial.Text == "")
            {
                exist = true;
            }
            else
                exist = false;

            if (exist == false)
            {
                
                if (txtContactNumber.Text.Length == 10)
                {
                    data.customers.Add(customer);
                    SnackbarThree.MessageQueue.Enqueue("Customer Added Successfully");
                }
                else
                {
                    MessageBox.Show("Incorrect Mobile Number. Please Try Again", "Incorrect Details", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                    txtContactNumber.Clear();
                }
                
            }
            else
            {
                MessageBox.Show("The name already exist or name space is blank. Please Try Again", "Incorrect Details", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                txtFirstName.Clear();
                txtLastName.Clear();
                txtMiddleInitial.Clear();
            }
                       
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TxtMiddleInitial_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            if (txtMiddleInitial.Text.Length > 1)
                
            if (MessageBox.Show("Incorrect Middle Initial. Must only contain INITIAL", "Check input", MessageBoxButton.OK) == MessageBoxResult.OK)
                {
                    txtMiddleInitial.Clear();
                }

                      
        }


        //List<string> output = File.ReadAllLines(filePath).ToList();
        //List<string> customer = new List<string>();
        //customer.Add(CustomerFullName);
        //customer.Add(Add.Customer.GetAddress);
        //customer.Add(CustomerContactNumber);

        //output.Add($"{CustomerFullName},{Add.Customer.GetAddress},{CustomerContactNumber}");

        //File.WriteAllLines(filePath, output);

        //---------------------------------------------------

        //List<string> list = File.ReadAllLines(CustName).ToList();


        //list.Add(CustomerFullName);

        //foreach (string items in list)
        //{
        //    Add.cmbCustomer.Items.Add(items);
        //}
        //File.WriteAllLines(CustName, list);

    }
}
