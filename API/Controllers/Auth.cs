using Microsoft.AspNetCore.Mvc;
using DTOs;
using System;
using System.Threading.Tasks;
using BL.Managers;
using Twilio.Rest.Verify.V2.Service;

namespace API.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class Auth : ControllerBase
    {
        private readonly UserManager _userManager;
        private readonly Validator _validatorManager;

        public Auth()
        {
            _userManager = new UserManager();
            _validatorManager = new Validator();
        }

        [HttpPost]
        [Route("signin")]
        public async Task<IActionResult> signin(UserDTO user)
        {
            try
            {
                var response =  _userManager.LoginUserHandler(user);
                // Setting cookie user id to the client
                HttpContext.Response.Cookies.Append("user", response.Id + "");
                Console.WriteLine(response.Id);
                return Ok(ResponseHelper.Success<UserDTO>(response, "got user"));
            }
            catch (ManagerException<ApiResponse<UserDTO>> ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Data);
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
                var response = await _userManager.SignUpUserHandler(user);
                return Ok(ResponseHelper.Success<Dictionary<string, dynamic>>(response, "Validating phone and credentials"));
            }
            catch (ManagerException<ApiResponse<string>> ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Data);
            }
            catch (ManagerException<ApiResponse<Dictionary<string, string>>> ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Data);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("sign-up-verification")]
        public async Task<IActionResult> signUpVerificaton(UserDTO user, string code)
        {
            try
            {
                var response = await _userManager.SignUpValidationUserHandler(user, code);
                return Ok(ResponseHelper.Success(response, "User created"));
            }
            catch (ManagerException<ApiResponse<VerificationCheckResource>> ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Data);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("recovery-password")]
        public async Task<IActionResult> recoveryPassword(UserDTO user)
        {
            try
            {
                var response = await _userManager.RecoveryPasswordHandler(user);
                return Ok(ResponseHelper.Success(response, "Validating code"));
            }
            catch (ManagerException<ApiResponse<string>> ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Data);
            }
            catch (ManagerException<ApiResponse<Dictionary<string, string>>> ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Data);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("recovery-password-verification")]
        public async Task<IActionResult> recoveryPasswordVerificaton(UserDTO user, string code)
        {
            try
            {
                var response = await _userManager.RecoveryPasswordVerificatonHandler(user, code);
                return Ok(ResponseHelper.Success(response, "Password updated"));
            }
            catch (ManagerException<ApiResponse<VerificationCheckResource>> ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Data);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}