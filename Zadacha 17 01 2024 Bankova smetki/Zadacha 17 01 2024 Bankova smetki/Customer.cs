using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadacha_17_01_2024_Bankova_smetki
{
    internal class Customer
    {
        private string name;
        private CustomerType type;

        public Customer(string name, CustomerType type)
        {
            this.name = name;
            this.type = type;
        }

        public string GetName()
        {
            return name;
        }

        public CustomerType GetType()
        {
            return type;
        }
    }
}
