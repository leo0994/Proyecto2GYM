using DTOs;
using DAO;

namespace BL.User
{
     public class UserManager
    {
        private readonly UserCrudFactory _userCrudFactory;

        public UserManager()
        {
            _userCrudFactory = new UserCrudFactory();
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

        public void UpdatePassword(UserDTO user)
        {
            _userCrudFactory.UpdatePassword(user);
        }
        public int VerifyUserPassword(UserDTO user)
        {
            return _userCrudFactory.VerifyUserPassword(user);
        }
    }
}
