using DTOs;
using DAO.Mapper;
using System;
using System.Collections.Generic;

namespace DAO.Crud
{
    public class HistoryEnrollmentCrudFactory : CrudFactory
    {
        private readonly HistoryEnrollmentMapper _mapper;

        public HistoryEnrollmentCrudFactory()
        {
            _mapper = new HistoryEnrollmentMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var historyEnrollment = (HistoryEnrollmentDTO)entity;
            var sqlOperation = _mapper.GetCreateStatement(historyEnrollment);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override void Update(BaseEntity entity)
        {
            var historyEnrollment = (HistoryEnrollmentDTO)entity;
            var sqlOperation = _mapper.GetUpdateStatement(historyEnrollment);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override void Delete(BaseEntity entity)
        {
            var historyEnrollment = (HistoryEnrollmentDTO)entity;
            var sqlOperation = _mapper.GetDeleteStatement(historyEnrollment.Id);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override T Retrieve<T>(int id)
        {
            var sqlOperation = _mapper.GetRetrieveByIdStatement(id);
            var lstResult = dao.ExecuteQueryProcedure(sqlOperation);
            var dic = new Dictionary<string, object>();

            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
            }

            var historyEnrollment = _mapper.BuildObject(dic);
            return (T)Convert.ChangeType(historyEnrollment, typeof(T));
        }

        public override List<T> RetrieveAll<T>()
        {
            var sqlOperation = _mapper.GetRetrieveAllStatement();
            var lstResult = dao.ExecuteQueryProcedure(sqlOperation);

            var historyEnrollments = _mapper.BuildObjects(lstResult);
            var list = new List<T>();

            foreach (var historyEnrollment in historyEnrollments)
            {
                list.Add((T)Convert.ChangeType(historyEnrollment, typeof(T)));
            }

            return list;
        }
    }
}
