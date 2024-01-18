using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadacha_17_01_2024_Bankova_smetki
{
    internal interface IAccount
    {
        void Deposit(decimal amount);
        void Withdraw(decimal amount);
        decimal CalculateInterest(int months);
        
    }
}
