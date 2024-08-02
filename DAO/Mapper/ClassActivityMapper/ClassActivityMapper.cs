using DTOs;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace DAO.Mapper
{
    public class ClassActivityMapper : ICrudStatements<ClassActivityDTO>, IObjectMapper<ClassActivityDTO>
    {
        public ClassActivityDTO BuildObject(Dictionary<string, object> row)
        {
            return new ClassActivityDTO
            {
                Id = (int)row["id"],
                Name = (string)row["name"],
                Description = (string)row["description"],
                Image_url = row["image_url"] != DBNull.Value ? (string)row["image_url"] : null,
                Instructor = (int)row["Instructor"],
                NameInstructor = (string)row["NameInstructor"],
                DayOfWeek = (string)row["DayOfWeek"],
                Hour = TimeSpan.Parse((string)row["Hour"]),
                Capacity = (int) row["Capacity"]
            };
        }

        public List<ClassActivityDTO> BuildObjects(List<Dictionary<string, object>> rows)
        {
            var results = new List<ClassActivityDTO>();
            foreach (var row in rows)
            {
                results.Add(BuildObject(row));
            }
            return results;
        }

        public SqlOperation GetCreateStatement(ClassActivityDTO classActivity)
        {
            var operation = new SqlOperation { ProcedureName = "CreateClassActivity" };
            operation.AddVarcharParam("@name", classActivity.Name);
            operation.AddVarcharParam("@description", classActivity.Description);
            operation.AddVarcharParam("@image_url", classActivity.Image_url ?? null);
            operation.AddIntParam("@instructor", classActivity.Instructor);
            operation.AddVarcharParam("@dayOfWeek", classActivity.DayOfWeek);
            operation.AddTimeParamAsString("@hour", classActivity.Hour);
            operation.AddIntParam("@capacity", classActivity.Capacity ?? 0);
            return operation;
        }

        public SqlOperation GetRetrieveByIdStatement(int id)
        {
            var operation = new SqlOperation { ProcedureName = "GetClassActivityById" };
            operation.AddIntParam("@id", id);
            return operation;
        }

        public SqlOperation GetUpdateStatement(ClassActivityDTO classActivity)
        {
            var operation = new SqlOperation { ProcedureName = "UpdateClassActivity" };
            operation.AddIntParam("@id", classActivity.Id);
            operation.AddVarcharParam("@name", classActivity.Name);
            operation.AddVarcharParam("@description", classActivity.Description);
            operation.AddVarcharParam("@image_url", classActivity.Image_url ?? null);
            operation.AddIntParam("@instructor", classActivity.Instructor);
            operation.AddVarcharParam("@dayOfWeek", classActivity.DayOfWeek);
            operation.AddTimeParamAsString("@hour", classActivity.Hour);
            operation.AddIntParam("@capacity", classActivity.Capacity ?? 0);
            return operation;
        }

        public SqlOperation GetDeleteStatement(int id)
        {
            var operation = new SqlOperation { ProcedureName = "DeleteClassActivity" };
            operation.AddIntParam("@id", id);
            return operation;
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            return new SqlOperation { ProcedureName = "GetAllClassActivities" };
        }
    }
}
