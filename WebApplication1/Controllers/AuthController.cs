using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NajotTalim.HR.DataAcces.Entities;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
       private readonly UserManager<AppUser>_userManager;
       private readonly IConfiguration _configuration;

       public AuthController(UserManager<AppUser> userManager, IConfiguration configuration)
       {
            _userManager = userManager;
            _configuration = configuration;
       }
        [Route("register")]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel registerModel)
        {
            var foundUsr= await _userManager .FindByNameAsync(registerModel.Username);
            if (foundUsr != null) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel { Status = "Error", Message = "User already exists!" });       
            }
            var user = new AppUser
            {

                Email = registerModel.Email,
                UserName = registerModel.Username,
                SecurityStamp = Guid.NewGuid().ToString(),
            };

            var result=await _userManager.CreateAsync(user,registerModel.Password);
            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel { Status = "Error", Message = "User creation." });

            }
            return Ok(new ResponseModel { Status="Succes",Message = "User created successfully!"});
        }

       
    }
}
