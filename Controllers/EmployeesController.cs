using CurdOperation.Data;
using CurdOperation.Model;
using CurdOperation.Model.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CurdOperation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {

        private readonly ApplicationDBContext dBContext;
        public EmployeesController(ApplicationDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var EmployeesList = dBContext.Employees.ToList();
            return Ok(EmployeesList);
        }

        [HttpPost]
        public IActionResult AddEmplooye(AddEmployeesDto addEmployeesDto)
        {

            var EmployeeEntity = new Employee
            {

                Email = addEmployeesDto.Email,
                Name = addEmployeesDto.Name,
                phone = addEmployeesDto.phone,
                salary = addEmployeesDto.salary,
            };
            dBContext.Employees.Add(EmployeeEntity);
            dBContext.SaveChanges();
            return Ok(EmployeeEntity);
        }


        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetEmployeeById(Guid id)

        {

            var emp = dBContext.Employees.Find(id);
            if (emp is null)
            {
                return NotFound("given Id is not exist in Database");
            }
            return Ok(emp);

        }
        [HttpDelete]
        [Route("{id:Guid}")]
        public IActionResult DeleteEmployeeData(Guid id)
        {
            var emp = dBContext.Employees.Find(id);
            if (emp is null)
            {
                return NotFound("user not found here please make sure user present in database");
            }
            dBContext.Remove(emp);
            dBContext.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateEmployeeData(Guid id, UpdateEmployeeDto updateEmployeeDto)
        {

            var emp = dBContext.Employees.Find(id);

            if (emp is null)
            {

                return NotFound("user not found here please make sure user present in database");
            }
            emp.Name = updateEmployeeDto.Name;
            emp.phone= updateEmployeeDto.phone;
            emp.salary = updateEmployeeDto.salary;  
            emp.Email = updateEmployeeDto.Email;

            dBContext.SaveChanges();
            return Ok(updateEmployeeDto);
        }
    }
}