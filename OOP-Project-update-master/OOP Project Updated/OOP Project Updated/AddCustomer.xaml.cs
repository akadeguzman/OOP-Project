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
        public Person Customer;
        public DataStorage data = new DataStorage();
        public string MobileNumber = "+63";

        public AddCustomer()
        {
            InitializeComponent();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {

            //string filePath = @"C:\Users\Adrian\Documents\GitHub\OOP-Project\OOP-Project-update-master\OOP Project Updated\OOP Project Updated\TextFiles\Customers.txt";
            //string CustName = @"C:\Users\Adrian\Documents\GitHub\OOP-Project\OOP-Project-update-master\OOP Project Updated\OOP Project Updated\TextFiles\CustomerName.txt";

           
                AddTransaction Add = new AddTransaction();

                
            Person Customer = new Person(this.txtFirstName.Text, this.txtMiddleInitial.Text, this.txtLastName.Text, this.txtAddress.Text, this.txtContactNumber.Text);

            

            if (txtContactNumber.Text.Length == 10)
            {
                //---------------------------------------------------

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

                //----------------------------------------------------
                MobileNumber += txtContactNumber.Text;

                data.customers.Add(Customer);

                Add.cmbCustomer.Items.Add(Customer.GetFullName());
                

                this.Close();
                Add.Show();
            }
            else
            {
                MessageBox.Show("Incorrect Mobile Number. Please Try Again", "Incorrect Details", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
            }

            
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            SnackbarThree.MessageQueue.Enqueue("Customer Added Successfully");
        }

        
    }
}
