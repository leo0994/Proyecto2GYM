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
                //MachineId = row["machine_id"] != DBNull.Value ? (int?)row["machine_id"] : null,
                MachineId  =(int)row["machine_id"],
                ExerciseBaseId = (int)row["exerciseBase_id"],
                Reps = row["reps"] != DBNull.Value ? (int?)row["reps"] : null,
                //Weight = row["weight"] != DBNull.Value ? (float?)row["reps"] : null,
                Weight = row["weight"] != DBNull.Value ? Convert.ToSingle(row["weight"]) : (float?)null,
                Time=row["time"] != DBNull.Value ? (int?)row["reps"] : null,
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
            var sqlOperation = new SqlOperation { ProcedureName = "dbo.InsertExercise" };

            sqlOperation.AddIntParam("@id", exercise.Id);
            sqlOperation.AddVarcharParam("@description", exercise.Description);
            sqlOperation.AddNullableIntParam("machine_id", exercise.MachineId);
            sqlOperation.AddIntParam("@exerciseBase_id", exercise.ExerciseBaseId);
            sqlOperation.AddIntParam("@reps", exercise.Reps ?? 0); //nullish coalising https://www.bing.com/search?pglt=171&q=nullish+coalescing&cvid=3d23c5b59c654bcbad1613576ad246d3&gs_lcrp=EgZjaHJvbWUqBggAEAAYQDIGCAAQABhAMgYIARAAGEAyBggCEAAYQDIGCAMQABhAMgYIBBAAGEAyBggFEAAYQDIGCAYQABhAMgYIBxAAGEAyBggIEAAYQNIBCDYwNTRqMGoxqAIAsAIA&FORM=ANNTA1&adppc=EDGEESS&PC=HCTS
            sqlOperation.AddFloatParam("@weight", exercise.Weight ?? 0);
            sqlOperation.AddNullableIntParam("@time", exercise.Time);  
           

            return sqlOperation;
        }

        public SqlOperation GetDeleteStatement(int id)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "dbo.DeleteExercise" };
            sqlOperation.AddIntParam("@id", id);
            return sqlOperation;
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            return new SqlOperation { ProcedureName = "dbo.GetAllExercises" };
        }

        public SqlOperation GetRetrieveByIdStatement(int id)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "dbo.GetExerciseById" };
            sqlOperation.AddIntParam("@p_exercise_id", id);
            return sqlOperation;
        }

        public SqlOperation GetUpdateStatement(ExerciseDTO exercise)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "dbo.UpdateExercise" };

            sqlOperation.AddIntParam("@id", exercise.Id);
            sqlOperation.AddVarcharParam("@description", exercise.Description);
            sqlOperation.AddNullableIntParam("machine_id", exercise.MachineId);
            sqlOperation.AddIntParam("@exerciseBase_id", exercise.ExerciseBaseId);
            sqlOperation.AddIntParam("@reps", exercise.Reps ?? 0); //nullish coalising https://www.bing.com/search?pglt=171&q=nullish+coalescing&cvid=3d23c5b59c654bcbad1613576ad246d3&gs_lcrp=EgZjaHJvbWUqBggAEAAYQDIGCAAQABhAMgYIARAAGEAyBggCEAAYQDIGCAMQABhAMgYIBBAAGEAyBggFEAAYQDIGCAYQABhAMgYIBxAAGEAyBggIEAAYQNIBCDYwNTRqMGoxqAIAsAIA&FORM=ANNTA1&adppc=EDGEESS&PC=HCTS
            sqlOperation.AddFloatParam("@weight", exercise.Weight ?? 0);
            sqlOperation.AddNullableIntParam("@time", exercise.Time);  
           

            return sqlOperation;
        }
    }
}
