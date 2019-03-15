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
    /// Interaction logic for PaymentTransaction.xaml
    /// </summary>
    public partial class PaymentTransaction : Window
    {
        public DataStorage data;
        public Product product;

        public PaymentTransaction()
        {
            InitializeComponent();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            AddPayment payment = new AddPayment();
            {
                payment.data = data;
            }
            data.counter.Clear();
            payment.Show();
            this.Hide();
        }

        private void BtnPay_Click(object sender, RoutedEventArgs e)
        {
            product.GetCounter = data.counter[0];

            decimal computations = Convert.ToDecimal(txtPaidAmount.Text) - Convert.ToDecimal(txtBalance.Text);

            txtBalance.Text = computations.ToString();

            data.finalDetails[product.GetCounter][10] = txtBalance.Text;

            txtBalance.Text = data.finalDetails[product.GetCounter][10];
        }
    }
}
