using DTOs;
using System.Collections.Generic;

namespace DAO.Mapper
{
    public class EnrollmentMapper : ICrudStatements<EnrollmentDTO>, IObjectMapper<EnrollmentDTO>
    {
        public EnrollmentDTO BuildObject(Dictionary<string, object> row)
        {
            var enrollment = new EnrollmentDTO
            {
                Id = (int)row["id"],
                Amount = (decimal)row["amount"]
            };

            return enrollment;
        }

        public List<EnrollmentDTO> BuildObjects(List<Dictionary<string, object>> rowsList)
        {
            var resultsList = new List<EnrollmentDTO>();
            foreach (var row in rowsList)
            {
                var enrollment = BuildObject(row);
                resultsList.Add(enrollment);
            }
            return resultsList;
        }

        public SqlOperation GetCreateStatement(EnrollmentDTO enrollment)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "CreateEnrollment" };
            sqlOperation.AddDecimalParam("@amount",enrollment.Amount);
            return sqlOperation;
        }

        public SqlOperation GetDeleteStatement(int id)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "DeleteEnrollment" };
            sqlOperation.AddIntParam("@id", id);
            return sqlOperation;
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            return new SqlOperation { ProcedureName = "GetAllEnrollments" };
        }

        public SqlOperation GetRetrieveByIdStatement(int id)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "GetEnrollmentById" };
            sqlOperation.AddIntParam("@id", id);
            return sqlOperation;
        }

        public SqlOperation GetUpdateStatement(EnrollmentDTO enrollment)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "UpdateEnrollment" };

            sqlOperation.AddIntParam("@id", enrollment.Id);
            sqlOperation.AddDecimalParam("@amount", enrollment.Amount);

            return sqlOperation;
        }
    }
}
