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
        public async Task<ActionResult> SignUpAsync(SignUpRequestDTO signUpRequest)
        { 
            try
            {
                await _userService.SignUpAsync(signUpRequest.Name, signUpRequest.Email, signUpRequest.Password);

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
        public async Task<ActionResult> SignInAsync(SignInRequestDTO signInRequest)
        {
            try
            {
                var result = await _userService.SignInAsync(signInRequest.Email, signInRequest.Password);

                return Ok(
                    new{
                        Status = true,
                        Message = "Sign up successful",
                        Token = result.Token,
                        UserId = result.UserId
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
    }
}
