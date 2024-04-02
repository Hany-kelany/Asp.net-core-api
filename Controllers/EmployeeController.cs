using Api.Data;
using Api.DTO;
using Api.Models;
using Api.Models.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IbaseRepository<Employee , EmployeeModel> repo1;

        public EmployeeController(IbaseRepository<Employee, EmployeeModel> repo)
        {
            repo1 = repo;
        }

        [HttpGet]
        public IActionResult GetEmployees() 
        {
            var employees = repo1.GetAll();
            return Ok(employees);   
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployeebyiD(int id)
        { 
            var Emp = repo1.GetById(id);
            return Ok(Emp);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteEmp(int id)
        {
            repo1.DeleteById(id);

            return StatusCode(StatusCodes.Status204NoContent);
        }

        [HttpPost]
        public IActionResult AddEmployee([FromBody] EmployeeModel emp)
        {
           
            repo1.Add(emp);
            return Ok("Added...");    
        }

        [HttpPut]
        public IActionResult EditEployee(int id , EmployeeModel emp)
        {
           var Newemp = repo1.Update(id, emp);
           return Ok(Newemp);
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateWithPatch([FromBody] JsonPatchDocument<Employee> employee , int id )
        {
         var emp = repo1.UpdateWithPatch(employee , id);
            if(emp is null)
            {
                return NotFound($"Not found from controller");
            }
            return Ok(emp);
        }
        



    }
}
