using DTOs;
using System.Collections.Generic;

namespace DAO.Mapper
{
    public class TypeUserMapper : ICrudStatements<TypeUserDTO>, IObjectMapper<TypeUserDTO>
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
            var results = new List<TypeUserDTO>();
            foreach (var row in rows)
            {
                results.Add(BuildObject(row));
            }
            return results;
        }

        public SqlOperation GetCreateStatement(TypeUserDTO typeUser)
        {
            var operation = new SqlOperation { ProcedureName = "CreateTypeUser" };
            operation.AddVarcharParam("@p_name", typeUser.Name);
            return operation;
        }

        public SqlOperation GetRetrieveByIdStatement(int id)
        {
            var operation = new SqlOperation { ProcedureName = "GetTypeUserById" };
            operation.AddIntParam("@p_id", id);
            return operation;
        }

        public SqlOperation GetUpdateStatement(TypeUserDTO typeUser)
        {
            var operation = new SqlOperation { ProcedureName = "UpdateTypeUser" };
            operation.AddIntParam("@p_id", typeUser.Id);
            operation.AddVarcharParam("@p_name", typeUser.Name);
            return operation;
        }

        public SqlOperation GetDeleteStatement(int id)
        {
            var operation = new SqlOperation { ProcedureName = "DeleteTypeUser" };
            operation.AddIntParam("@p_id", id);
            return operation;
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            return new SqlOperation { ProcedureName = "GetAllTypeUsers" };
        }
    }
}
