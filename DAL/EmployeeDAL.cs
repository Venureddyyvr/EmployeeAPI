using EmployeeAPI.Models;
using System.Data.SqlClient;

namespace EmployeeAPI.DAL
{
    public class EmployeeDAL
    {
        private readonly string? _connectionString = Environment.GetEnvironmentVariable("EmployeeDBConnection", EnvironmentVariableTarget.Machine);
        public IEnumerable<Employee> GetAllEmployees()
        {
            List<Employee> employees = new();
            using (SqlConnection connection = new(_connectionString))
            {
                connection.Open();
                using SqlCommand command = new("select * from employees", connection);
                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    employees.Add(new Employee
                    {
                        ID = (int)reader["ID"],
                        FirstName = (string)reader["FirstName"],
                        LastName = (string)reader["LastName"],
                        DeptID = (int)reader["DeptID"]

                    });
                }

            }
            return employees;

        }
        public Employee GetEmployee(int id)
        {
            Employee? employee = null;
            using SqlConnection connection = new(_connectionString);
            connection.Open();
            using (SqlCommand command = new("select * from employees where ID = @ID", connection))
            {
                command.Parameters.AddWithValue("@ID", id);
                using SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    employee = new Employee
                    {
                        ID = (int)reader["ID"],
                        FirstName = (string)reader["FirstName"],
                        LastName = (string)reader["LastName"],
                        DeptID = (int)reader["DeptID"]
                    };
                }
            }

#pragma warning disable CS8603 // Possible null reference return.
            return employee;
#pragma warning restore CS8603 // Possible null reference return.
        }
        public void AddEmployee(Employee employee)
        {
            using SqlConnection connection = new(_connectionString);
            connection.Open();
            using SqlCommand command = new("Insert into employees (ID, FirstName, LastName, DeptID) values (@ID, @FirstName, @LastName, @DeptID)", connection);
            command.Parameters.AddWithValue("@ID", employee.ID);
            command.Parameters.AddWithValue("@FirstName", employee.FirstName);
            command.Parameters.AddWithValue("@LastName", employee.LastName);
            command.Parameters.AddWithValue("@DeptID", employee.DeptID);
            command.ExecuteNonQuery();
        }

        public void UpdateEmployee(Employee employee, int id)
        {
            using SqlConnection connection = new(_connectionString);
            connection.Open();
            using SqlCommand command = new("Update employees set FirstName = @FirstName, LastName = @LastName,DeptID = @DeptID where ID = @ID", connection);
            command.Parameters.AddWithValue("@ID", id);
            command.Parameters.AddWithValue("@FirstName", employee.FirstName);
            command.Parameters.AddWithValue("@LastName", employee.LastName);
            command.Parameters.AddWithValue("@DeptID", employee.DeptID);
            command.ExecuteNonQuery();
        }

        public void DeleteEmployee(int id)
        {
            using SqlConnection connection = new(_connectionString);
            connection.Open();
            using SqlCommand command = new("Delete from employees where ID = @ID", connection);
            command.Parameters.AddWithValue("@ID", id);
            command.ExecuteNonQuery();

        }
        
    } 
}
