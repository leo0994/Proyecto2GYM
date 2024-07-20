using DTOs;
using DAO.Mapper;
using System.Collections.Generic;

namespace DAO.Crud
{
    public class HistoryEnrollmentCrudFactory : CrudFactory<HistoryEnrollmentDTO>
    {
        private readonly HistoryEnrollmentMapper _mapper;

        public HistoryEnrollmentCrudFactory()
        {
            dao = SqlDAO.GetInstance();
            _mapper = new HistoryEnrollmentMapper();
        }

        public override HistoryEnrollmentDTO Create(HistoryEnrollmentDTO historyEnrollment)
        {
            var sqlOperation = _mapper.GetCreateStatement(historyEnrollment);
            dao.ExecuteProcedure(sqlOperation);
            return historyEnrollment;
        }

        public override HistoryEnrollmentDTO Delete(HistoryEnrollmentDTO historyEnrollment)
        {
            var sqlOperation = _mapper.GetDeleteStatement(historyEnrollment.Id);
            dao.ExecuteProcedure(sqlOperation);
            return historyEnrollment;
        }

        public override List<HistoryEnrollmentDTO> RetrieveAll()
        {
            var sqlOperation = _mapper.GetRetrieveAllStatement();
            var result = dao.ExecuteQueryProcedure(sqlOperation);
            return _mapper.BuildObjects(result);
        }

        public override HistoryEnrollmentDTO RetrieveById(int id)
        {
            var sqlOperation = _mapper.GetRetrieveByIdStatement(id);
            var result = dao.ExecuteQueryProcedure(sqlOperation);
            if (result.Count > 0)
            {
                return _mapper.BuildObject(result[0]);
            }
            return null;
        }

        public override HistoryEnrollmentDTO Update(HistoryEnrollmentDTO historyEnrollment)
        {
            var sqlOperation = _mapper.GetUpdateStatement(historyEnrollment);
            dao.ExecuteProcedure(sqlOperation);
            return historyEnrollment;
        }
    }
}
