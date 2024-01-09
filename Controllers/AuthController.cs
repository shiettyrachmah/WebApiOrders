using Microsoft.AspNetCore.Mvc;
using WebApiOrder.Models;
using WebApiOrder.IServices;
using WebApiOrder.helpers;
using Microsoft.AspNetCore.Authorization;

namespace WebApiOrder.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;

        private readonly IAuthServices _services;
        private readonly IJwtServices _jwtServices;

        public AuthController(ILogger<AuthController> logger, IAuthServices services, IJwtServices jwtServices)
        {
            _logger = logger;
            _services = services;
            _jwtServices = jwtServices;
        }

        [HttpGet("/GetAllDataUser")]
        public async Task<ActionResult<List<User>>> GetAllDataUser()
        {
            try
            {
                var resultData = await _services.GetAllDataUser();

                if (resultData.Count == 0)
                {
                    return NotFound(new { message = "Data Empty" });
                }

                return Ok(resultData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("/register")]
        public async Task<ActionResult<User>> Register(User users)
        {
            try
            {
                var user = new User
                {
                    UserName = users.UserName,
                    Password = BCrypt.Net.BCrypt.HashPassword(users.Password),
                    IsAdmin = users.IsAdmin
                };

                var result = await _services.AddUser(user);

                if (result == null)
                {
                    return NotFound(new { message = "Add Unsuccessful" });
                }

                return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [AllowAnonymous]
        [HttpPost("/login")]

        public async Task<ActionResult<User>> Login(User user)
        {

            var getExistingUser = await _services.GetByUsername(user.UserName);

            if (getExistingUser == null)
            {
                return NotFound(new { message = "Username not found" });
            }

            if (!BCrypt.Net.BCrypt.Verify(text: user.Password, hash: getExistingUser.Password))
            {
                return BadRequest(new { message = "Password was wrong" });
            }

            var cookie = _jwtServices.Generate(getExistingUser.UserID);

            if(cookie == null)
            {
                return Unauthorized();
            }

            Response.Cookies.Append(key: "cookie", value: cookie, new CookieOptions
            {
                HttpOnly = true
            });

            return Ok(getExistingUser);
        }

        [HttpGet("/GetAuthUser")]
        public async Task<ActionResult<User>> GetAuthUser()
        {
            try
            {
                var jwt = Request.Cookies["cookie"];
                var token = _jwtServices.Verify(jwt);
                string ids = token.Issuer;
                var user = await _services.GetByUserId(ids);

                return Ok(user);
            }
            catch (Exception _)
            {
                return Unauthorized();
            }
        }

        [HttpPost("/logout")]
        public async Task<IActionResult> Logout()
        {
            try
            {
                Response.Cookies.Delete(key: "cookie");

                return Ok(new { message = "success logout" });

            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Destroy cookie failed" });
            }
        }
    }
}
