using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NajotTalim.HR.DataAcces.Services;
using NajotTalim.HR.DataAcces;
using WebApplication1.Models;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IGenericCRUDService<AddressModel> _addressSvc;
        public AddressController(IGenericCRUDService<AddressModel> addressSvc)
        {
            _addressSvc = addressSvc;
        }

        // GET: api/<EmployeController>
        [HttpGet]
        
        public async Task<IActionResult> Get()
        {
            return Ok(await _addressSvc.GetAll());
        }

        // GET api/<EmployeController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id == 0)
                return NotFound($"Address with the given id {id} is mot found ...");

            else if (id <= 0)
                return BadRequest("Wrong data.");

            return Ok(await _addressSvc.Get(id));
        }

        // POST api/<EmployeController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddressModel address)
        {
            var createdEmployee = await _addressSvc.Create(address);
            var rauteValues = new { id = createdEmployee.Id };
            return CreatedAtRoute(rauteValues, createdEmployee);
        }

        // PUT api/<EmployeController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] AddressModel address)
        {
            var updatedEmployee = await _addressSvc.Update(id, address);
            return Ok(updatedEmployee);
        }

        // DELETE api/<EmployeController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool deleteResult = await _addressSvc.Delete(id);
            if (deleteResult)
                return NoContent();
            else
                return NotFound();
        }
    }
}
