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
                Id = (int)row["id"],
                UserId = (int)row["user_id"],
                CreatorId = (int)row["creator_id"]
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

            sqlOperation.AddIntParam("@user_Id", routine.UserId);
            sqlOperation.AddIntParam("@creator_id", routine.CreatorId);

            return sqlOperation;
        }

        public SqlOperation GetDeleteStatement(int id)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "DeleteRoutine" };
            sqlOperation.AddIntParam("@id", id);
            return sqlOperation;
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            return new SqlOperation { ProcedureName = "GetAllRoutines" };
        }

        public SqlOperation GetRetrieveByIdStatement(int id)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "GetRoutineById" };
            sqlOperation.AddIntParam("@id", id);
            return sqlOperation;
        }

        public SqlOperation GetUpdateStatement(RoutineDTO routine)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "UpdateRoutine" };

            sqlOperation.AddIntParam("@id", routine.Id);
            sqlOperation.AddIntParam("@user_id", routine.UserId);
            sqlOperation.AddIntParam("@creator_id", routine.CreatorId);

            return sqlOperation;
        }
    }
}
