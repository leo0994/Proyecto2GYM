using DTOs;
using DAO.Mapper;
using System.Collections.Generic;

namespace DAO.Crud
{
    public class ClassActivityCrudFactory
    {
        private readonly SqlDAO _dao;
        private readonly ClassActivityMapper _mapper;

        public ClassActivityCrudFactory()
        {
            _dao = SqlDAO.GetInstance();
            _mapper = new ClassActivityMapper();
        }

        public void Create(ClassActivityDTO classActivity)
        {
            var sqlOperation = _mapper.GetCreateStatement(classActivity);
            _dao.ExecuteProcedure(sqlOperation);
        }

        public ClassActivityDTO RetrieveById(int id)
        {
            var sqlOperation = _mapper.GetRetrieveByIdStatement(id);
            var result = _dao.ExecuteQueryProcedure(sqlOperation);

            if (result.Count > 0)
            {
                return _mapper.BuildObject(result[0]);
            }

            return null;
        }

        public List<ClassActivityDTO> RetrieveAll()
        {
            var sqlOperation = _mapper.GetRetrieveAllStatement();
            var result = _dao.ExecuteQueryProcedure(sqlOperation);

            if (result.Count > 0)
            {
                return _mapper.BuildObjects(result);
            }

            return new List<ClassActivityDTO>();
        }

        public void Update(ClassActivityDTO classActivity)
        {
            var sqlOperation = _mapper.GetUpdateStatement(classActivity);
            _dao.ExecuteProcedure(sqlOperation);
        }

        public void Delete(int id)
        {
            var sqlOperation = _mapper.GetDeleteStatement(id);
            _dao.ExecuteProcedure(sqlOperation);
        }
    }
}
