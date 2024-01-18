using System;
using Zadacha_17_01_2024_Bankova_smetki;

namespace MyApp 
{
    internal class Program
    {
        static void Main(string[] args)
        {

            bool isItEnd = true;

            List<Customer> customers = new List<Customer>();
            List<Account> accounts = new List<Account>();

            // Примери за създаване на сметки и изчисляване на лихвата
            /*
            Customer individualCustomer = new Customer("Иван Иванов", CustomerType.Individual);
            Customer companyCustomer = new Customer("Фирма ABC", CustomerType.Company);

            DepositAccount individualDeposit = new DepositAccount(individualCustomer, 1500, 0.02m);
            CreditAccount individualCredit = new CreditAccount(individualCustomer, 2000, 0.05m);
            MortgageAccount companyMortgage = new MortgageAccount(companyCustomer, 50000, 0.03m);

            Console.WriteLine("Лихвата за депозитната сметка на Иван Иванов след 6 месеца е: " + individualDeposit.CalculateInterest(6));
            Console.WriteLine("Лихвата за кредитната сметка на Иван Иванов след 5 месеца е: " + individualCredit.CalculateInterest(5));
            Console.WriteLine("Лихвата за ипотечната сметка на Фирма ABC след 18 месеца е: " + companyMortgage.CalculateInterest(18));
            */

            Console.WriteLine("Menu:\r\n1. Add customer\r\n2. Create Account\r\n3. Calculate Interest \r\n4. Exit");
            Console.WriteLine("Enter choice:");

            while (isItEnd)
            {
                string input = Console.ReadLine();

                int convertedInput = Convert.ToInt32(input);

                if (convertedInput > 0 && convertedInput < 4)
                {
                    if (convertedInput == 1)
                    {
                        //Add customer

                        Console.WriteLine("What is the name of the new customer:");
                        string name = Console.ReadLine();

                        Console.WriteLine("What is the type (individual/company) of the new customer:");
                        string type = Console.ReadLine();

                        bool isItCorrectType = false;

                        if (type.ToLower().Equals("individual") || type.ToLower().Equals("company"))
                        {
                            isItCorrectType = true;
                        }
                        while (!isItCorrectType)
                        {
                            Console.WriteLine("Wrong input! Try again.");
                            Console.WriteLine("What is the type (individual/company) of the new customer:");
                            type = Console.ReadLine();

                            if (type.ToLower().Equals("individual") || type.ToLower().Equals("company"))
                            {
                                isItCorrectType = true;
                            }
                        }
                        

                        CustomerType customerTypeIndividual = CustomerType.Individual;
                        CustomerType customerTypeCompany = CustomerType.Company;

                        if (type.ToLower().Equals("individual"))
                        {
                            Customer customerIndividual = new Customer(name, customerTypeIndividual);
                            customers.Add(customerIndividual);
                        }
                        else
                        {
                            Customer customerCompany = new Customer(name, customerTypeCompany);
                            customers.Add(customerCompany);
                        }


                    }
                    else if (convertedInput == 2)
                    {
                        /*   private Customer owner;
                             private decimal balance;
                             private decimal monthlyInterestRate;
                        */

                        // Add Account

                        Console.WriteLine("What is the name of the customer:");
                        string nameOfCustomer = Console.ReadLine();

                        bool isFoundName = false;
                        Customer owner = new Customer("T", CustomerType.Individual);

                        foreach (var c in customers)
                        {
                            if (c.GetName().Equals(nameOfCustomer))
                            {
                                isFoundName = true;
                                owner = c;                               
                            }
                        }

                        while (!isFoundName)
                        {
                            Console.WriteLine("Customer not found! Try again.");
                            Console.WriteLine("What is the name of the customer:");
                            nameOfCustomer = Console.ReadLine();

                            isFoundName = false;

                            foreach (var c in customers)
                            {
                                if (c.GetName().Equals(nameOfCustomer))
                                {
                                    isFoundName = true;
                                }
                            }
                        }

                        

                            Console.WriteLine("What is the balance of the customer:");
                            string inputBalance = Console.ReadLine();

                            decimal falseResult = -1.00m;

                            while (!Decimal.TryParse(inputBalance, out falseResult))
                            {
                                Console.WriteLine("Wrong input! Try again!");
                                Console.WriteLine("What is the balance of the customer:");
                                inputBalance = Console.ReadLine();
                            }

                            while (!(Convert.ToDecimal(inputBalance) > 0))
                            {
                                Console.WriteLine("Wrong input! Try again!");
                                Console.WriteLine("What is the balance of the customer:");
                                inputBalance = Console.ReadLine();
                            }

                            decimal balanceOfCustomer = Convert.ToDecimal(inputBalance);

                            Console.WriteLine("What is the monthly interest rate of the customer:");
                            string monthlyInterestRate = Console.ReadLine();

                            decimal falseResult2 = -1.00m;

                            while (!Decimal.TryParse(monthlyInterestRate, out falseResult2))
                            {
                                Console.WriteLine("Wrong input! Try again!");
                                Console.WriteLine("What is the monthly interest rate of the customer:");
                                monthlyInterestRate = Console.ReadLine();
                            }

                            while (!(Convert.ToDecimal(monthlyInterestRate) > 0))
                            {
                                Console.WriteLine("Wrong input! Try again!");
                                Console.WriteLine("What is the monthly interest rate of the customer:");
                                monthlyInterestRate = Console.ReadLine();
                            }

                            decimal monthlyInterestRateOfCustomer = Convert.ToDecimal(monthlyInterestRate);


                            Console.WriteLine("What is the type of account you wanna create(credit/deposit/mortgage):");
                            string creditType = Console.ReadLine();

                            bool isItCorrectCreditType = false;

                            if (creditType.ToLower().Equals("credit") || creditType.ToLower().Equals("deposit") || creditType.ToLower().Equals("mortgage"))
                            {
                                isItCorrectCreditType = true;
                            }
                            while (!isItCorrectCreditType)
                            {
                                Console.WriteLine("Wrong input! Try again.");
                                Console.WriteLine("What is the type of account you wanna create(credit/deposit/mortgage):");
                                creditType = Console.ReadLine();
                                if (creditType.ToLower().Equals("credit") || creditType.ToLower().Equals("deposit") || creditType.ToLower().Equals("mortgage"))
                                {
                                    isItCorrectCreditType = true;
                                }
                            }                         

                            if (creditType.ToLower().Equals("credit"))
                            {
                                Account creditAccount = new CreditAccount(owner, balanceOfCustomer, monthlyInterestRateOfCustomer);
                                accounts.Add(creditAccount);
                            }
                            else if (creditType.ToLower().Equals("deposit"))
                            {
                                Account depositAccount = new DepositAccount(owner, balanceOfCustomer, monthlyInterestRateOfCustomer);
                                accounts.Add(depositAccount);
                            }
                            else
                            {
                                Account mortgageAccount = new MortgageAccount(owner, balanceOfCustomer, monthlyInterestRateOfCustomer);
                                accounts.Add(mortgageAccount);
                            }

                        
                        
                    }
                    else if (convertedInput == 3)
                    {
                        //Calculate Interest                    

                        Console.WriteLine("What is the name of the customer:");
                        string nameOfCustomer = Console.ReadLine();

                        bool isFoundName = false;
                        Customer owner = new Customer("T", CustomerType.Individual);

                        foreach (var c in customers)
                        {
                            if (c.GetName().Equals(nameOfCustomer))
                            {
                                isFoundName = true;
                                owner = c;
                                break;
                            }
                        }

                        while (!isFoundName)
                        {
                            Console.WriteLine("Customer not found! Try again.");
                            Console.WriteLine("What is the name of the customer:");
                            nameOfCustomer = Console.ReadLine();

                            isFoundName = false;

                            foreach (var c in customers)
                            {
                                if (c.GetName().Equals(nameOfCustomer))
                                {
                                    isFoundName = true;
                                }
                            }
                        }

                            Console.WriteLine("How many months you want to calculate:");
                            int inputTime = Int32.Parse(Console.ReadLine());

                            while (inputTime <= 0)
                            {
                                Console.WriteLine("Wrong input! Try again!");
                                Console.WriteLine("How many months you want to calculate:");
                                inputTime = Int32.Parse(Console.ReadLine());
                            }



                            Console.WriteLine("What is the type of account you wanna create(credit/deposit/mortgage):");
                            string creditType = Console.ReadLine();

                            bool isItCorrectCreditType = false;

                            if (creditType.ToLower().Equals("credit") || creditType.ToLower().Equals("deposit") || creditType.ToLower().Equals("mortgage"))
                            {
                                isItCorrectCreditType = true;
                            }
                            while (!isItCorrectCreditType)
                            {
                                Console.WriteLine("Wrong input! Try again.");
                                Console.WriteLine("What is the type of account you wanna check(credit/deposit/mortgage):");
                                creditType = Console.ReadLine();

                            if (creditType.ToLower().Equals("credit") || creditType.ToLower().Equals("deposit") || creditType.ToLower().Equals("mortgage"))
                            {
                                isItCorrectCreditType = true;
                            }
                        }

                            bool isItFoundAccount = false;
                            bool didItBreak = false;
                            
                            int lastAccountIndex = accounts.Count();
                            int i = 0;

                        while (!isItFoundAccount && !didItBreak)
                        {
                            foreach (var ac in accounts)
                            {
                                if (ac.GetOwner().GetName().Equals(owner.GetName()) && ac.GetTypeName().Equals(creditType))
                                {
                                    isItFoundAccount = true;
                                    Console.WriteLine("Лихвата за сметкага за зададеният период е " + ac.CalculateInterest(inputTime));
                                    break;
                                }
                                else
                                {
                                    i++;
                                    if (i == lastAccountIndex)
                                    {
                                        Console.WriteLine("Account is not found! Sorry.");
                                        didItBreak = true;                                       
                                    }
                                }

                            }
                        }                                             
                    }

                    Console.WriteLine("Menu:\r\n1. Add customer\r\n2. Create Account\r\n3. Calculate Interest \r\n4. Exit");
                    Console.WriteLine("Enter choice:");
                }
                else if (convertedInput == 4)
                {
                    isItEnd = false;
                    break;
                }
                else
                {
                    Console.WriteLine("Not valid input! Try again!");
                    Console.WriteLine("Menu:\r\n1. Add customer\r\n2. Create Account\r\n3. Calculate Interest \r\n4. Exit");
                    Console.WriteLine("Enter choice:");
                }

            }

        }

    }
}
