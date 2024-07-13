using DAO.Mapper;
using DTOs;
using System.Collections.Generic;

namespace DAO.Crud
{
    public class EnrollmentCrudFactory : CrudFactory<EnrollmentDTO>
    {
        private readonly EnrollmentMapper _mapper;

        public EnrollmentCrudFactory()
        {
            dao = SqlDAO.GetInstance();
            _mapper = new EnrollmentMapper();
        }

        public override EnrollmentDTO Create(EnrollmentDTO entityDTO)
        {
            var sqlOperation = _mapper.GetCreateStatement(entityDTO);
            dao.ExecuteProcedure(sqlOperation);
            return entityDTO;
        }

        public override EnrollmentDTO Update(EnrollmentDTO entityDTO)
        {
            var sqlOperation = _mapper.GetUpdateStatement(entityDTO);
            dao.ExecuteProcedure(sqlOperation);
            return entityDTO;
        }

        public override EnrollmentDTO Delete(EnrollmentDTO entityDTO)
        {
            var sqlOperation = _mapper.GetDeleteStatement(entityDTO.Id);
            dao.ExecuteProcedure(sqlOperation);
            return entityDTO;
        }

        public override List<EnrollmentDTO> RetrieveAll()
        {
            var sqlOperation = _mapper.GetRetrieveAllStatement();
            var result = dao.ExecuteQueryProcedure(sqlOperation);
            if (result.Count > 0)
            {
                return _mapper.BuildObjects(result);
            }
            return new List<EnrollmentDTO>();
        }

        public override EnrollmentDTO RetrieveById(int id)
        {
            var sqlOperation = _mapper.GetRetrieveByIdStatement(id);
            var result = dao.ExecuteQueryProcedure(sqlOperation);
            if (result.Count > 0)
            {
                return _mapper.BuildObject(result[0]);
            }
            return null;
        }
    }
}
