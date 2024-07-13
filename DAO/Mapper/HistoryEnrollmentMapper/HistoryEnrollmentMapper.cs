using DTOs;
using System.Collections.Generic;

namespace DAO.Mapper
{
    public class HistoryEnrollmentMapper : ICrudStatements<HistoryEnrollmentDTO>, IObjectMapper<HistoryEnrollmentDTO>
    {
        public HistoryEnrollmentDTO BuildObject(Dictionary<string, object> row)
        {
            var historyEnrollment = new HistoryEnrollmentDTO
            {
                Id = (int)row["id"],
                Date = (DateTime)row["date"],
                UserId = (int)row["user_id"],
                EnrollmentId = (int)row["enrollment_id"]
            };

            return historyEnrollment;
        }

        public List<HistoryEnrollmentDTO> BuildObjects(List<Dictionary<string, object>> rowsList)
        {
            var resultsList = new List<HistoryEnrollmentDTO>();
            foreach (var row in rowsList)
            {
                var historyEnrollment = BuildObject(row);
                resultsList.Add(historyEnrollment);
            }
            return resultsList;
        }

        public SqlOperation GetCreateStatement(HistoryEnrollmentDTO historyEnrollment)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "LogEnrollment" };

            sqlOperation.AddDateTimeParam("@p_date", historyEnrollment.Date);
            sqlOperation.AddIntParam("@p_user_id", historyEnrollment.UserId);
            sqlOperation.AddIntParam("@p_enrollment_id", historyEnrollment.EnrollmentId);

            return sqlOperation;
        }

        public SqlOperation GetDeleteStatement(int id)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "DeleteHistoryEnrollment" }; // Assuming the existence of this stored procedure
            sqlOperation.AddIntParam("@p_id", id);
            return sqlOperation;
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            return new SqlOperation { ProcedureName = "GetAllHistoryEnrollments" }; // Assuming the existence of this stored procedure
        }

        public SqlOperation GetRetrieveByIdStatement(int id)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "GetHistoryEnrollmentById" }; // Assuming the existence of this stored procedure
            sqlOperation.AddIntParam("@p_id", id);
            return sqlOperation;
        }

        public SqlOperation GetUpdateStatement(HistoryEnrollmentDTO historyEnrollment)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "UpdateHistoryEnrollment" }; // Assuming the existence of this stored procedure

            sqlOperation.AddIntParam("@p_id", historyEnrollment.Id);
            sqlOperation.AddDateTimeParam("@p_date", historyEnrollment.Date);
            sqlOperation.AddIntParam("@p_user_id", historyEnrollment.UserId);
            sqlOperation.AddIntParam("@p_enrollment_id", historyEnrollment.EnrollmentId);

            return sqlOperation;
        }
    }
}
