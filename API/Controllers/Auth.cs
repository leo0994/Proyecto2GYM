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
        [Route("signin")]
        public async Task<IActionResult> signin(UserDTO user)
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
                ValidationResult validationResult = _validatorManager.ValidateCred(user.Email, user.Number, user.Password);

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
                return Ok(ResponseHelper.Success(authSendCodeUser, "Validating phone and credentials"));
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
                var authSendCodeUser = await AuthSendCodeUser.verify(user, code);
                if (authSendCodeUser.Status == "approved")
                {
                    _userManager.Create(user);
                    return Ok(ResponseHelper.Success(authSendCodeUser, "User created"));
                }
                return BadRequest(ResponseHelper.Error("Incorrect code", authSendCodeUser));
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        //  Call GetUserByEmail Crud and call it using GetUserByEmail storeProcedure then create the recoveryPassword-verification like above code 
        // public async Task<IActionResult> recoveryPassword(UserDTO user)
        // {
        //     // // Validation Email exist
        //     // var response = _userManager.ValidateEmailExist(user);
        //     // if (response == 1)
        //     // {
        //     //     return BadRequest(ResponseHelper.Error<string>("Email already exist"));
        //     // }
        // }
    }
}