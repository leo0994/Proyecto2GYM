using DTOs;
using System.Collections.Generic;

namespace DAO.Mapper
{
    public class ExerciseBaseMapper : ICrudStatements<ExerciseBaseDTO>, IObjectMapper<ExerciseBaseDTO>
    {
        public ExerciseBaseDTO BuildObject(Dictionary<string, object> row)
        {
            var exerciseBase = new ExerciseBaseDTO
            {
                Id = (int)row["id"],
                Name = (string)row["name"],
                TypeExercise = (string)row["typeExercise"]
            };

            return exerciseBase;
        }

        public List<ExerciseBaseDTO> BuildObjects(List<Dictionary<string, object>> rowsList)
        {
            var resultsList = new List<ExerciseBaseDTO>();
            foreach (var row in rowsList)
            {
                var exerciseBase = BuildObject(row);
                resultsList.Add(exerciseBase);
            }
            return resultsList;
        }

        public SqlOperation GetCreateStatement(ExerciseBaseDTO exerciseBase)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "dbo.InsertExerciseBase" }; 

            sqlOperation.AddVarcharParam("@name", exerciseBase.Name);
            sqlOperation.AddVarcharParam("@typeExercise", exerciseBase.TypeExercise);

            return sqlOperation;
        }

        public SqlOperation GetDeleteStatement(int id)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "DeleteExerciseBase" }; // Assuming the existence of this stored procedure
            sqlOperation.AddIntParam("@id", id);
            return sqlOperation;
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            return new SqlOperation { ProcedureName = "dbo.GetAllExerciseBase" }; 
        }

        public SqlOperation GetRetrieveByIdStatement(int id)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "GetExerciseBaseById" };
            sqlOperation.AddIntParam("@id", id);
            return sqlOperation;
        }

        public SqlOperation GetUpdateStatement(ExerciseBaseDTO exerciseBase)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "dbo.UpdateExerciseBaseById" };

            sqlOperation.AddIntParam("@id", exerciseBase.Id);
            sqlOperation.AddVarcharParam("@name", exerciseBase.Name);
            sqlOperation.AddVarcharParam("@typeExercise", exerciseBase.TypeExercise);

            return sqlOperation;
        }
    }
}
