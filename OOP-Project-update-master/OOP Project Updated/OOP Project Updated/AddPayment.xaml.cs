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
using System.Threading;

namespace OOP_Project_Updated
{
    /// <summary>
    /// Interaction logic for AddPayment.xaml
    /// </summary>
    public partial class AddPayment : Window
    {
        public DataStorage data;
        public PaymentTransaction PaymentTransaction;
        public Product product = new Product();


        public AddPayment()
        {
            InitializeComponent();
        }


        private void TxtUnique8DigitNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtUnique8DigitNumber.Text.Length > 8)
            {

            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Hide();
        }

        private void BtnVerify_Click(object sender, RoutedEventArgs e)
        {
            btnVerify.IsEnabled = Progress.IsIndeterminate = true;
            int i = 0;
            for (i = 0; i < data.finalDetails.Count; i++)
            {
                data.finalDetails[i].Contains(txtUnique8DigitNumber.ToString());

                if (txtUnique8DigitNumber.Text == data.finalDetails[i][9].ToString())
                {
                    PaymentTransaction paymentTransaction = new PaymentTransaction();
                    paymentTransaction.data = data;

                    var accumulated = Calculations.CalculateAccruedAmount(Convert.ToDecimal(data.finalDetails[i][6]), 12M, data.finalDetails[i][7], DateTime.Now.ToString());

                    data.finalDetails[i][10] = accumulated.ToString();

                    paymentTransaction.txtName.Text = data.finalDetails[i][0].ToString();
                    paymentTransaction.txtAmountBorrowed.Text = data.finalDetails[i][6].ToString();
                    paymentTransaction.txtJewelryDeposited.Text = data.finalDetails[i][1].ToString();
                    paymentTransaction.txtDateTransac.Text = data.finalDetails[i][7].ToString();
                    paymentTransaction.txtBalance.Text = data.finalDetails[i][10];

                    product.GetCounter = i;

                    data.counter.Add(product.GetCounter);

                    paymentTransaction.Show();
                    Thread.Sleep(1000);
                    this.Hide();
                    break;
                }
            }
                       
        }
    }

    class Calculations
    {
        public static int CalculateAge(string dateTransac, bool returnInMonths = true)
        {
            int age = 0;
            int ageInMonths = 0;

            DateTime today = Convert.ToDateTime(DateTime.Now);
            DateTime past = Convert.ToDateTime(dateTransac);
            age = today.Year - past.Year;
            ageInMonths = today.Month - past.Month;

            if (returnInMonths)
            {
                if (today.Month > past.Month)
                {
                    age = ageInMonths + 2;
                }
                else
                {
                    age = age * 12 + (ageInMonths);
                }
            }

            return age;
        }

        public static decimal CalculateInterest(decimal principalAmount, decimal monthlyRate)
        {
            var interest = principalAmount * (monthlyRate / 100);
            return interest = decimal.Round(interest, 0);
        }

        public static decimal CalculateAccruedAmount(decimal principalAmount, decimal monthlyRate, string birthDate, string date)
        {
            decimal accruedAmount = principalAmount + (CalculateInterest(principalAmount, monthlyRate) * CalculateAge(birthDate, true));
            accruedAmount = decimal.Round(accruedAmount, 0);
            return accruedAmount;
        }
    }
}
