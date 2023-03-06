using EmployeeAPI.Models;
using System.Data.SqlClient;

namespace EmployeeAPI.DAL
{
    public class DepartmentDAL
    {
        private readonly string? _connectionString = Environment.GetEnvironmentVariable("EmployeeDBConnection", EnvironmentVariableTarget.Machine);
        public IEnumerable<Department> GetAllDepartments()
        {
            List<Department> departments = new();
            using (SqlConnection connection = new(_connectionString))
            {
                connection.Open();
                using SqlCommand command = new("select * from departments", connection);
                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    departments.Add(new Department
                    { 
                        DeptID = (int)reader["DeptID"],
                        DeptName = (string)reader["DeptName"]

                    });
                }

            }
            return departments;

        }
        public Department GetDepartment(int id)
        {
            Department? department = null;
            using SqlConnection connection = new(_connectionString);
            connection.Open();
            using (SqlCommand command = new("select * from departments where DeptID = @DeptID", connection))
            {
                command.Parameters.AddWithValue("@DeptID", id);
                using SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    department = new Department
                    {
                        DeptID = (int)reader["DeptID"],
                        DeptName = (string)reader["DeptName"]
                    };
                }
            }

#pragma warning disable CS8603 // Possible null reference return.
            return department;
#pragma warning restore CS8603 // Possible null reference return.
        }
        public void AddDepartment(Department department)
        {
            using SqlConnection connection = new(_connectionString);
            connection.Open();
            using SqlCommand command = new("Insert into departments (DeptID, DeptName) values (@DeptID, @DeptName)", connection);
            command.Parameters.AddWithValue("@DeptID", department.DeptID);
            command.Parameters.AddWithValue("@DeptName", department.DeptName);
            command.ExecuteNonQuery();
        }

        public void UpdateDepartment(Department department, int id)
        {
            using SqlConnection connection = new(_connectionString);
            connection.Open();
            using SqlCommand command = new("Update departments set DeptName = @DeptName where DeptID = @DeptID", connection);
            command.Parameters.AddWithValue("@DeptID", id);
            command.Parameters.AddWithValue("@DeptName", department.DeptName);
            command.ExecuteNonQuery();
        }

        public void DeleteDepartment(int id)
        {
            using SqlConnection connection = new(_connectionString);
            connection.Open();
            using SqlCommand command = new("Delete from departments where DeptID = @DeptID", connection);
            command.Parameters.AddWithValue("@DeptID", id);
            command.ExecuteNonQuery();

        }

    }
}

