using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadacha_17_01_2024_Bankova_smetki
{
    internal class CreditAccount:Account
    {
        private readonly string typeName = "credit";
        public CreditAccount(Customer owner, decimal balance, decimal monthlyInterestRate)
       : base(owner, balance, monthlyInterestRate)
        {
        }

        public override decimal CalculateInterest(int months)
        {
            if (GetOwner().GetType() == CustomerType.Individual)
            {
                if (months <= 3)
                {
                    return 0;
                }
                else
                {
                    return GetBalance() * (1 + GetMonthlyInterestRate() * (months - 3));
                }
            }
            else if (GetOwner().GetType() == CustomerType.Company)
            {
                if (months <= 2)
                {
                    return 0;
                }
                else
                {
                    return GetBalance() * (1 + GetMonthlyInterestRate() * (months - 2));
                }
            }

            return 0;
        }

        public override string GetTypeName() { 
        return typeName;
        }
    }
}
