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

        public SqlOperation GetCreateStatement(TypeUserDTO typeUser) // create
        {
            var operation = new SqlOperation { ProcedureName = "CreateTypeUser" };
            operation.AddVarcharParam("@name", typeUser.Name);
            return operation;
        }

        public SqlOperation GetRetrieveByIdStatement(int id) // return by ID
        {
            var operation = new SqlOperation { ProcedureName = "GetTypeUserById" };
            operation.AddIntParam("@id", id);
            return operation;
        }

        public SqlOperation GetUpdateStatement(TypeUserDTO typeUser) // Update
        {
            var operation = new SqlOperation { ProcedureName = "UpdateTypeUser" };
            operation.AddIntParam("@id", typeUser.Id);
            operation.AddVarcharParam("@name", typeUser.Name);
            return operation;
        }

        public SqlOperation GetDeleteStatement(int id) // Delete
        {
            var operation = new SqlOperation { ProcedureName = "DeleteTypeUser" };
            operation.AddIntParam("@id", id);
            return operation;
        }

        public SqlOperation GetRetrieveAllStatement() // Update
        {
            return new SqlOperation { ProcedureName = "GetAllTypeUsers" };
        }
    }
}
