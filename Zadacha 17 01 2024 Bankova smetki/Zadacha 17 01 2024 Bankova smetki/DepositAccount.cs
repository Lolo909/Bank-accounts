using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadacha_17_01_2024_Bankova_smetki
{
    internal class DepositAccount:Account
    {
        private readonly string typeName = "deposit";
        public DepositAccount(Customer owner, decimal balance, decimal monthlyInterestRate)
       : base(owner, balance, monthlyInterestRate)
        {
        }

        public override decimal CalculateInterest(int months)
        {
            if (GetBalance() < 1000)
            {
                return 0;
            }

            return GetBalance() * (1 + GetMonthlyInterestRate() * months);
        }

        public override string GetTypeName()
        {
            return typeName;
        }
    }
}
