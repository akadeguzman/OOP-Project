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
        public DataStorage data;
        
               
        public Settings()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow main = new MainWindow();
            {
                main.data = data;
            }

            decimal[] Qualities = new decimal[3];

            Qualities[0] = Convert.ToDecimal(Quality10k.Text);
            Qualities[1] = Convert.ToDecimal(Quality18k.Text);
            Qualities[2] = Convert.ToDecimal(Quality21k.Text);

            foreach (decimal quali in Qualities)
                data.qualities.Add(quali);

            main.Show();
        }
    }
}
