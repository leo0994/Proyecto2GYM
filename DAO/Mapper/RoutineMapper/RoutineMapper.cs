using DTOs;
using System.Collections.Generic;

namespace DAO.Mapper
{
    public class RoutineMapper : ISqlStatements, IObjectMapper
    {
        public RoutineDTO BuildObject(Dictionary<string, object> row)
        {
            var routineDTO = new RoutineDTO
            {
                Id = (int)row["id"],
                UserId = (int)row["userId"],
                CreatorId = (int)row["creatorId"]
            };

            return routineDTO;
        }

        public List<RoutineDTO> BuildObjects(List<Dictionary<string, object>> rowsList)
        {
            var resultsList = new List<RoutineDTO>();
            foreach (var row in rowsList)
            {
                var routineDTO = BuildObject(row);
                resultsList.Add(routineDTO);
            }
            return resultsList;
        }

        public SqlOperation GetCreateStatement(RoutineDTO routine)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "CreateRoutine" };

            sqlOperation.AddIntParam("@p_userId", routine.UserId);
            sqlOperation.AddIntParam("@p_creatorId", routine.CreatorId);

            return sqlOperation;
        }

        public SqlOperation GetDeleteStatement(int id)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "DeleteRoutine" };
            sqlOperation.AddIntParam("@p_id", id);
            return sqlOperation;
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            return new SqlOperation { ProcedureName = "GetAllRoutines" };
        }

        public SqlOperation GetRetrieveByIdStatement(int id)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "GetRoutineById" };
            sqlOperation.AddIntParam("@p_id", id);
            return sqlOperation;
        }

        public SqlOperation GetUpdateStatement(RoutineDTO routine)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "UpdateRoutine" };

            sqlOperation.AddIntParam("@p_id", routine.Id);
            sqlOperation.AddIntParam("@p_userId", routine.UserId);
            sqlOperation.AddIntParam("@p_creatorId", routine.CreatorId);

            return sqlOperation;
        }
    }
}
