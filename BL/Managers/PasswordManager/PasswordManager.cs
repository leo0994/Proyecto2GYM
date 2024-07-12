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

        public PasswordDTO Create(PasswordDTO password)
        {
            return _crudFactory.Create(password);
        }

        public PasswordDTO Update(PasswordDTO password)
        {
            return _crudFactory.Update(password);
        }

        public PasswordDTO Delete(PasswordDTO password)
        {
            return _crudFactory.Delete(password);
        }

        public List<PasswordDTO> RetrieveAll()
        {
            return _crudFactory.RetrieveAll();
        }

        public PasswordDTO RetrieveById(int id)
        {
            return _crudFactory.RetrieveById(id);
        }
    }
}
