using DTOs;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace DAO.Mapper
{
    public class UserMapper : ICrudStatements<UserDTO>, IObjectMapper<UserDTO>
    {
        public UserDTO BuildObject(Dictionary<string, object> row)
        {
            var userDTO = new UserDTO
            {
                Id = (int)row["id"],
                Name = (string)row["name"],
                Email = (string)row["email"],
                Password = (string)row["password"],
                TypeUserId = (int)row["typeUser_id"],
                Number = (string)row["number"],
                Age = (int)row["age"]
            };

            return userDTO;
        }

        public List<UserDTO> BuildObjects(List<Dictionary<string, object>> rowsList)
        {
            var resultsList = new List<UserDTO>();
            foreach (var row in rowsList)
            {
                var userDTO = BuildObject(row);
                resultsList.Add(userDTO);
            }
            return resultsList;
        }

        public SqlOperation GetCreateStatement(UserDTO user)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "CreateUser" };

            sqlOperation.AddVarcharParam("@p_name", user.Name);
            sqlOperation.AddVarcharParam("@p_email", user.Email);
            sqlOperation.AddVarcharParam("@p_password", user.Password);
            sqlOperation.AddIntParam("@p_typeUser_id", user.TypeUserId);
            sqlOperation.AddVarcharParam("@p_number", user.Number);
            sqlOperation.AddIntParam("@p_age", user.Age);

            return sqlOperation;
        }

        public SqlOperation GetDeleteStatement(int id)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "DeleteUser" };
            sqlOperation.AddIntParam("@p_id", id);
            return sqlOperation;
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            return new SqlOperation { ProcedureName = "GetAllUsers" };
        }

        public SqlOperation GetRetrieveByIdStatement(int id)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "GetUserById" };
            sqlOperation.AddIntParam("@p_user_id", id);
            return sqlOperation;
        }

        public SqlOperation GetUpdateStatement(UserDTO user)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "UpdateUser" };

            sqlOperation.AddIntParam("@p_user_id", user.Id);
            sqlOperation.AddVarcharParam("@p_name", user.Name);
            sqlOperation.AddVarcharParam("@p_email", user.Email);
            sqlOperation.AddVarcharParam("@p_password", user.Password);
            sqlOperation.AddIntParam("@p_typeUser_id", user.TypeUserId);
            sqlOperation.AddVarcharParam("@p_number", user.Number);
            sqlOperation.AddIntParam("@p_age", user.Age);

            return sqlOperation;
        }
    }
}
