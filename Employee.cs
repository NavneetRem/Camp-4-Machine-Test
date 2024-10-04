using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camp4_MachineTest
{
    public class Employee : IPayable
    {
        public int AccountNumber { get; set; }
        public string EmployeeName { get; set; }
        private decimal balance;

        public Employee(int accountNumber, string name)
        {
            AccountNumber = accountNumber;
            EmployeeName = name;
            balance = 0; // Initial balance is 0
        }

        // Implementing Deposit method
        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Deposit amount must be greater than zero.");
            }
            balance += amount;
            Console.WriteLine($"{amount:C} deposited. Current balance: {balance:C}");
        }

        // Implementing Withdraw method
        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Withdrawal amount must be greater than zero.");
            }
            if (amount > balance)
            {
                throw new InvalidOperationException("Insufficient funds for withdrawal.");
            }
            balance -= amount;
            Console.WriteLine($"{amount:C} withdrawn. Current balance: {balance:C}");
        }

        // Implementing CheckBalance method
        public decimal CheckBalance()
        {
            return balance;
        }
    }

}
