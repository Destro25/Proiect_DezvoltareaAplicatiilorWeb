using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proiect_DezvoltareaAplicatiilorWeb.Helpers.Attributes;
using Proiect_DezvoltareaAplicatiilorWeb.Models.DTOs;
using Proiect_DezvoltareaAplicatiilorWeb.Models.Enums;
using Proiect_DezvoltareaAplicatiilorWeb.Services.UserService;

namespace Proiect_DezvoltareaAplicatiilorWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(UserDTO newUser)
        {
            await _userService.Create(newUser);
            return Ok();
        }

        [HttpPut("update-user")]
        //[Authorization(Role.Admin, Role.User)]
        public async Task<IActionResult> UpdateUser(UserDTO user, Guid userId)
        {
            var actlUser = await _userService.Update(userId, user);
            if (actlUser == null) { return NotFound(); }
            return Ok(actlUser);

        }

        [HttpGet("get-All-Users")]
        //[Authorization(Role.Admin, Role.User)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _userService.GetAll());
        }

        [HttpDelete("delete-user")]
        //[Authorization(Role.Admin)]
        public async Task<IActionResult> DeleteCustomer(Guid Id)
        {
            await _userService.Delete(Id);
            return Ok();
        }

        [HttpPost("create-user")]
        public async Task<IActionResult> CreateUser(UserRequestDTO user)
        {
            await _userService.CreateUser(user);
            return Ok();
        }

        [HttpPost("create-admin")]
        public async Task<IActionResult> CreateAdmin(UserRequestDTO admin)
        {
            await _userService.CreateAdmin(admin);
            return Ok();
        }

        [HttpPost("login-user")]
        public IActionResult Login(UserRequestDTO user)
        {
            var req = _userService.Authenticate(user);
            if (req == null) { return BadRequest("Authentication failed."); }
            return Ok(req);
        }
    }
}
