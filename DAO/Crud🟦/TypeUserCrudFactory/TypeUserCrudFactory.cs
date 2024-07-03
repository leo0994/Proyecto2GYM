using DAO.Crud;
using DAO.Mapper;
using DTOs;
using System.Collections.Generic;

namespace DAO.Crud
{
    public class TypeUserCrudFactory
    {
        private readonly SqlDAO _dao;
        private readonly TypeUserMapper _mapper;

        public TypeUserCrudFactory()
        {
            _dao = SqlDAO.GetInstance();
            _mapper = new TypeUserMapper();
        }

        public void Create(TypeUserDTO typeUser)
        {
            var sqlOperation = _mapper.GetCreateStatement(typeUser);
            _dao.ExecuteProcedure(sqlOperation);
        }

        public TypeUserDTO RetrieveById(int id)
        {
            var sqlOperation = _mapper.GetRetrieveByIdStatement(id);
            var result = _dao.ExecuteQueryProcedure(sqlOperation);

            if (result.Count > 0)
            {
                return _mapper.BuildObject(result[0]);
            }

            return null;
        }

        public List<TypeUserDTO> RetrieveAll()
        {
            var sqlOperation = _mapper.GetRetrieveAllStatement();
            var result = _dao.ExecuteQueryProcedure(sqlOperation);

            if (result.Count > 0)
            {
                return _mapper.BuildObjects(result);
            }

            return new List<TypeUserDTO>();
        }

        public void Update(TypeUserDTO typeUser)
        {
            var sqlOperation = _mapper.GetUpdateStatement(typeUser);
            _dao.ExecuteProcedure(sqlOperation);
        }

        public void Delete(int id)
        {
            var sqlOperation = _mapper.GetDeleteStatement(id);
            _dao.ExecuteProcedure(sqlOperation);
        }
    }
}
