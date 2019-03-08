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
    public partial class Settings : Window
    {
        public Product Quality10k = new Product();
        public Product Quality18k = new Product();
        public Product Quality21k = new Product();
        
        public Settings()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow main = new MainWindow();
            
            Quality10k.GetPrice = Convert.ToDecimal(Necklace10k.Text);
            Quality18k.GetPrice = Convert.ToDecimal(Necklace18k.Text);
            Quality21k.GetPrice = Convert.ToDecimal(Necklace21k.Text);


            main.Show();
        }
    }
}
