using DTOs;
using System.Collections.Generic;

namespace DAO.Mapper
{
    public class MeasureMapper : ICrudStatements<MeasureDTO>, IObjectMapper<MeasureDTO>
    {
        public MeasureDTO BuildObject(Dictionary<string, object> row)
        {
            var measure = new MeasureDTO
            {
                Id = (int)row["id"],
                Weight = (decimal)row["weight"],
                Height = (decimal)row["height"],
                BodyFat = (decimal)row["bodyFat"],
                Date = (DateTime)row["date"],
                UserId = (int)row["user_id"]
            };

            return measure;
        }

        public List<MeasureDTO> BuildObjects(List<Dictionary<string, object>> rowsList)
        {
            var resultsList = new List<MeasureDTO>();
            foreach (var row in rowsList)
            {
                var measure = BuildObject(row);
                resultsList.Add(measure);
            }
            return resultsList;
        }

        public SqlOperation GetCreateStatement(MeasureDTO measure)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "RegisterMeasurement" };

            sqlOperation.AddIntParam("@p_user_id", measure.UserId);
            sqlOperation.AddFloatParam("@p_weight", (float)measure.Weight);
            sqlOperation.AddFloatParam("@p_height", (float)measure.Height);
            sqlOperation.AddFloatParam("@p_bodyFat", (float)measure.BodyFat);
            sqlOperation.AddDateTimeParam("@p_date", measure.Date);

            return sqlOperation;
        }

        public SqlOperation GetDeleteStatement(int id)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "DeleteMeasurement" };
            sqlOperation.AddIntParam("@p_measure_id", id);
            return sqlOperation;
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            return new SqlOperation { ProcedureName = "GetAllMeasurements" }; // Assuming the existence of this stored procedure
        }

        public SqlOperation GetRetrieveByIdStatement(int id)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "GetMeasurementById" }; // Assuming the existence of this stored procedure
            sqlOperation.AddIntParam("@p_measure_id", id);
            return sqlOperation;
        }

        public SqlOperation GetUpdateStatement(MeasureDTO measure)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "UpdateMeasurement" };

            sqlOperation.AddIntParam("@p_measure_id", measure.Id);
            sqlOperation.AddFloatParam("@p_weight", (float)measure.Weight);
            sqlOperation.AddFloatParam("@p_height", (float)measure.Height);
            sqlOperation.AddFloatParam("@p_bodyFat", (float)measure.BodyFat);
            sqlOperation.AddDateTimeParam("@p_date", measure.Date);

            return sqlOperation;
        }
    }
}
