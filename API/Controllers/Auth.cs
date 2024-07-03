using Microsoft.AspNetCore.Mvc;
using DTO;
using DTO.User;
using BL.User;

namespace API.Controllers
{

    [ApiController]
    [Route("api/auth")]
    public class Auth : ControllerBase
    {

        [HttpGet]
        [Route("login")]
        public IActionResult login()
        {
            Dictionary<string, string> map = new Dictionary<string, string>();
            map["name"] = "jimmy";
            map["email"] = "cuentageovacoc@gmail.com";
            var response = ResponseHelper.Error("An Erro has occured ", map);
            return Ok(response);
        }

        [HttpPost]
        [Route("signup")]
        public IActionResult signUp(UserEntity user)
        {
            try
            {
                var userManager = new UserManager();
                return Ok(userManager.create(user));
            }
            catch (System.Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}