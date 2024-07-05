using Microsoft.AspNetCore.Mvc;
using DTOs;
using System;
using System.Threading.Tasks;
using BL.User;
using BL.ValidatorCredentialsManager;
using BL.TwilioManager;

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
        [Route("login")]
        public async Task<IActionResult> login(UserDTO user)
        {
            try
            {
                var response = _userManager.RetrieveByCredentials(user);
                if (response != null)
                {
                    return Ok(ResponseHelper.Success<UserDTO>(response, "got user"));
                }
                return BadRequest(ResponseHelper.Error<UserDTO>("User incorrect blah blah blah", response));
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
                // validate password - phone - email                 
                ValidationResult validationResult = _validatorManager.Validate(user.Email, user.Number, user.Password);

                if (!validationResult.IsValid)
                {
                    return BadRequest(ResponseHelper.Error<Dictionary<string, string>>("Error credentials rules", validationResult.Errors));
                }
                // Validation Email exist
                var response = _userManager.ValidateEmailExist(user);
                if (response == 1)
                {
                    return BadRequest(ResponseHelper.Error<string>("Email already exist"));
                }
                // Sending CodeUser
                var authSendCodeUser = await AuthSendCodeUser.send(user);
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
                if (authSendCodeUser.Status == "approved")
                {
                    _userManager.Create(user);
                    return Ok(ResponseHelper.Success(authSendCodeUser));
                }
                return BadRequest(ResponseHelper.Error("Incorrect code", authSendCodeUser));
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}