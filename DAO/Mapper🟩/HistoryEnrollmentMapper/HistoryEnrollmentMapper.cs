using DTOs;
using System.Collections.Generic;

namespace DAO.Mapper
{
    public class HistoryEnrollmentMapper : ISqlStatements, IObjectMapper
    {
        public HistoryEnrollmentDTO BuildObject(Dictionary<string, object> row)
        {
            var historyEnrollmentDTO = new HistoryEnrollmentDTO
            {
                Id = (int)row["id"],
                Date = (DateTime)row["date"],
                UserId = (int)row["userId"],
                EnrollmentId = (int)row["enrollmentId"]
            };

            return historyEnrollmentDTO;
        }

        public List<HistoryEnrollmentDTO> BuildObjects(List<Dictionary<string, object>> rowsList)
        {
            var resultsList = new List<HistoryEnrollmentDTO>();
            foreach (var row in rowsList)
            {
                var historyEnrollmentDTO = BuildObject(row);
                resultsList.Add(historyEnrollmentDTO);
            }
            return resultsList;
        }

        public SqlOperation GetCreateStatement(HistoryEnrollmentDTO historyEnrollment)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "CreateHistoryEnrollment" };

            sqlOperation.AddDateTimeParam("@p_date", historyEnrollment.Date);
            sqlOperation.AddIntParam("@p_userId", historyEnrollment.UserId);
            sqlOperation.AddIntParam("@p_enrollmentId", historyEnrollment.EnrollmentId);

            return sqlOperation;
        }

        public SqlOperation GetDeleteStatement(int id)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "DeleteHistoryEnrollment" };
            sqlOperation.AddIntParam("@p_id", id);
            return sqlOperation;
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            return new SqlOperation { ProcedureName = "GetAllHistoryEnrollments" };
        }

        public SqlOperation GetRetrieveByIdStatement(int id)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "GetHistoryEnrollmentById" };
            sqlOperation.AddIntParam("@p_id", id);
            return sqlOperation;
        }

        public SqlOperation GetUpdateStatement(HistoryEnrollmentDTO historyEnrollment)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "UpdateHistoryEnrollment" };

            sqlOperation.AddIntParam("@p_id", historyEnrollment.Id);
            sqlOperation.AddDateTimeParam("@p_date", historyEnrollment.Date);
            sqlOperation.AddIntParam("@p_userId", historyEnrollment.UserId);
            sqlOperation.AddIntParam("@p_enrollmentId", historyEnrollment.EnrollmentId);

            return sqlOperation;
        }
    }
}
