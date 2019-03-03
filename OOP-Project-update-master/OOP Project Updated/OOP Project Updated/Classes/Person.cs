using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.IO;

namespace OOP_Project
{
    public class Person
    {
        private string FirstName;
        private string MiddleInitial;
        private string LastName;
        private string Address;
        private string MobileNumber = "+63";

        public string GetAddress { get; set; }        

        public Person(string firstName, string middleInitial, string lastName)
        {
            FirstName = firstName;
            MiddleInitial = middleInitial;
            LastName = lastName;
        }

        public static string GetTitleCase(string fullName)
        {
            string[] names = fullName.Split(' ');
            List<string> currentNameList = new List<string>();
            foreach (var name in names)
            {
                if (Char.IsUpper(name[0]))
                {
                    currentNameList.Add(name);
                }
                else
                {
                    currentNameList.Add(Char.ToUpper(name[0]) + name.Remove(0, 1));
                }
            }

            return string.Join(" ", currentNameList.ToArray()).Trim();
        }

        public string GetFullName()
        {
            LastName = GetTitleCase(LastName);
            FirstName = GetTitleCase(FirstName);

            return string.Format("{0} {1}. {2}", FirstName,
                MiddleInitial.ToString().ToUpper(), LastName);

        }

        public string GetMobileNumber
        {
                        
            get
            {
                return MobileNumber;
            }
            set
            {
                if (value.Length == 10)
                {
                    MobileNumber += value;
                }
                else
                    MobileNumber = " ";
                
            }
        }

    }
}
