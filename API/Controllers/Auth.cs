using Microsoft.AspNetCore.Mvc;
using DTOs;
using System;
using System.Threading.Tasks;
using BL.Managers;

namespace API.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class Auth : ControllerBase
    {

        private readonly UserManager _userManager;

        public Auth()
        {
            _userManager = new UserManager();
        }

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
        public async Task<IActionResult> signUp(UserDTO user)
        {
            try
            {
                _userManager.Create(user);
                return Ok(user);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}