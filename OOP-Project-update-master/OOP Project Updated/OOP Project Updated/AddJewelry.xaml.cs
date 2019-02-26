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
    /// Interaction logic for AddJewelry.xaml
    /// </summary>
    public partial class AddJewelry : Window
    {
        public Product Jewelry = new Product();
        public string[] JewelryType = { "Bracelet", "Necklace", "Earrings", "Ring" };
        public AddJewelry()
        {
            InitializeComponent();
            foreach (string type in JewelryType)
                cmbType.Items.Add(type);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();

            MainWindow main = new MainWindow();

            main.Show();
        }
    }
}
