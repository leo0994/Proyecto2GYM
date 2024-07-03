using DTOs;
using DAO.Mapper;
using System.Collections.Generic;

namespace DAO.Crud
{
    public class EnrollmentCrudFactory
    {
        private readonly SqlDAO _dao;
        private readonly EnrollmentMapper _mapper;

        public EnrollmentCrudFactory()
        {
            _dao = SqlDAO.GetInstance();
            _mapper = new EnrollmentMapper();
        }

        public void Create(EnrollmentDTO enrollment)
        {
            var sqlOperation = _mapper.GetCreateStatement(enrollment);
            _dao.ExecuteProcedure(sqlOperation);
        }

        public EnrollmentDTO RetrieveById(int id)
        {
            var sqlOperation = _mapper.GetRetrieveByIdStatement(id);
            var result = _dao.ExecuteQueryProcedure(sqlOperation);

            if (result.Count > 0)
            {
                return _mapper.BuildObject(result[0]);
            }

            return null;
        }

        public List<EnrollmentDTO> RetrieveAll()
        {
            var sqlOperation = _mapper.GetRetrieveAllStatement();
            var result = _dao.ExecuteQueryProcedure(sqlOperation);

            if (result.Count > 0)
            {
                return _mapper.BuildObjects(result);
            }

            return new List<EnrollmentDTO>();
        }

        public void Delete(int id)
        {
            var sqlOperation = _mapper.GetDeleteStatement(id);
            _dao.ExecuteProcedure(sqlOperation);
        }
    }
}

