using EAD_Assignment_05;
using System;
using System.Data;

namespace EAD_Assignment_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee dataAccess = new Employee();

            Console.WriteLine("Select Data Access Method:");
            Console.WriteLine("1. Perform CRUD with SqlDataReader");
            Console.WriteLine("2. Perform CRUD with SqlDataAdapter");
            Console.Write("Enter your choice: ");

            if (int.TryParse(Console.ReadLine(), out int dataAccessChoice))
            {
                if (dataAccessChoice == 1)
                {
                    RunCRUDWithSqlDataReader(dataAccess);
                }
                else if (dataAccessChoice == 2)
                {
                    RunCRUDWithSqlDataAdapter(dataAccess);
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }

        static void RunCRUDWithSqlDataReader(Employee dataAccess)
        {
            while (true)
            {
                Console.WriteLine("Employee Database Menu with SqlDataReader:");
                Console.WriteLine("1. List All Employees");
                Console.WriteLine("2. Add Employee");
                Console.WriteLine("3. Delete Employee");
                Console.WriteLine("4. Update Employee");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            GetAllEmployees(dataAccess);
                            break;
                        case 2:
                            InsertEmployee(dataAccess);
                            break;
                        case 3:
                            DeleteEmployee(dataAccess);
                            break;
                        case 4:
                            UpdateEmployee(dataAccess);
                            break;
                        case 5:
                            return;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }

                Console.WriteLine();
            }
        }

        static void RunCRUDWithSqlDataAdapter(Employee dataAccess)
        {
            while (true)
            {
                Console.WriteLine("Employee Database Menu with SqlDataAdapter:");
                Console.WriteLine("1. List All Employees");
                Console.WriteLine("2. Add Employee");
                Console.WriteLine("3. Delete Employee");
                Console.WriteLine("4. Update Employee");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            ListAllEmployeesWithDataAdapter(dataAccess);
                            break;
                        case 2:
                            AddEmployeeWithDataAdapter(dataAccess);
                            break;
                        case 3:
                            DeleteEmployeeWithDataAdapter(dataAccess);
                            break;
                        case 4:
                            UpdateEmployeeWithDataAdapter(dataAccess);
                            break;
                        case 5:
                            return;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }

                Console.WriteLine();
            }
        }
    }
}


