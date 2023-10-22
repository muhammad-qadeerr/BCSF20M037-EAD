using System.Data;
using System.Data.SqlClient;

namespace EAD_Assignment_05
{
    public class Employee
    {
        private readonly string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"E:\\BscsPUCIT\\BSCS 7th Semester\\EAD\\Assignments\\Assignment05\\EAD Assignment-05\\EAD Assignment-05\\AssignmentFive.mdf\";Integrated Security=True";

        public DataTable GetAllEmployees1()
        {
            // Estabishing the new Connection.
            SqlConnection conn = new SqlConnection(connectionString);  // In ADO.NET 

            // Opening a conn
            conn.Open();

            // To Run a Query - let query be

            string query = "SELECT * FROM Employees";
            SqlCommand command = new SqlCommand(query, conn); // Query, or conn vo conn jo isne use krna ha

            DataTable dataTable = new DataTable();

            // Above query will return some data for reading that data

            SqlDataReader reader = command.ExecuteReader();
                
            dataTable.Load(reader);

            // Closing the conn after reading data.
            conn.Close();

            return dataTable;
            
        }   

        public void InsertEmployee1(string firstName, string lastName, string email, string primaryPhone, string createdBy, DateTime createdOn)
        {
            SqlConnection conn = new SqlConnection(connectionString);
         
            conn.Open();
            string query = "INSERT INTO Employees (FirstName, LastName, Email, PrimaryPhoneNumber, CreatedBy, CreatedOn) " +
                            "VALUES (@FirstName, @LastName, @Email, @PrimaryPhoneNumber, @CreatedBy, @CreatedOn)";
            SqlCommand command = new SqlCommand(query, conn);

            command.Parameters.AddWithValue("@FirstName", firstName);
            command.Parameters.AddWithValue("@LastName", lastName);
            command.Parameters.AddWithValue("@Email", email);
            command.Parameters.AddWithValue("@PrimaryPhoneNumber", primaryPhone);
            command.Parameters.AddWithValue("@CreatedBy", createdBy);
            command.Parameters.AddWithValue("@CreatedOn", createdOn);
            command.ExecuteNonQuery();
            conn.Close();

        }

        public void DeleteEmployee1(long employeeId)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            
           conn.Open();
           string query = "DELETE FROM Employees WHERE ID = @EmployeeId";
           SqlCommand command = new SqlCommand(query, conn);
                
           command.Parameters.AddWithValue("@EmployeeId", employeeId);
           command.ExecuteNonQuery();
            conn.Close();


        }

        // Return Type will be DataRow, searching with id to get the whole row.
        public DataRow? GetEmployeeById1(long employeeId)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            
            conn.Open();
            string query = "SELECT * FROM Employees WHERE ID = @EmployeeId";
            SqlCommand command = new SqlCommand(query, conn);
                
            command.Parameters.AddWithValue("@EmployeeId", employeeId);
            SqlDataReader reader = command.ExecuteReader();
                   
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            conn.Close();
            return dataTable.Rows.Count > 0 ? dataTable.Rows[0] : null;
                      
           
        }

        public void UpdateEmployee1(long employeeId, string firstName, string lastName, string email, string primaryPhone, string modifiedBy, DateTime? modifiedOn)
        {
            SqlConnection conn = new SqlConnection(connectionString);
         
            conn.Open();
            string query = "UPDATE Employees " +
                           "SET FirstName = @FirstName, LastName = @LastName, Email = @Email, " +
                           "PrimaryPhoneNumber = @PrimaryPhoneNumber, ModifiedBy = @ModifiedBy, " +
                           "ModifiedOn = @ModifiedOn " +
                           "WHERE ID = @EmployeeId";
            SqlCommand command = new SqlCommand(query, conn);

            command.Parameters.AddWithValue("@EmployeeId", employeeId);
            command.Parameters.AddWithValue("@FirstName", firstName);
            command.Parameters.AddWithValue("@LastName", lastName);
            command.Parameters.AddWithValue("@Email", email);
            command.Parameters.AddWithValue("@PrimaryPhoneNumber", primaryPhone);
            command.Parameters.AddWithValue("@ModifiedBy", modifiedBy);
            command.Parameters.AddWithValue("@ModifiedOn", modifiedOn ?? (object)DBNull.Value);
            command.ExecuteNonQuery();
            conn.Close();

        }

        // Implemantation using data Adapters

        public DataTable GetAllEmployees2()
        {
            SqlConnection conn = new SqlConnection(connectionString);
           
            conn.Open();
            string query = "SELECT * FROM Employees";
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);

            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            conn.Close();
            return dataTable;

        }

        public void InsertEmployee2(string firstName, string lastName, string email, string primaryPhone, string createdBy, DateTime createdOn)
        {
            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();
            string query = "INSERT INTO Employees (FirstName, LastName, Email, PrimaryPhoneNumber, CreatedBy, CreatedOn) " +
                           "VALUES (@FirstName, @LastName, @Email, @PrimaryPhoneNumber, @CreatedBy, @CreatedOn)";

            SqlCommand command = new SqlCommand(query, conn);
               
             command.Parameters.AddWithValue("@FirstName", firstName);
            command.Parameters.AddWithValue("@LastName", lastName);
            command.Parameters.AddWithValue("@Email", email);
            command.Parameters.AddWithValue("@PrimaryPhoneNumber", primaryPhone);
            command.Parameters.AddWithValue("@CreatedBy", createdBy);
            command.Parameters.AddWithValue("@CreatedOn", createdOn);
            command.ExecuteNonQuery();
            conn.Close();

        }

        public void DeleteEmployee2(long employeeId)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            string query = "DELETE FROM Employees WHERE ID = @EmployeeId";


            SqlCommand command = new SqlCommand(query, conn);
           
            command.Parameters.AddWithValue("@EmployeeId", employeeId);
            command.ExecuteNonQuery();
            conn.Close();


        }

        public DataTable GetEmployeeById2(long employeeId)
        {
            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();
            string query = "SELECT * FROM Employees WHERE ID = @EmployeeId";
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                
            adapter.SelectCommand.Parameters.AddWithValue("@EmployeeId", employeeId);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            conn.Close();
            return dataTable;


        }

        public void UpdateEmployee2(long employeeId, string firstName, string lastName, string email, string primaryPhone, string modifiedBy, DateTime? modifiedOn)
        {
            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();
            string query = "UPDATE Employees " +
                           "SET FirstName = @FirstName, LastName = @LastName, Email = @Email, " +
                           "PrimaryPhoneNumber = @PrimaryPhoneNumber, ModifiedBy = @ModifiedBy, " +
                           "ModifiedOn = @ModifiedOn " +
                           "WHERE ID = @EmployeeId";

            SqlCommand command = new SqlCommand(query, conn);

            command.Parameters.AddWithValue("@EmployeeId", employeeId);
            command.Parameters.AddWithValue("@FirstName", firstName);
            command.Parameters.AddWithValue("@LastName", lastName);
            command.Parameters.AddWithValue("@Email", email);
            command.Parameters.AddWithValue("@PrimaryPhoneNumber", primaryPhone);
            command.Parameters.AddWithValue("@ModifiedBy", modifiedBy);
            command.Parameters.AddWithValue("@ModifiedOn", modifiedOn ?? (object)DBNull.Value);
            command.ExecuteNonQuery();
            conn.Close();



        }
    }
}
