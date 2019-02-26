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

            AddTransaction Add = new AddTransaction();

            Add.Customer = new Person(this.txtFirstName.Text, this.txtMiddleInitial.Text, this.txtLastName.Text);
            CustomerFullName = Add.Customer.GetFullName();


            Add.Show();
        }
    }
}
