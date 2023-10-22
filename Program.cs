using EAD_Assignment_05;
using System.Data;

namespace EAD_Assignment_5
{
    class Program
    {

        // CRUD using SqlAdapter

        static void ListAllEmployees1(Employee empData)
        {
            DataTable employees = empData.GetAllEmployees1();
            Console.WriteLine("List of Employees:");
            Console.WriteLine("ID\tFirstName\tLastName\tEmail\tPrimaryPhoneNumber\tCreatedBy\tCreatedOn\tModifiedBy\tModifiedOn");

            // Iterating the DataTable row to get all the entities and display them.
            foreach (DataRow row in employees.Rows)
            {
                foreach (var item in row.ItemArray)
                {
                    Console.Write(item + "\t");
                }
                Console.WriteLine();
            }
        }


        static void AddEmployee1(Employee empData)
        {
            Console.Write("Enter First Name: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter Last Name: ");
            string lastName = Console.ReadLine();
            Console.Write("Enter Email: ");
            string email = Console.ReadLine();
            Console.Write("Enter Primary Phone Number: ");
            string primaryPhone = Console.ReadLine();
            Console.Write("Enter Created By: ");
            string createdBy = Console.ReadLine();
            DateTime createdOn = DateTime.Now;

            empData.InsertEmployee1(firstName, lastName, email, primaryPhone, createdBy, createdOn);
            Console.WriteLine("Employee added successfully using SqlDataReader. ");
        }

        static void DeleteEmployee1(Employee empData)
        {
            Console.Write("Enter Employee ID to delete: ");
            if (long.TryParse(Console.ReadLine(), out long employeeId))
            {
                empData.DeleteEmployee1(employeeId);
                Console.WriteLine("Employee deleted successfully using SqlDataReader.");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid ID.");
            }
        }

        static void UpdateEmployee1(Employee empData)
        {
            Console.Write("Enter Employee ID to update: ");
            if (long.TryParse(Console.ReadLine(), out long employeeId))
            {
                var employee = empData.GetEmployeeById1(employeeId);
                if (employee != null)
                {
                    Console.Write("Enter First Name: ");
                    string firstName = Console.ReadLine();
                    Console.Write("Enter Last Name: ");
                    string lastName = Console.ReadLine();
                    Console.Write("Enter Email: ");
                    string email = Console.ReadLine();
                    Console.Write("Enter Primary Phone Number: ");
                    string primaryPhone = Console.ReadLine();
                    Console.Write("Enter Modified By: ");
                    string modifiedBy = Console.ReadLine();
                    Console.Write("Enter Modified On (Leave empty for no change): ");
                    string modifiedOnStr = Console.ReadLine();

                    // Leave the space empty if you dont want to add modified date.
                    DateTime? modifiedOn = string.IsNullOrEmpty(modifiedOnStr) ? (DateTime?)null : DateTime.Parse(modifiedOnStr);

                    empData.UpdateEmployee1(employeeId, firstName, lastName, email, primaryPhone, modifiedBy, modifiedOn);
                    Console.WriteLine("Employee updated successfully using SqlDataReader.");
                }
                else
                {
                    Console.WriteLine("Employee not found with the given ID.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid ID.");
            }
        }

        // CRUD using SqlAdapter

        static void ListAllEmployees2(Employee empData)
        {
            DataTable employees = empData.GetAllEmployees2();

            Console.WriteLine("List of Employees:");
            Console.WriteLine("ID\tFirstName\tLastName\tEmail\tPrimaryPhoneNumber\tCreatedBy\tCreatedOn\tModifiedBy\tModifiedOn");

            foreach (DataRow row in employees.Rows)
            {
                Console.WriteLine($"{row["ID"]}\t{row["FirstName"]}\t{row["LastName"]}\t{row["Email"]}\t{row["PrimaryPhoneNumber"]}\t{row["CreatedBy"]}\t{row["CreatedOn"]}\t{row["ModifiedBy"]}\t{row["ModifiedOn"]}");
            }
        }

        static void AddEmployee2(Employee empData)
        {
            Console.WriteLine("Enter Employee Details:");
            Console.Write("First Name: ");
            string firstName = Console.ReadLine();
            Console.Write("Last Name: ");
            string lastName = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Primary Phone: ");
            string primaryPhone = Console.ReadLine();
            Console.Write("Created By: ");
            string createdBy = Console.ReadLine();
            DateTime createdOn = DateTime.Now;

            empData.InsertEmployee2(firstName, lastName, email, primaryPhone, createdBy, createdOn);

            Console.WriteLine("Employee added successfully.");
        }

        static void DeleteEmployee2(Employee empData)
        {
            Console.Write("Enter Employee ID to delete: ");
            if (long.TryParse(Console.ReadLine(), out long employeeId))
            {
                empData.DeleteEmployee2(employeeId);
                Console.WriteLine("Employee deleted successfully.");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid Employee ID.");
            }
        }

        static void UpdateEmployee2(Employee empData)
        {
            Console.Write("Enter Employee ID to update: ");
            if (long.TryParse(Console.ReadLine(), out long employeeId))
            {
                Console.WriteLine("Enter Updated Employee Details:");
                Console.Write("First Name: ");
                string firstName = Console.ReadLine();
                Console.Write("Last Name: ");
                string lastName = Console.ReadLine();
                Console.Write("Email: ");
                string email = Console.ReadLine();
                Console.Write("Primary Phone: ");
                string primaryPhone = Console.ReadLine();
                Console.Write("Modified By: ");
                string modifiedBy = Console.ReadLine();
                Console.Write("Enter Modified On (Leave empty for no change): ");
                string modifiedOnStr = Console.ReadLine();

                // Leave the space empty if you dont want to add modified date.
                DateTime? modifiedOn = string.IsNullOrEmpty(modifiedOnStr) ? (DateTime?)null : DateTime.Parse(modifiedOnStr);

                empData.UpdateEmployee2(employeeId, firstName, lastName, email, primaryPhone, modifiedBy, modifiedOn);
                Console.WriteLine("Employee updated successfully.");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid Employee ID.");
            }
        }



        // Main

        static void Main(string[] args)
        {
            Employee empData = new Employee();

            Console.WriteLine("Select Data Access Method:");
            Console.WriteLine("1. Perform CRUD with SqlDataReader");
            Console.WriteLine("2. Perform CRUD with SqlDataAdapter");
            Console.Write("Enter your choice: ");

            int operationChoice = int.Parse(Console.ReadLine());

            if (operationChoice == 1)
            {
                CRUD_DataReader(empData);
            }
            else if (operationChoice == 2)
            {
                CRUD_DataAdapter(empData);
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }

        }



        // Seperate functions containing Menus for both kind of CRUD Operations whether using SqlDataReader or SqlDataAdapter.


        static void CRUD_DataReader(Employee empData)
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

                int crudChoice = int.Parse(Console.ReadLine());

                switch (crudChoice)
                {
                    case 1:
                        ListAllEmployees1(empData);
                        break;
                    case 2:
                        AddEmployee1(empData);
                        break;
                    case 3:
                        DeleteEmployee1(empData);
                        break;
                    case 4:
                        UpdateEmployee1(empData);
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine();
            }
        }

        static void CRUD_DataAdapter(Employee empData)
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

                int crudChoice = int.Parse(Console.ReadLine());

                switch (crudChoice)
                {
                    case 1:
                        ListAllEmployees2(empData);
                        break;
                    case 2:
                        AddEmployee2(empData);
                        break;
                    case 3:
                        DeleteEmployee2(empData);
                        break;
                    case 4:
                        UpdateEmployee2(empData);
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine();
            }
        }
    }
}


