using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadacha_17_01_2024_Bankova_smetki
{
    internal abstract class Account:IAccount
    {
        private Customer owner;
        private decimal balance;
        private decimal monthlyInterestRate;

        public Account(Customer owner, decimal balance, decimal monthlyInterestRate)
        {
            this.owner = owner;
            this.balance = balance;
            this.monthlyInterestRate = monthlyInterestRate;
        }

        public abstract string GetTypeName();
        public Customer GetOwner()
        {
            return owner;
        }

        public decimal GetBalance()
        {
            return balance;
        }

        public decimal GetMonthlyInterestRate()
        {
            return monthlyInterestRate;
        }

        public void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                balance += amount;
            }
            else
            {
                throw new ArgumentException("Amount must be positive.");
            }
        }

        public void Withdraw(decimal amount)
        {
            if (amount > 0 && amount <= balance)
            {
                balance -= amount;
            }
            else
            {
                throw new ArgumentException("Invalid withdrawal amount.");
            }
        }

        public abstract decimal CalculateInterest(int months);
    }
}
