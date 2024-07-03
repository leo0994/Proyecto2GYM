using DAO.Crud;
using DTOs;
using System.Collections.Generic;

namespace Mana_gers.TypeUserManager
{
    public class TypeUserManager
    {
        private readonly TypeUserCrudFactory _crudFactory;

        public TypeUserManager()
        {
            _crudFactory = new TypeUserCrudFactory();
        }

        public void Create(TypeUserDTO typeUser)
        {
            _crudFactory.Create(typeUser);
        }

        public TypeUserDTO RetrieveById(int id)
        {
            return _crudFactory.RetrieveById(id);
        }

        public List<TypeUserDTO> RetrieveAll()
        {
            return _crudFactory.RetrieveAll();
        }

        public void Update(TypeUserDTO typeUser)
        {
            _crudFactory.Update(typeUser);
        }

        public void Delete(int id)
        {
            _crudFactory.Delete(id);
        }
    }
}
