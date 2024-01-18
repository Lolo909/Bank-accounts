using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadacha_17_01_2024_Bankova_smetki
{
    internal class MortgageAccount:Account
    {
        private readonly string typeName = "mortage";
        public MortgageAccount(Customer owner, decimal balance, decimal monthlyInterestRate)
       : base(owner, balance, monthlyInterestRate)
        {
        }

        public override decimal CalculateInterest(int months)
        {
            if (GetOwner().GetType() == CustomerType.Individual)
            {
                if (months <= 6)
                {
                    return 0;
                }
                else
                {
                    return GetBalance() * (1 + GetMonthlyInterestRate() * (months - 6));
                }
            }
            else if (GetOwner().GetType() == CustomerType.Company)
            {
                if (months <= 12)
                {
                    return GetBalance() * (1 + GetMonthlyInterestRate() * months * 0.5m);
                }
                else
                {
                    return GetBalance() * (1 + GetMonthlyInterestRate() * 12 * 0.5m + GetMonthlyInterestRate() * (months - 12));
                }
            }

            return 0;
        }

        

        public override string GetTypeName()
        {
            return typeName;
        }
    }
}
