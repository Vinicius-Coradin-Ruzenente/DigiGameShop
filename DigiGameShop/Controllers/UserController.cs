using DigiGameShop.Models;
using DigiGameShop.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DigiGameShop.Controllers
{
    [Route("api/v1/[controller]")]
    public class UserController(IUserServices userServices) : ControllerBase
    {
        private readonly IUserServices _userServices = userServices;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _userServices.GetUsersAsync());
        }

        [HttpGet("byId")]
        public async Task<IActionResult> Get([FromQuery] int id)
        {
            var user = await _userServices.GetUserByIdAsync(id);
            if (user == null) {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost()]
        public async Task<IActionResult> Post([FromBody] AddUpdateUser newUserObj)
        {
            var user = await _userServices.AddUserAsync(newUserObj);
            if (user == null)
            {
                return BadRequest();
            }
            return Ok(new
            {
                message = "New User created succesfully",
                id = user!.Id
            });
        }

        [HttpPut()]
        public async Task<IActionResult> Put([FromQuery] int id, [FromBody] AddUpdateUser updatedUserObj)
        {
            var user = await _userServices.UpdateUserAsync(id, updatedUserObj);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(new
            {
                message = "User updated succesfully",                
            });
        }

        [HttpDelete()]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            var user = await _userServices.DeleteUserAsync(id);
            if (!user)
            {
                return NotFound();
            }
            return Ok(new
            {
                message = "User deleted succesfully"
            });
        }
    }
}
