using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project
{
    public class Calculations
    {
        public static int CalculateAge(string birthDate, bool returnInMonths = true)
        {
            int age = 0;
            int ageInMonths = 0;

            DateTime today = Convert.ToDateTime("26/11/2018");
            DateTime past = Convert.ToDateTime(birthDate);

            age = today.Year - past.Year;
            ageInMonths = today.Month - past.Month;

            if (today.DayOfYear < past.DayOfYear)
                age = age - 1;

            else if (returnInMonths)
            {
                if (age <= 0 && today.Month > past.Month)
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
            decimal accruedAmount = principalAmount + (CalculateInterest(principalAmount, monthlyRate) * CalculateAge(date, true));
            accruedAmount = decimal.Round(accruedAmount, 0);
            return accruedAmount;
        }
    }
}
