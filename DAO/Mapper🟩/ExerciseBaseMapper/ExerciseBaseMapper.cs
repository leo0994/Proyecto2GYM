using DTOs;
using System.Collections.Generic;

namespace DAO.Mapper
{
    public class ExerciseBaseMapper : ISqlStatements, IObjectMapper
    {
        public ExerciseBaseDTO BuildObject(Dictionary<string, object> row)
        {
            var exerciseBaseDTO = new ExerciseBaseDTO
            {
                Id = (int)row["id"],
                Name = (string)row["name"],
                TypeExercise = (string)row["typeExercise"]
            };

            return exerciseBaseDTO;
        }

        public List<ExerciseBaseDTO> BuildObjects(List<Dictionary<string, object>> rowsList)
        {
            var resultsList = new List<ExerciseBaseDTO>();
            foreach (var row in rowsList)
            {
                var exerciseBaseDTO = BuildObject(row);
                resultsList.Add(exerciseBaseDTO);
            }
            return resultsList;
        }

        public SqlOperation GetCreateStatement(ExerciseBaseDTO exerciseBase)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "CreateExerciseBase" };

            sqlOperation.AddVarcharParam("@p_name", exerciseBase.Name);
            sqlOperation.AddVarcharParam("@p_typeExercise", exerciseBase.TypeExercise);

            return sqlOperation;
        }

        public SqlOperation GetDeleteStatement(int id)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "DeleteExerciseBase" };
            sqlOperation.AddIntParam("@p_id", id);
            return sqlOperation;
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            return new SqlOperation { ProcedureName = "GetAllExerciseBases" };
        }

        public SqlOperation GetRetrieveByIdStatement(int id)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "GetExerciseBaseById" };
            sqlOperation.AddIntParam("@p_id", id);
            return sqlOperation;
        }

        public SqlOperation GetUpdateStatement(ExerciseBaseDTO exerciseBase)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "UpdateExerciseBase" };

            sqlOperation.AddIntParam("@p_id", exerciseBase.Id);
            sqlOperation.AddVarcharParam("@p_name", exerciseBase.Name);
            sqlOperation.AddVarcharParam("@p_typeExercise", exerciseBase.TypeExercise);

            return sqlOperation;
        }
    }
}
