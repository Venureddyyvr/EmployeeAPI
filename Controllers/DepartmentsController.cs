using EmployeeAPI.BLL;
using EmployeeAPI.Models;
using Microsoft.AspNetCore.Mvc; namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly DepartmentBLL _departmentBLL;
        public DepartmentsController(DepartmentBLL departmentBLL)
        {
            _departmentBLL = departmentBLL;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Department>> GetAllDepartments()
        {
            return Ok(_departmentBLL.GetAllDepartments());
        }
        [HttpGet("{id}")]
        public ActionResult<Department> GetDepartment(int id)
        {
            var department = _departmentBLL.GetDepartment(id);
            if (department == null)
            {
                return NotFound();
            }
            return Ok(department);
        }
        [HttpPost]
        public ActionResult<Department> AddDepartment(Department department)
        {
            _departmentBLL.AddDepartment(department);
            return CreatedAtAction(nameof(GetDepartment), new { id = department.DeptID }, department);
        }
        [HttpPut("{id}")]
        public ActionResult<Department> UpdateDepartment(int id, Department department)
        {
            if (id != department.DeptID)
            {
                return BadRequest();
            }
            _departmentBLL.UpdateDepartment(department, id);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult<Department> DeleteDepartment(int id)
        {
            Department department = _departmentBLL.GetDepartment(id);
            if (id != department.DeptID)
            {
                return BadRequest();
            }
            _departmentBLL.DeleteDepartment(id);
            return NoContent();
        }
    }
}

