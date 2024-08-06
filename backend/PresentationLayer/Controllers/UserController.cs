using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusinessLogicLayer.Interfaces;
using PresentationLayer.DTOs;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpPost("SignUp")]
        public async Task<ActionResult> SignUpAsync(string name, string email, string password)
        {
            try
            {
                await _userService.SignUpAsync(name, email, password);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("SignIn")]
        public async Task<ActionResult<string>> SignInAsync(string email, string password)
        {
            try
            {
                var token = await _userService.SignInAsync(email, password);

                return token;

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
