using DTOs;
using System.Collections.Generic;
using DTO.TypeExcercise;

namespace DAO.Mapper.TypeExerciseMapper;

public class TypeExerciseMapper : ICrudStatements<TypeExerciseDTO>, IObjectMapper<TypeExerciseDTO>
{
    public TypeExerciseDTO BuildObject(Dictionary<string, object> row)
        {
            var typeExercise = new TypeExerciseDTO
            {
                Id = (int)row["id"],
                Name = (string)row["name"],

            };

            return typeExercise;
        }

        public List<TypeExerciseDTO> BuildObjects(List<Dictionary<string, object>> rowsList)
        {
            var resultsList = new List<TypeExerciseDTO>();
            foreach (var row in rowsList)
            {
                var exercise = BuildObject(row);
                resultsList.Add(exercise);
            }
            return resultsList;
        }

    public SqlOperation GetCreateStatement(TypeExerciseDTO entityDTO)
    {
            var operation = new SqlOperation { ProcedureName = "dbo.InsertTypeExercise" };
            operation.AddIntParam("@id",entityDTO.Id);
            operation.AddVarcharParam("@name", entityDTO.Name);
            return operation;
    }



    public SqlOperation GetDeleteStatement(int id)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "dbo.DeleteTypeExercise" };
            sqlOperation.AddIntParam("@id", id);
            return sqlOperation;
        }


        public SqlOperation GetRetrieveAllStatement()
        {
            return new SqlOperation { ProcedureName = "dbo.GetAllTypeExercises" };
        }



        public SqlOperation GetRetrieveByIdStatement(int id)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "dbo.GetTypeExerciseById" };
            sqlOperation.AddIntParam("id", id);
            return sqlOperation;
        }

    public SqlOperation GetUpdateStatement(int id)
    {
            var sqlOperation = new SqlOperation { ProcedureName = "dbo.UpdateTypeExerciseById" };
            sqlOperation.AddIntParam("id", id);
            return sqlOperation;
    }

    public SqlOperation GetUpdateStatement(TypeExerciseDTO entityDTO)
    {
        throw new NotImplementedException();
    }
}
