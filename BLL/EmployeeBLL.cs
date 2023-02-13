using EmployeeAPI.DAL;
using EmployeeAPI.Models;

namespace EmployeeAPI.BLL
{
    public class EmployeeBLL
    {
        private readonly EmployeeDAL _employeeDAL;
        public EmployeeBLL(EmployeeDAL employeeDAL)
        {
            _employeeDAL = employeeDAL;
        }
        public void AddEmployee(Employee employee)
        {
            _employeeDAL.AddEmployee(employee);
        }
        public void DeleteEmployee(int id)
        {
            _employeeDAL.DeleteEmployee(id);
        }
        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeDAL.GetAllEmployees();
        }
        public Employee GetEmployee(int id)
        {
            return _employeeDAL.GetEmployee(id);
        }
        public void UpdateEmployee(Employee employee, int id)
        {
            _employeeDAL.UpdateEmployee(employee, id);
        }
    }


}
