using Bootcamp4_AspMVC.Dtos;
using Bootcamp4_AspMVC.Interfaces.IServices;
using Bootcamp4_AspMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bootcamp4_Asp_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {



        private readonly IUserService _userService;
        public AuthController(IUserService userService)
        {
            _userService = userService;

        }



        [HttpGet("login")]
        public ActionResult<string> Login([FromQuery] LoginRequestDto loginRequest)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(loginRequest.Email) || string.IsNullOrWhiteSpace(loginRequest.Password))
                    return BadRequest("Username and password are required.");

                var token = _userService.GetByEmailAndpass(loginRequest);
                if (token == null)
                    return Unauthorized("اسم المستخدم او كلمه المرور غير صحيحه"); // 401
                  return Ok(token); // 200
               
            }
            catch (Exception ex)
            {
                var message = ex.Message.ToString();
                return BadRequest($"{message}حدث خطا غير متوقع");
            }

        }




        //[HttpGet("login")]
        //public ActionResult<LoginResponse> Login([FromQuery] LoginRequestDto loginRequest)
        //{

        //    // Dummy authentication logic
        //    if (loginRequest.Email == "user@gmail.com" && loginRequest.Password == "123456")
        //    {

        //        var response = new LoginResponse
        //        {
        //            IsSuccess = true,
        //            FirstName = "Mohamed Alswaify",
        //            Email = "user@gmail.com",

        //        };


        //        return Ok(response);
        //    }
        //    return Unauthorized();

        //}







        [HttpPost("register")]
        public ActionResult Register([FromBody] UserDto registerRequest)
        {
            try
            {
                var existingUser = _userService.IsEmailExist(registerRequest.Email);
                if (existingUser)
                {
                    return BadRequest("User already exists.");
                }

                var newUser = new User
                {
                    FirstName = registerRequest.FirstName,
                    LastName = registerRequest.LastName,
                    Email = registerRequest.Email,
                    Password = registerRequest.Password,
                    Country = registerRequest.Country,
                    Phone = registerRequest.Phone,
                    Gender = registerRequest.Gender,
                    BirthDate = registerRequest.BirthDate,
                };

                _userService.Create(newUser);

                var result = new registerDto
                {
                    firstName = newUser.FirstName,
                    lastName = newUser.LastName,
                };



                return Ok(result);
            }
            catch (Exception ex)
            {
                var message = ex.Message.ToString();
                return BadRequest($"{message}حدث خطا غير متوقع");
            }



        }

   
    }



    }
