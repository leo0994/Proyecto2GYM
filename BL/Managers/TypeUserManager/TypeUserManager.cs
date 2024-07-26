using DTOs;
using DAO.Crud;
using System.Collections.Generic;

namespace Managers
{
    public class TypeUserManager : CrudFactory<TypeUserDTO>
    {
        private readonly TypeUserCrudFactory _typeUserCrudFactory;

        public TypeUserManager()
        {
            _typeUserCrudFactory = new TypeUserCrudFactory();
        }

        public override TypeUserDTO Create(TypeUserDTO entityDTO)
        {

            return _typeUserCrudFactory.Create(entityDTO);
        }

        public override TypeUserDTO Update(TypeUserDTO entityDTO)
        {
            return _typeUserCrudFactory.Update(entityDTO);
        }

        public override TypeUserDTO Delete(TypeUserDTO entityDTO)
        {
            return _typeUserCrudFactory.Delete(entityDTO);
        }

        public override List<TypeUserDTO> RetrieveAll()
        {
            return _typeUserCrudFactory.RetrieveAll();
        }

        public override TypeUserDTO RetrieveById(int id)
        {
            return _typeUserCrudFactory.RetrieveById(id);
        }
    }
}
