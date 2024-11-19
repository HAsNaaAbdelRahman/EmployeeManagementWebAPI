using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationAPI.Models;

namespace WebApplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDbContext context ;
        public EmployeeController(ApplicationDbContext _context)
        {
            context = _context;
        }
        [HttpGet]
        public IActionResult GetEmployee()
        {
          List<Employee> emp =  context.Employees.ToList();

            return Ok(emp);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById([FromRoute]int id)
        {

            Employee emp = context.Employees.SingleOrDefault(x => x.Id == id);
            return Ok(emp);
        }
        [HttpPut("{id}")]

        public IActionResult PutEmployee([FromRoute]int id ,[FromBody] Employee NewEmp)
        {

            if (ModelState.IsValid)
            {
                Employee OldEmployees = context.Employees.FirstOrDefault(i => i.Id == id);

                if (OldEmployees == null)
                {
                    return NotFound($"Employee with ID {id} not found.");
                }

                OldEmployees.FirstName = NewEmp.FirstName;
                OldEmployees.LastName = NewEmp.LastName;
                OldEmployees.Address = NewEmp.Address;
                OldEmployees.Phone = NewEmp.Phone;
                OldEmployees.BirthDate = NewEmp.BirthDate;
                OldEmployees.Email = NewEmp.Email;
                OldEmployees.Salary = NewEmp.Salary;
                context.SaveChanges();
                return StatusCode(StatusCodes.Status204NoContent);

            }
            return BadRequest(ModelState);
        }

        [HttpDelete]
        public IActionResult DeleteEmployee( int id)
        {
            if(ModelState.IsValid)
            {
                Employee emp = context.Employees.FirstOrDefault(e => e.Id == id);
                context.Employees.Remove(emp);
                context.SaveChanges();
                return Ok(StatusCodes.Status204NoContent);
            }
            return BadRequest();
        }

        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            if (ModelState.IsValid)
            {
                context.Employees.Add(employee);
                context.SaveChanges();
                return Created("http://localhost:5096/api/employee" + employee.Id, employee);
            }
            return BadRequest(ModelState);
        }
    }
}
