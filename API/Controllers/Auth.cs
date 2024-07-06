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
                var dataByCredentials = _userManager.RetrieveByCredentials(user);
                if (dataByCredentials != null)
                {
                    return Ok(ResponseHelper.Success<UserDTO>(dataByCredentials, "got user"));
                }
                return BadRequest(ResponseHelper.Error<UserDTO>("User incorrect blah blah blah", dataByCredentials));
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
                var dataByEmail = _userManager.RetrieveByEmail(user);
                if (dataByEmail != null)
                {
                    return BadRequest(ResponseHelper.Error<string>("Email already exist"));
                }
                // Sending CodeUser
                var authSendCodeUser = await AuthSendCodeUser.send(user);
                var response = new Dictionary<string, dynamic>();
                response["user"] = user;
                response["verificationResource"] = authSendCodeUser;
                return Ok(ResponseHelper.Success(response, "Validating phone and credentials"));
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
                    // This should just be an endpoint to register client users
                    // that's why we are setting the typeUserId
                    user.TypeUserId = 2;
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

        [HttpPost]
        [Route("recovery-password")]
        public async Task<IActionResult> recoveryPassword(UserDTO user)
        {
            // Validation Email exist
            var dataByEmail = _userManager.RetrieveByEmail(user);
            if (dataByEmail == null)
            {
                return BadRequest(ResponseHelper.Error<string>("email and user incorrect"));
            }
            // Validate new password rules from <UserDTO user>
            ValidationResult validationResult = _validatorManager.ValidatePassword(user.Password);
            if (!validationResult.IsValid)
            {
                return BadRequest(ResponseHelper.Error<Dictionary<string, string>>("Error credentials rules", validationResult.Errors));
            }
            // Validate history password from <UserDTO dataByEmail>
            // Then we should assing the new password from <UserDTO user> to <UserDTO dataByEmail>
            dataByEmail.Password = user.Password;
            var IsPasswordValid = (int) _userManager.VerifyUserPassword(dataByEmail);
            if(IsPasswordValid == 0){
                return BadRequest(ResponseHelper.Error<Dictionary<string, string>>("Password should be different from the last 5 passwords used."));
            }
            // Sending code to the user
            var authSendCodeUser = await AuthSendCodeUser.send(dataByEmail);
            // Componsing Response 
            var response = new Dictionary<string, dynamic>();
            response["user"] = dataByEmail;
            response["verificationResource"] = authSendCodeUser;

            return Ok(ResponseHelper.Success(response, "Validating code"));
        }

        [HttpPost]
        [Route("recovery-password-verification")]
        public async Task<IActionResult> recoveryPasswordVerificaton(UserDTO user, string code)
        {
            var authSendCodeUser = await AuthSendCodeUser.verify(user, code);
            if (authSendCodeUser.Status == "approved")
            {
                _userManager.UpdatePassword(user);
                return Ok(ResponseHelper.Success(authSendCodeUser, "Password updated"));
            }
            return BadRequest(ResponseHelper.Error("Incorrect code", authSendCodeUser));
        }
    }
}