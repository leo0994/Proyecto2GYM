using DTOs;
using DAO.Mapper;
using System.Collections.Generic;

namespace DAO.Mapper
{
    public class ExerciseMapper : ISqlStatements, IObjectMapper
    {
        public ExerciseDTO BuildObject(Dictionary<string, object> row)
        {
            var exerciseDTO = new ExerciseDTO
            {
                Id = (int)row["id"],
                Description = (string)row["description"],
                MachineId = row["machine_id"] != DBNull.Value ? (int?)row["machine_id"] : null,
                ExerciseBaseId = (int)row["exerciseBase_id"],
                RoutineId = (int)row["routine_id"]
            };

            return exerciseDTO;
        }

        public List<ExerciseDTO> BuildObjects(List<Dictionary<string, object>> rowsList)
        {
            var resultsList = new List<ExerciseDTO>();
            foreach (var row in rowsList)
            {
                var exerciseDTO = BuildObject(row);
                resultsList.Add(exerciseDTO);
            }
            return resultsList;
        }

        public SqlOperation GetCreateStatement(ExerciseDTO exercise)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "AddExerciseToRoutine" };

            sqlOperation.AddVarcharParam("@p_description", exercise.Description);
            sqlOperation.AddIntParam("@p_exerciseBase_id", exercise.ExerciseBaseId);
            sqlOperation.AddIntParam("@p_routine_id", exercise.RoutineId);

            if (exercise.MachineId.HasValue)
            {
                sqlOperation.AddIntParam("@p_machine_id", exercise.MachineId.Value);
            }
            else
            {
                sqlOperation.AddIntParam("@p_machine_id", DBNull.Value);
            }

            return sqlOperation;
        }

        public SqlOperation GetDeleteStatement(int id)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "DeleteExercise" };
            sqlOperation.AddIntParam("@p_exercise_id", id);
            return sqlOperation;
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            return new SqlOperation { ProcedureName = "GetAllExercises" };
        }

        public SqlOperation GetRetrieveByIdStatement(int id)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "GetExerciseById" };
            sqlOperation.AddIntParam("@p_exercise_id", id);
            return sqlOperation;
        }

        public SqlOperation GetUpdateStatement(ExerciseDTO exercise)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "UpdateExercise" };

            sqlOperation.AddIntParam("@p_exercise_id", exercise.Id);
            sqlOperation.AddVarcharParam("@p_description", exercise.Description);
            sqlOperation.AddIntParam("@p_exerciseBase_id", exercise.ExerciseBaseId);
            sqlOperation.AddIntParam("@p_routine_id", exercise.RoutineId);

            if (exercise.MachineId.HasValue)
            {
                sqlOperation.AddIntParam("@p_machine_id", exercise.MachineId.Value);
            }
            else
            {
                sqlOperation.AddIntParam("@p_machine_id", DBNull.Value);
            }

            return sqlOperation;
        }
    }
}
