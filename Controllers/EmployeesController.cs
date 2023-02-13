using EmployeeAPI.BLL;
using EmployeeAPI.Models;
using Microsoft.AspNetCore.Mvc; 

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeBLL _employeeBLL;
        public EmployeesController(EmployeeBLL employeeBLL)
        {
            _employeeBLL = employeeBLL;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetAllEmployees()
        {
            return Ok(_employeeBLL.GetAllEmployees());
        }
        [HttpGet("{id}")]
        public ActionResult<Employee> GetEmployee(int id)
        {
            var employee = _employeeBLL.GetEmployee(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }
        [HttpPost]
        public ActionResult<Employee> AddEmployee(Employee employee)
        {
            _employeeBLL.AddEmployee(employee);
            return CreatedAtAction(nameof(GetEmployee), new { id = employee.ID }, employee);
        }
        [HttpPut("{id}")]
        public ActionResult<Employee> UpdateEmployee(int id, Employee employee)
        {
            if (id != employee.ID)
            {
                return BadRequest();
            }
            _employeeBLL.UpdateEmployee(employee, id);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult<Employee> DeleteEmployee(int id)
        {
            Employee employee = _employeeBLL.GetEmployee(id);
            if (id != employee.ID)
            {
                return BadRequest();
            }
            _employeeBLL.DeleteEmployee(id);
            return NoContent();
        }
    }
}


