using Microsoft.AspNetCore.Mvc;
using DTOs;
using System;
using System.Threading.Tasks;
using BL.User;
using BL.TwilioManager;

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

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> login(UserDTO user)
        {
            try
            {   
                var response = _userManager.RetrieveByCredentials(user);
                if(response != null){
                    return Ok(ResponseHelper.Success<UserDTO>(response, "got user"));
                }                
                return Ok(ResponseHelper.Error<UserDTO>("User incorrect blah blah blah", response));
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("signup")]
        public async Task<IActionResult> signUp(UserDTO user)
        {
            try
            {   
                var authSendCodeUser  = await AuthSendCodeUser.send(user);
                return Ok(ResponseHelper.Success(authSendCodeUser));
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("verify-code")]
        public async Task<IActionResult> verifyCode(UserDTO user, string userCode)
        {
            try
            {   
                var authSendCodeUser = await AuthSendCodeUser.verify(user, userCode);
                if(authSendCodeUser.Status == "approved"){
                    _userManager.Create(user);
                    return Ok(ResponseHelper.Success(authSendCodeUser));
                }                
                return Ok(ResponseHelper.Error("Incorrect code", authSendCodeUser));
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}