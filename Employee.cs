using System;
using System.Data;
using System.Data.SqlClient;

namespace EAD_Assignment_05
{
    public class Employee
    {
        private readonly string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"E:\\BscsPUCIT\\BSCS 7th Semester\\EAD\\Assignments\\Assignment05\\EAD Assignment-05\\EAD Assignment-05\\AssignmentFive.mdf\";Integrated Security=True";

        public DataTable GetAllEmployees()
        {
            // Estabishing the new Connection.
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Employees";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    DataTable dataTable = new DataTable();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        dataTable.Load(reader);
                    }
                    return dataTable;
                }
            }
        }

        public void InsertEmployee(string firstName, string lastName, string email, string primaryPhone, string createdBy, DateTime createdOn)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Employees (FirstName, LastName, Email, PrimaryPhoneNumber, CreatedBy, CreatedOn) " +
                               "VALUES (@FirstName, @LastName, @Email, @PrimaryPhoneNumber, @CreatedBy, @CreatedOn)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@LastName", lastName);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@PrimaryPhoneNumber", primaryPhone);
                    command.Parameters.AddWithValue("@CreatedBy", createdBy);
                    command.Parameters.AddWithValue("@CreatedOn", createdOn);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteEmployee(long employeeId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Employees WHERE ID = @EmployeeId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeId", employeeId);
                    command.ExecuteNonQuery();
                }
            }
        }

        public DataRow GetEmployeeById(long employeeId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Employees WHERE ID = @EmployeeId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeId", employeeId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        return dataTable.Rows.Count > 0 ? dataTable.Rows[0] : null;
                    }
                }
            }
        }

        public void UpdateEmployee(long employeeId, string firstName, string lastName, string email, string primaryPhone, string modifiedBy, DateTime? modifiedOn)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE Employees " +
                               "SET FirstName = @FirstName, LastName = @LastName, Email = @Email, " +
                               "PrimaryPhoneNumber = @PrimaryPhoneNumber, ModifiedBy = @ModifiedBy, " +
                               "ModifiedOn = @ModifiedOn " +
                               "WHERE ID = @EmployeeId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeId", employeeId);
                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@LastName", lastName);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@PrimaryPhoneNumber", primaryPhone);
                    command.Parameters.AddWithValue("@ModifiedBy", modifiedBy);
                    command.Parameters.AddWithValue("@ModifiedOn", modifiedOn ?? (object)DBNull.Value);
                    command.ExecuteNonQuery();
                }
            }
        }

        // Implemantation using data Adapters




        public DataTable GetAllEmployeesWithDataAdapter()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Employees";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable;
                }
            }
        }

        public void InsertEmployeeWithDataAdapter(string firstName, string lastName, string email, string primaryPhone, string createdBy, DateTime createdOn)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Employees (FirstName, LastName, Email, PrimaryPhoneNumber, CreatedBy, CreatedOn) " +
                               "VALUES (@FirstName, @LastName, @Email, @PrimaryPhoneNumber, @CreatedBy, @CreatedOn)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@LastName", lastName);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@PrimaryPhoneNumber", primaryPhone);
                    command.Parameters.AddWithValue("@CreatedBy", createdBy);
                    command.Parameters.AddWithValue("@CreatedOn", createdOn);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteEmployeeWithDataAdapter(long employeeId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Employees WHERE ID = @EmployeeId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeId", employeeId);
                    command.ExecuteNonQuery();
                }
            }
        }

        public DataTable GetEmployeeByIdWithDataAdapter(long employeeId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Employees WHERE ID = @EmployeeId";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@EmployeeId", employeeId);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable;
                }
            }
        }

        public void UpdateEmployeeWithDataAdapter(long employeeId, string firstName, string lastName, string email, string primaryPhone, string modifiedBy, DateTime? modifiedOn)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE Employees " +
                               "SET FirstName = @FirstName, LastName = @LastName, Email = @Email, " +
                               "PrimaryPhoneNumber = @PrimaryPhoneNumber, ModifiedBy = @ModifiedBy, " +
                               "ModifiedOn = @ModifiedOn " +
                               "WHERE ID = @EmployeeId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeId", employeeId);
                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@LastName", lastName);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@PrimaryPhoneNumber", primaryPhone);
                    command.Parameters.AddWithValue("@ModifiedBy", modifiedBy);
                    command.Parameters.AddWithValue("@ModifiedOn", modifiedOn ?? (object)DBNull.Value);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
