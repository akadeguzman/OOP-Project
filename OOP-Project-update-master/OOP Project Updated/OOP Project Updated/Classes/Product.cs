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
        private string Condition;
        private string Quality;
        private decimal Price;
        private decimal Weight;
        private decimal Discount;
        private int Items;

        public string GetName { get; set; }       
        public string GetCondition { get; set; } 
        public decimal GetWeight { get; set; }
        public decimal GetPrice { get; set; }
        public string GetQuality { get; set; }

        public void DeductItems(int items = 0)
         {
                if (items != 0)
                    Items = Items - items;
                else
                    Items--;
                Console.WriteLine(Items);
         }

        
    }

}
