using Microsoft.AspNetCore.Mvc;
using NajotTalim.HR.DataAcces;
using System;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
       public IGenericCRUDService<EmployeeModel> _employeeSvc;

        public EmployeeController(IGenericCRUDService<EmployeeModel> employeeSvc)
        {
            _employeeSvc = employeeSvc;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var employees = await _employeeSvc.GetAll();
            return Ok(employees);
        }
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            if (id == 0)
                return NotFound($"Employee with the give id:{id} is found");
            else if (id < 0)
                return BadRequest("Wrong data.");

            return Ok(await _employeeSvc.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EmployeeModel employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid employee data");
            }

            var createdEmployee = await _employeeSvc.Create(employee);
            var routeValues = new {id=createdEmployee.Id};
            return CreatedAtRoute(routeValues, createdEmployee);
        }

      

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] EmployeeModel employee)
        {
          
            var updatedEmployee = await _employeeSvc.Update(id, employee);
            return Ok(updatedEmployee);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool deleteResult=await _employeeSvc.Delete(id);
            if (deleteResult)
                return NoContent();
            else
                return NotFound();
        }
    }
}
