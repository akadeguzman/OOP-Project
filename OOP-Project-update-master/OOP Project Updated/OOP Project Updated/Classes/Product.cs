using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project
{
    public class Product
    {
        public string Name;
        public string Description;
        public string Manufacture;
        public decimal Price;
        public int Items;
        public decimal MonthlyInterestRate;
        public int InvItems;

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
