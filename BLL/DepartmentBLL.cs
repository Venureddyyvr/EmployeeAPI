using EmployeeAPI.DAL;
using EmployeeAPI.Models; 

namespace EmployeeAPI.BLL
{
    public class DepartmentBLL
    {
        private readonly DepartmentDAL _departmentDAL;
        public DepartmentBLL(DepartmentDAL departmentDAL)
        {
            _departmentDAL = departmentDAL;
        }
        public void AddDepartment(Department department)
        {
            _departmentDAL.AddDepartment(department);
        }
        public void DeleteDepartment(int id)
        {
            _departmentDAL.DeleteDepartment(id);
        }
        public IEnumerable<Department> GetAllDepartments()
        {
            return _departmentDAL.GetAllDepartments();
        }
        public Department GetDepartment(int id)
        {
            return _departmentDAL.GetDepartment(id);
        }
        public void UpdateDepartment(Department department, int id)
        {
            _departmentDAL.UpdateDepartment(department, id);
        }
    }
}


