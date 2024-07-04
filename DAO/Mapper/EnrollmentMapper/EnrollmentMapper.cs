using DTOs;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace DAO.Mapper
{
    public class EnrollmentMapper : ISqlStatements, IObjectMapper
    {
        public EnrollmentDTO BuildObject(Dictionary<string, object> row)
        {
            var enrollmentDTO = new EnrollmentDTO
            {
                Id = (int)row["id"],
                Amount = (decimal)row["amount"]
            };

            return enrollmentDTO;
        }

        public List<EnrollmentDTO> BuildObjects(List<Dictionary<string, object>> rowsList)
        {
            var resultsList = new List<EnrollmentDTO>();
            foreach (var row in rowsList)
            {
                var enrollmentDTO = BuildObject(row);
                resultsList.Add(enrollmentDTO);
            }
            return resultsList;
        }

        public SqlOperation GetCreateStatement(EnrollmentDTO enrollment)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "CreateEnrollment" };

            sqlOperation.AddDecimalParam("@p_amount", enrollment.Amount);

            return sqlOperation;
        }

        public SqlOperation GetDeleteStatement(int id)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "DeleteEnrollment" };
            sqlOperation.AddIntParam("@p_id", id);
            return sqlOperation;
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            return new SqlOperation { ProcedureName = "GetAllEnrollments" };
        }

        public SqlOperation GetRetrieveByIdStatement(int id)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "GetEnrollmentById" };
            sqlOperation.AddIntParam("@p_enrollment_id", id);
            return sqlOperation;
        }

        public SqlOperation GetUpdateStatement(EnrollmentDTO enrollment)
        {
            // Assuming there's no update statement needed for enrollment in this context
            return null;
        }
    }
}
