
using Microsoft.AspNetCore.Mvc;
using NajotTalim.HR.DataAcces;
using NajotTalim.HR.DataAcces.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeController : ControllerBase
    {
        private readonly IGenericCRUDService<EmployeeModel> _employeeSvc;
        public EmployeController(IGenericCRUDService<EmployeeModel> employeeSvc)
        {
            _employeeSvc = employeeSvc;
        }

        // GET: api/<EmployeController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _employeeSvc.GetAll());
        }

        // GET api/<EmployeController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id == 0)
                return NotFound($"Employee with the given id {id} is mot found ...");

            else if (id <= 0)
                return BadRequest("Wrong data.");

            return Ok(await _employeeSvc.Get(id));
        }

        // POST api/<EmployeController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EmployeeModel employee)
        {
            var createdEmployee = await _employeeSvc.Create(employee);
            var rauteValues = new { id = createdEmployee.Id };
            return CreatedAtRoute(rauteValues, createdEmployee);
        }

        // PUT api/<EmployeController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] EmployeeModel employee)
        {
            var updatedEmployee = await _employeeSvc.Update(id, employee);
            return Ok(updatedEmployee);
        }

        // DELETE api/<EmployeController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool deleteResult = await _employeeSvc.Delete(id);
            if (deleteResult)
                return NoContent();
            else
                return NotFound();
        }
    }
}