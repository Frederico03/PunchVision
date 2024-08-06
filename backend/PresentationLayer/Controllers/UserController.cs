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
        public async Task<ActionResult> SignUpAsync(SignUpRequestDTO signRequest)
        {
            try
            {
                await _userService.SignUpAsync(signRequest.Name, signRequest.Email, signRequest.Password);

                return Ok(
                    new{
                        Status = true,
                        Message = "Sign up successful"
                    }
                );
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Status = false,
                    Message = ex.Message
                });
            }
        }

        [HttpPost("SignIn")]
        public async Task<ActionResult> SignInAsync(UserDTO userRequest)
        {
            try
            {
                var token = await _userService.SignInAsync(userRequest.Email, userRequest.Password);

                return Ok(new
                {
                    Status = true,
                    Message = "Sign up successful",
                    Token = token
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Status = false,
                    Message = ex.Message
                });
            }
        }
    }
}
