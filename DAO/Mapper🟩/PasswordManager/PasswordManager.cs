using DTOs;
using DAO.Crud;
using System.Collections.Generic;

namespace BL.Managers
{
    public class PasswordManager
    {
        private readonly PasswordCrudFactory _crudFactory;

        public PasswordManager()
        {
            _crudFactory = new PasswordCrudFactory();
        }

        public void Create(PasswordDTO password)
        {
            _crudFactory.Create(password);
        }

        public void Update(PasswordDTO password)
        {
            _crudFactory.Update(password);
        }

        public void Delete(int id)
        {
            var password = new PasswordDTO { Id = id };
            _crudFactory.Delete(password);
        }

        public PasswordDTO RetrieveById(int id)
        {
            return _crudFactory.Retrieve<PasswordDTO>(id);
        }

        public List<PasswordDTO> RetrieveAll()
        {
            return _crudFactory.RetrieveAll<PasswordDTO>();
        }
    }
}
