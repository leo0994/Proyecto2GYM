using DTOs;
using DAO.Mapper;
using System.Collections.Generic;

namespace DAO.Crud
{
    public class TypeUserCrudFactory : CrudFactory<TypeUserDTO>
    {
        private readonly SqlDAO _dao;
        private readonly TypeUserMapper _mapper;

        public TypeUserCrudFactory()
        {
            _dao = SqlDAO.GetInstance();
            _mapper = new TypeUserMapper();
        }

        public override TypeUserDTO Create(TypeUserDTO entityDTO)
        {
            var operation = _mapper.GetCreateStatement(entityDTO);
            _dao.ExecuteProcedure(operation);
            return entityDTO;
        }

        public override TypeUserDTO Update(TypeUserDTO entityDTO)
        {
            var operation = _mapper.GetUpdateStatement(entityDTO);
            _dao.ExecuteProcedure(operation);
            return entityDTO;
        }

        public override TypeUserDTO Delete(TypeUserDTO entityDTO)
        {
            var operation = _mapper.GetDeleteStatement(entityDTO.Id);
            _dao.ExecuteProcedure(operation);
            return entityDTO;
        }

        public override List<TypeUserDTO> RetrieveAll()
        {
            var operation = _mapper.GetRetrieveAllStatement();
            var results = _dao.ExecuteQueryProcedure(operation);
            return _mapper.BuildObjects(results);
        }

        public override TypeUserDTO RetrieveById(int id)
        {
            var operation = _mapper.GetRetrieveByIdStatement(id);
            var results = _dao.ExecuteQueryProcedure(operation);
            if (results.Count > 0)
            {
                return _mapper.BuildObject(results[0]);
            }
            return null;
        }
    }
}
