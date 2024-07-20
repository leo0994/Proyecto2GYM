using DTOs;
using System.Collections.Generic;

namespace DAO.Mapper
{
    public class RoutineMapper : ICrudStatements<RoutineDTO>, IObjectMapper<RoutineDTO>
    {
        public RoutineDTO BuildObject(Dictionary<string, object> row)
        {
            var routine = new RoutineDTO
            {
                Id = (int)row["Id"],
                UserId = (int)row["UserId"],
                CreatorId = (int)row["CreatorId"]
            };

            return routine;
        }

        public List<RoutineDTO> BuildObjects(List<Dictionary<string, object>> rowsList)
        {
            var resultsList = new List<RoutineDTO>();
            foreach (var row in rowsList)
            {
                var routine = BuildObject(row);
                resultsList.Add(routine);
            }
            return resultsList;
        }

        public SqlOperation GetCreateStatement(RoutineDTO routine)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "CreateRoutine" };

            sqlOperation.AddIntParam("@UserId", routine.UserId);
            sqlOperation.AddIntParam("@CreatorId", routine.CreatorId);

            return sqlOperation;
        }

        public SqlOperation GetDeleteStatement(int id)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "DeleteRoutine" };
            sqlOperation.AddIntParam("@Id", id);
            return sqlOperation;
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            return new SqlOperation { ProcedureName = "GetAllRoutines" };
        }

        public SqlOperation GetRetrieveByIdStatement(int id)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "GetRoutineById" };
            sqlOperation.AddIntParam("@Id", id);
            return sqlOperation;
        }

        public SqlOperation GetUpdateStatement(RoutineDTO routine)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "UpdateRoutine" };

            sqlOperation.AddIntParam("@Id", routine.Id);
            sqlOperation.AddIntParam("@UserId", routine.UserId);
            sqlOperation.AddIntParam("@CreatorId", routine.CreatorId);

            return sqlOperation;
        }
    }
}
