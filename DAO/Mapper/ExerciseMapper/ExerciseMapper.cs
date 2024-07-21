using DTOs;
using System.Collections.Generic;

namespace DAO.Mapper
{
    public class ExerciseMapper : ICrudStatements<ExerciseDTO>, IObjectMapper<ExerciseDTO>
    {
        public ExerciseDTO BuildObject(Dictionary<string, object> row)
        {
            var exercise = new ExerciseDTO
            {
                Id = (int)row["id"],
                Description = (string)row["description"],
                MachineId = row["machine_id"] != DBNull.Value ? (int?)row["machine_id"] : null,
                ExerciseBaseId = (int)row["exerciseBase_id"],
                RoutineId = (int)row["routine_id"]
            };

            return exercise;
        }

        public List<ExerciseDTO> BuildObjects(List<Dictionary<string, object>> rowsList)
        {
            var resultsList = new List<ExerciseDTO>();
            foreach (var row in rowsList)
            {
                var exercise = BuildObject(row);
                resultsList.Add(exercise);
            }
            return resultsList;
        }

        public SqlOperation GetCreateStatement(ExerciseDTO exercise)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "AddExerciseToRoutine" };

            sqlOperation.AddIntParam("@routine_id", exercise.RoutineId);
            sqlOperation.AddIntParam("@exerciseBase_id", exercise.ExerciseBaseId);
            sqlOperation.AddVarcharParam("@description", exercise.Description);
            sqlOperation.AddNullableIntParam("@machine_id", exercise.MachineId);

            return sqlOperation;
        }

        public SqlOperation GetDeleteStatement(int id)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "DeleteExercise" };
            sqlOperation.AddIntParam("@exercise_id", id);
            return sqlOperation;
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            return new SqlOperation { ProcedureName = "GetAllExercises" }; // Assuming the existence of this stored procedure
        }

        public SqlOperation GetRetrieveByIdStatement(int id)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "GetExerciseById" }; // Assuming the existence of this stored procedure
            sqlOperation.AddIntParam("@exercise_id", id);
            return sqlOperation;
        }

        public SqlOperation GetUpdateStatement(ExerciseDTO exercise)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "UpdateExercise" };

            sqlOperation.AddIntParam("@exercise_id", exercise.Id);
            sqlOperation.AddVarcharParam("@description", exercise.Description);
            sqlOperation.AddNullableIntParam("@machine_id", exercise.MachineId);
            sqlOperation.AddIntParam("@exerciseBase_id", exercise.ExerciseBaseId);

            return sqlOperation;
        }
    }
}
