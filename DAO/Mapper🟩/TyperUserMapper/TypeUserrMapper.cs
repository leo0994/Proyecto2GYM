using DAO.Mapper;
using DTOs;
using System.Collections.Generic;

namespace DAO.Mapper
{
    public class TypeUserMapper
    {
        public TypeUserDTO BuildObject(Dictionary<string, object> row)
        {
            return new TypeUserDTO
            {
                Id = (int)row["id"],
                Name = (string)row["name"]
            };
        }

        public List<TypeUserDTO> BuildObjects(List<Dictionary<string, object>> rows)
        {
            var typeUsers = new List<TypeUserDTO>();
            foreach (var row in rows)
            {
                typeUsers.Add(BuildObject(row));
            }
            return typeUsers;
        }

        public SqlOperation GetCreateStatement(TypeUserDTO typeUser)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "CreateTypeUser" };

            sqlOperation.AddVarcharParam("p_name", typeUser.Name);

            return sqlOperation;
        }

        public SqlOperation GetRetrieveByIdStatement(int id)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "GetTypeUserById" };
            sqlOperation.AddIntParam("p_id", id);
            return sqlOperation;
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            return new SqlOperation { ProcedureName = "GetAllTypeUsers" };
        }

        public SqlOperation GetUpdateStatement(TypeUserDTO typeUser)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "UpdateTypeUser" };

            sqlOperation.AddIntParam("p_id", typeUser.Id);
            sqlOperation.AddVarcharParam("p_name", typeUser.Name);

            return sqlOperation;
        }

        public SqlOperation GetDeleteStatement(int id)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "DeleteTypeUser" };
            sqlOperation.AddIntParam("p_id", id);
            return sqlOperation;
        }
    }
}
