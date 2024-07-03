using DTOs;
using System.Collections.Generic;

namespace DAO.Mapper
{
    public class MachineMapper : ISqlStatements, IObjectMapper
    {
        public MachineDTO BuildObject(Dictionary<string, object> row)
        {
            var machineDTO = new MachineDTO
            {
                Id = (int)row["id"],
                Name = (string)row["name"],
                Description = (string)row["description"]
            };

            return machineDTO;
        }

        public List<MachineDTO> BuildObjects(List<Dictionary<string, object>> rowsList)
        {
            var resultsList = new List<MachineDTO>();
            foreach (var row in rowsList)
            {
                var machineDTO = BuildObject(row);
                resultsList.Add(machineDTO);
            }
            return resultsList;
        }

        public SqlOperation GetCreateStatement(MachineDTO machine)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "CreateMachine" };

            sqlOperation.AddVarcharParam("@p_name", machine.Name);
            sqlOperation.AddVarcharParam("@p_description", machine.Description);

            return sqlOperation;
        }

        public SqlOperation GetDeleteStatement(int id)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "DeleteMachine" };
            sqlOperation.AddIntParam("@p_id", id);
            return sqlOperation;
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            return new SqlOperation { ProcedureName = "GetAllMachines" };
        }

        public SqlOperation GetRetrieveByIdStatement(int id)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "GetMachineById" };
            sqlOperation.AddIntParam("@p_id", id);
            return sqlOperation;
        }

        public SqlOperation GetUpdateStatement(MachineDTO machine)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "UpdateMachine" };

            sqlOperation.AddIntParam("@p_id", machine.Id);
            sqlOperation.AddVarcharParam("@p_name", machine.Name);
            sqlOperation.AddVarcharParam("@p_description", machine.Description);

            return sqlOperation;
        }
    }
}
