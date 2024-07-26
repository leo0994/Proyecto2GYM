using DTOs;
using System.Collections.Generic;

namespace DAO.Mapper
{
    public class PasswordMapper : ICrudStatements<PasswordDTO>, IObjectMapper<PasswordDTO>
    {
        public PasswordDTO BuildObject(Dictionary<string, object> row)
        {
            var passwordDTO = new PasswordDTO
            {
                Id = (int)row["id"],
                Password = (string)row["password"]
            };

            return passwordDTO;
        }

        public List<PasswordDTO> BuildObjects(List<Dictionary<string, object>> rowsList)
        {
            var resultsList = new List<PasswordDTO>();
            foreach (var row in rowsList)
            {
                var passwordDTO = BuildObject(row);
                resultsList.Add(passwordDTO);
            }
            return resultsList;
        }

        public SqlOperation GetCreateStatement(PasswordDTO password)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "CreatePassword" }; // Assuming this stored procedure exists

            sqlOperation.AddVarcharParam("@password", password.Password);

            return sqlOperation;
        }

        public SqlOperation GetDeleteStatement(int id)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "DeletePassword" }; // Assuming this stored procedure exists
            sqlOperation.AddIntParam("@id", id);
            return sqlOperation;
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            return new SqlOperation { ProcedureName = "GetAllPasswords" }; // Assuming this stored procedure exists
        }

        public SqlOperation GetRetrieveByIdStatement(int id)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "GetPasswordById" }; // Assuming this stored procedure exists
            sqlOperation.AddIntParam("@id", id);
            return sqlOperation;
        }

        public SqlOperation GetUpdateStatement(PasswordDTO password)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "UpdatePassword" }; // Assuming this stored procedure exists

            sqlOperation.AddIntParam("@id", password.Id);
            sqlOperation.AddVarcharParam("@password", password.Password);

            return sqlOperation;
        }
    }
}
