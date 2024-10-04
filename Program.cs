using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camp4_MachineTest
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;  // Required for Regex

    public class Program
    {
        // Dictionary to store Employee account details
        private static Dictionary<int, Employee> employees = new Dictionary<int, Employee>();

        public static void Main()
        {
            bool continueAddingEmployees = true;

            // Add Employees during runtime
            while (continueAddingEmployees)
            {
                try
                {
                    Console.WriteLine("\nAdding a new Employee...");

                    // Input and validation for Account Number
                    Console.Write("Enter Account Number: ");
                    int accountNumber = int.Parse(Console.ReadLine());

                    if (employees.ContainsKey(accountNumber))
                    {
                        Console.WriteLine("Account Number already exists. Please try again.");
                        continue;
                    }

                    // Input and validation for Employee Name
                    Console.Write("Enter Employee Name: ");
                    string employeeName = Console.ReadLine();

                    if (!IsValidName(employeeName))
                    {
                        throw new ArgumentException("Name can only contain alphabetic characters and spaces.");
                    }

                    // Create a new Employee object and add it to the collection
                    employees.Add(accountNumber, new Employee(accountNumber, employeeName));

                    Console.Write("Would you like to add another employee? (y/n): ");
                    string input = Console.ReadLine();
                    continueAddingEmployees = input.ToLower() == "y";
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a numeric value for Account Number.");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                }
            }

            // Once employees are added, display options to interact with them
            bool continueSession = true;

            while (continueSession)
            {
                try
                {
                    Console.WriteLine("\nATM Interface");
                    Console.WriteLine("-------------\n");
                    Console.Write("Enter Account Number: ");
                    int accountNumber = int.Parse(Console.ReadLine());

                    if (!employees.ContainsKey(accountNumber))
                    {
                        Console.WriteLine("Invalid Account Number. Try again.");
                        continue;
                    }

                    Employee emp = employees[accountNumber];
                    Console.WriteLine($"\nWelcome, {emp.EmployeeName}!");

                    bool showMenu = true;

                    // Loop for choices until the user chooses to exit or log out
                    while (showMenu)
                    {
                        Console.WriteLine("\nChoose an option:");
                        Console.WriteLine("1. Deposit Amount");
                        Console.WriteLine("2. Withdraw Amount");
                        Console.WriteLine("3. Check Balance");
                        Console.WriteLine("4. Logout");
                        Console.WriteLine("5. Exit");
                        Console.Write("Enter choice: ");
                        int choice = int.Parse(Console.ReadLine());

                        switch (choice)
                        {
                            case 1:
                                Console.Write("Enter deposit amount: ");
                                decimal depositAmount = decimal.Parse(Console.ReadLine());
                                emp.Deposit(depositAmount);
                                break;

                            case 2:
                                Console.Write("Enter withdrawal amount: ");
                                decimal withdrawAmount = decimal.Parse(Console.ReadLine());
                                emp.Withdraw(withdrawAmount);
                                break;

                            case 3:
                                Console.WriteLine($"Current balance: {emp.CheckBalance():C}");
                                break;

                            case 4: // Logout case
                                Console.WriteLine("Logging out...");
                                showMenu = false; // Breaks out of the menu to prompt for another account number
                                break;

                            case 5: // Exit case
                                showMenu = false;
                                continueSession = false; // Ends the outer loop as well, terminating the program
                                Console.WriteLine("Goodbye!");
                                break;

                            default:
                                Console.WriteLine("Invalid choice. Please try again.");
                                break;
                        }
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input format. Please enter numeric values.");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine($"Operation failed: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                }
            }
        }

        // Method to validate if the name only contains alphabetic characters and spaces
        private static bool IsValidName(string name)
        {
            // Regex to check if the name contains only letters and spaces
            return Regex.IsMatch(name, @"^[a-zA-Z\s]+$");
        }
    }
}
