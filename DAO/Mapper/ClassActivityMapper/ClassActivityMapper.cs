using DTOs;
using DAO.Mapper;
using System.Collections.Generic;

namespace DAO.Mapper
{
    public class ClassActivityMapper : ICrudStatements<ClassActivityDTO>, IObjectMapper<ClassActivityDTO>
    {
        public ClassActivityDTO BuildObject(Dictionary<string, object> row)
        {
            var classActivityDTO = new ClassActivityDTO
            {
                Id = (int)row["id"],
                Name = (string)row["name"],
                Description = (string)row["description"]
            };

            return classActivityDTO;
        }

        public List<ClassActivityDTO> BuildObjects(List<Dictionary<string, object>> rowsList)
        {
            var resultsList = new List<ClassActivityDTO>();
            foreach (var row in rowsList)
            {
                var classActivityDTO = BuildObject(row);
                resultsList.Add(classActivityDTO);
            }
            return resultsList;
        }

        public SqlOperation GetCreateStatement(ClassActivityDTO classActivity)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "CreateClassActivity" };

            sqlOperation.AddVarcharParam("@p_name", classActivity.Name);
            sqlOperation.AddVarcharParam("@p_description", classActivity.Description);

            return sqlOperation;
        }

        public SqlOperation GetDeleteStatement(int id)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "DeleteClassActivity" };
            sqlOperation.AddIntParam("@p_id", id);
            return sqlOperation;
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            return new SqlOperation { ProcedureName = "GetAllClassActivities" };
        }

        public SqlOperation GetRetrieveByIdStatement(int id)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "GetClassActivityById" };
            sqlOperation.AddIntParam("@p_class_id", id);
            return sqlOperation;
        }

        public SqlOperation GetUpdateStatement(ClassActivityDTO classActivity)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "UpdateClassActivity" };

            sqlOperation.AddIntParam("@p_class_id", classActivity.Id);
            sqlOperation.AddVarcharParam("@p_name", classActivity.Name);
            sqlOperation.AddVarcharParam("@p_description", classActivity.Description);

            return sqlOperation;
        }
    }
}
