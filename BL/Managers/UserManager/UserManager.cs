using DAO;
using DTOs;
using System;
using Twilio;
using BL.User;
using BL.ValidatorCredentialsManager;
using BL.TwilioManager;
using BL.PasswordManager;
using Twilio.Rest.Verify.V2.Service;
using System.Threading.Tasks;

namespace BL.User
{
     public class UserManager
    {
        private readonly UserCrudFactory _userCrudFactory;
        private readonly Validator _validatorManager;

        public UserManager()
        {
            _userCrudFactory = new UserCrudFactory();
            _validatorManager = new Validator();
        }

        public UserDTO LoginUserHandler(UserDTO user)
        {
            string hashedPassword = PasswordService.HashPassword(user.Password);
            user.Password = hashedPassword;
            
            var dataByCredentials = _userCrudFactory.RetrieveByCredentials(user);
            if (dataByCredentials == null)
            {
                var error = ResponseHelper.Error<UserDTO>("User incorrect blah blah blah", user);
                throw new ManagerException<ApiResponse<UserDTO>>(error);
            }

            return dataByCredentials;
        }

        public async Task<Dictionary<string, dynamic>> SignUpUserHandler(UserDTO user)
        {
            // validate password - phone - email                 
            ValidationResult validationResult = _validatorManager.ValidateCred(user.Email, user.Number, user.Password);
            if (!validationResult.IsValid)
            {
                var error = ResponseHelper.Error<Dictionary<string, string>>("Error credentials rules", validationResult.Errors);
                throw new ManagerException<ApiResponse<Dictionary<string, string>>>(error);
            }

            // Validation Email exist
            var dataByEmail = _userCrudFactory.RetrieveByEmail(user);
            if (dataByEmail != null)
            {
                var error = ResponseHelper.Error<string>("Email already exist");
                throw new ManagerException<ApiResponse<string>>(error);
            }

            // Sending CodeUser
            var authSendCodeUser = await AuthSendCodeUser.send(user);

            var response = new Dictionary<string, dynamic>();
            response["user"] = user;
            response["verificationResource"] = authSendCodeUser;

            return response;
        }

        public async Task<VerificationCheckResource> SignUpValidationUserHandler(UserDTO user, string code) 
        {
            var authSendCodeUser = await AuthSendCodeUser.verify(user, code);
            if (authSendCodeUser.Status != "approved")
            {
                var error = ResponseHelper.Error("Incorrect code", authSendCodeUser);
                throw new ManagerException<ApiResponse<VerificationCheckResource>>(error);
            }

            // Hash the password from user input to save it in db hashed
            string hashedPassword = PasswordService.HashPassword(user.Password);
            Console.WriteLine("Hashed Password: " + hashedPassword);
            user.Password = hashedPassword;

            // This should just be an endpoint to register client users
            // that's why we are setting the typeUserId
            user.TypeUserId = 2;
            _userCrudFactory.Create(user);

            return authSendCodeUser;
        }

        public async Task<Dictionary<string, dynamic>> RecoveryPasswordHandler(UserDTO user) {
             // Validation Email exist
            var dataByEmail = _userCrudFactory.RetrieveByEmail(user);
            if (dataByEmail == null)
            {
                var error = ResponseHelper.Error<string>("email and user incorrect");
                throw new ManagerException<ApiResponse<string>>(error);
            }

            // Validate new password rules from <UserDTO user>
            ValidationResult validationResult = _validatorManager.ValidatePassword(user.Password);
            if (!validationResult.IsValid)
            {
                var error = ResponseHelper.Error<Dictionary<string, string>>("Error credentials rules", validationResult.Errors);
                throw new ManagerException<ApiResponse<Dictionary<string, string>>>(error);
            }

            // Validate history password from <UserDTO dataByEmail>
            // Then we should assing the new password from <UserDTO user> to <UserDTO dataByEmail>
            dataByEmail.Password = user.Password;
            var IsPasswordValid = (int) _userCrudFactory.VerifyUserPassword(dataByEmail);

            if(IsPasswordValid == 0){
                var error = ResponseHelper.Error<Dictionary<string, string>>("Password should be different from the last 5 passwords used.");
                throw new ManagerException<ApiResponse<Dictionary<string, string>>>(error);
            }

            // Sending code to the user
            var authSendCodeUser = await AuthSendCodeUser.send(dataByEmail);

            // Componsing Response 
            var response = new Dictionary<string, dynamic>();
            response["user"] = dataByEmail;
            response["verificationResource"] = authSendCodeUser;

            return response;
        }

         public async Task<VerificationCheckResource> RecoveryPasswordVerificatonHandler(UserDTO user, string code) 
        {
            var authSendCodeUser = await AuthSendCodeUser.verify(user, code);
            if (authSendCodeUser.Status != "approved")
            {
                var error = ResponseHelper.Error("Incorrect code", authSendCodeUser);
                throw new ManagerException<ApiResponse<VerificationCheckResource>>(error);
            }

            string hashedPassword = PasswordService.HashPassword(user.Password);
            user.Password = hashedPassword;
            
            _userCrudFactory.UpdatePassword(user);

            return authSendCodeUser;
        }
    

        public void Create(UserDTO user)
        {
            _userCrudFactory.Create(user);
        }

        public void CreateAdm(UserDTO user)
        {
            // Implementar lógica adicional para crear administradores si es necesario
            _userCrudFactory.Create(user);
        }

        public void Update(UserDTO user)
        {
            _userCrudFactory.Update(user);
        }

        public void Delete(int id)
        {
            _userCrudFactory.Delete(id);
        }

        public List<UserDTO> RetrieveAll()
        {
            return _userCrudFactory.RetrieveAll();
        }

        public UserDTO RetrieveById(int id)
        {
            return _userCrudFactory.RetrieveById(id);
        }

        public UserDTO RetrieveByCredentials(UserDTO user)
        {
          return _userCrudFactory.RetrieveByCredentials(user);
        }

        public UserDTO RetrieveByEmail(UserDTO user)
        {
            return _userCrudFactory.RetrieveByEmail(user);
        }
    }
}
