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

        public int ValidateEmailExist(UserDTO user)
        {
          return _userCrudFactory.ValidateEmailExist(user);
        }

        public UserDTO RetrieveByEmail(string email)
        {
            // Implementar lógica para recuperar usuario por email si es necesario
            // Este método debería estar en UserCrudFactory si usas consultas directas
            return null;
        }

        public void UpdatePassword(string email)
        {
            // Implementar lógica para actualizar la contraseña del usuario
        }
    }
}
