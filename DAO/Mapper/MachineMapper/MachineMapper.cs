using DTOs;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace DAO.Mapper
{
    public class MachineMapper : ICrudStatements<MachineDTO>, IObjectMapper<MachineDTO>
    {
        public MachineDTO BuildObject(Dictionary<string, object> row)
        {
            return new MachineDTO
            {
                Id = (int)row["id"],
                Name = (string)row["name"],
                Description = (string)row["description"]
            };
        }

        public List<MachineDTO> BuildObjects(List<Dictionary<string, object>> rows)
        {
            var results = new List<MachineDTO>();
            foreach (var row in rows)
            {
                results.Add(BuildObject(row));
            }
            return results;
        }

        public SqlOperation GetCreateStatement(MachineDTO machine)
        {
            var operation = new SqlOperation { ProcedureName = "RegisterMachine" };
<<<<<<< HEAD
            operation.AddIntParam("@id",machine.Id);
            operation.AddVarcharParam("@name", machine.Name);
            operation.AddVarcharParam("@description", machine.Description);
=======
            operation.AddVarcharParam("@p_name", machine.Name);
            operation.AddVarcharParam("@p_description", machine.Description);
>>>>>>> 53a16680bd09438736e6386c08c9ad047a1d3f34
            return operation;
        }

        public SqlOperation GetRetrieveByIdStatement(int id)
        {
            var operation = new SqlOperation { ProcedureName = "GetMachineById" };
            operation.AddIntParam("@p_id", id);
            return operation;
        }

        public SqlOperation GetUpdateStatement(MachineDTO machine)
        {
            var operation = new SqlOperation { ProcedureName = "UpdateMachine" };
            operation.AddIntParam("@p_id", machine.Id);
            operation.AddVarcharParam("@p_name", machine.Name);
            operation.AddVarcharParam("@p_description", machine.Description);
            return operation;
        }

        public SqlOperation GetDeleteStatement(int id)
        {
            var operation = new SqlOperation { ProcedureName = "DeleteMachine" };
            operation.AddIntParam("@p_id", id);
            return operation;
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            return new SqlOperation { ProcedureName = "GetAllMachines" };
        }
    }
}
