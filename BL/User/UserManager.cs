using DTO;
using DTO.User;
using DAO.Crud.User;

namespace BL.User
{
    public class UserManager
    {
        public UserManager()
        {
        }

        public ApiResponse<UserEntity> create(UserEntity user)
        {
            var userEntity = new UserEntity();
            userEntity.Name = user.Name;
            userEntity.Email = user.Email;
            userEntity.Password = user.Password;
            userEntity.Born = user.Born;
            userEntity.Phone = user.Phone;
            userEntity.UserType = user.UserType;
            /**
                1. validate data here 
                2. validate 2MFA
            */
            var userCrudFactory = new UserCrudFactory();
            return ResponseHelper.Success(userCrudFactory.Create(userEntity));
        }

        public void update(UserEntity user)
        {
            // return null;
        }

        public void getUser(int id)
        {
            // return null;
        }

    }
}
