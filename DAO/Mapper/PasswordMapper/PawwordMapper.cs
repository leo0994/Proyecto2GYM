using DTOs;
using DAO.Mapper;
using System.Collections.Generic;

namespace DAO.Mapper
{
    public class PasswordMapper : ISqlStatements, IObjectMapper
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
            var sqlOperation = new SqlOperation { ProcedureName = "CreatePassword" };

            sqlOperation.AddVarcharParam("@p_password", password.Password);

            return sqlOperation;
        }

        public SqlOperation GetDeleteStatement(int id)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "DeletePassword" };
            sqlOperation.AddIntParam("@p_id", id);
            return sqlOperation;
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            return new SqlOperation { ProcedureName = "GetAllPasswords" };
        }

        public SqlOperation GetRetrieveByIdStatement(int id)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "GetPasswordById" };
            sqlOperation.AddIntParam("@p_id", id);
            return sqlOperation;
        }

        public SqlOperation GetUpdateStatement(PasswordDTO password)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "UpdatePassword" };

            sqlOperation.AddIntParam("@p_id", password.Id);
            sqlOperation.AddVarcharParam("@p_password", password.Password);

            return sqlOperation;
        }
    }
}
