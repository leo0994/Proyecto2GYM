using DTOs;


using System.Collections.Generic;

namespace DAO.Mapper
{
    public class ExerciseRoutineMapper : ICrudStatements<ExerciseRoutineDTO>, IObjectMapper<ExerciseRoutineDTO>
    {
        public ExerciseRoutineDTO BuildObject(Dictionary<string, object> row)
        {
            var exercise = new ExerciseRoutineDTO
            {
                Id = (int)row["Id"],
                IdRoutine = (int)row["IdRoutine"],
                IdExercise = (int)row["IdExercise"],
            };

            return exercise;
        }

        public List<ExerciseRoutineDTO> BuildObjects(List<Dictionary<string, object>> rowsList)
        {
            var resultsList = new List<ExerciseRoutineDTO>();
            foreach (var row in rowsList)
            {
                var exercise = BuildObject(row);
                resultsList.Add(exercise);
            }
            return resultsList;
        }

        public SqlOperation GetCreateStatement(ExerciseRoutineDTO exercise)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "dbo.InsertIntoExcerciseRoutine" }; 

            //sqlOperation.AddIntParam("@Id", exercise.Id);
            sqlOperation.AddIntParam("@IdRoutine", exercise.IdRoutine);
            sqlOperation.AddIntParam("@IdExercise", exercise.IdExercise);
            return sqlOperation;
        }

        public SqlOperation GetDeleteStatement(int id)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "dbo.DeleteExerciseRoutine" };
            sqlOperation.AddIntParam("@Id", id);
            return sqlOperation;
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            return new SqlOperation { ProcedureName = "dbo.GetAllExerciseRoutines" };
        }

        public SqlOperation GetRetrieveByIdStatement(int id)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "dbo.GetExerciseRoutineById" };
            sqlOperation.AddIntParam("@id", id);
            return sqlOperation;
        }

        public SqlOperation GetUpdateStatement(ExerciseRoutineDTO exercise)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "dbo.UpdateExerciseRoutine" };

            sqlOperation.AddIntParam("@id", exercise.Id);
            sqlOperation.AddIntParam("@IdRoutine", exercise.IdRoutine);
            sqlOperation.AddIntParam("@IdExercise", exercise.IdExercise);
           
            return sqlOperation;
        }
    }
}
