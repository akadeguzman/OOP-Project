using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OOP_Project
{
    public class Product
    {
        protected string Name;
        private decimal Price;
        private decimal Weight;
        private string Quality;
        private int Items;

        public string GetName { get; set; }       
        public decimal GetWeight { get; set; }
        public decimal GetPrice { get; set; }
        public string GetQuality { get; set; }
                       
    }

}
