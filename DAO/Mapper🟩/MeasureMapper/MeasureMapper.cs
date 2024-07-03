using DTOs;
using DAO.Mapper;
using System;
using System.Collections.Generic;

namespace DAO.Mapper
{
    public class MeasureMapper : ISqlStatements, IObjectMapper
    {
        public MeasureDTO BuildObject(Dictionary<string, object> row)
        {
            var measureDTO = new MeasureDTO
            {
                Id = (int)row["id"],
                Weight = (decimal)row["weight"],
                Height = (decimal)row["height"],
                BodyFat = (decimal)row["bodyFat"],
                Date = (DateTime)row["date"],
                UserId = (int)row["userId"]
            };

            return measureDTO;
        }

        public List<MeasureDTO> BuildObjects(List<Dictionary<string, object>> rowsList)
        {
            var resultsList = new List<MeasureDTO>();
            foreach (var row in rowsList)
            {
                var measureDTO = BuildObject(row);
                resultsList.Add(measureDTO);
            }
            return resultsList;
        }

        public SqlOperation GetCreateStatement(MeasureDTO measure)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "CreateMeasure" };

            sqlOperation.AddDecimalParam("@p_weight", measure.Weight);
            sqlOperation.AddDecimalParam("@p_height", measure.Height);
            sqlOperation.AddDecimalParam("@p_bodyFat", measure.BodyFat);
            sqlOperation.AddDateTimeParam("@p_date", measure.Date);
            sqlOperation.AddIntParam("@p_userId", measure.UserId);

            return sqlOperation;
        }

        public SqlOperation GetDeleteStatement(int id)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "DeleteMeasure" };
            sqlOperation.AddIntParam("@p_id", id);
            return sqlOperation;
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            return new SqlOperation { ProcedureName = "GetAllMeasures" };
        }

        public SqlOperation GetRetrieveByIdStatement(int id)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "GetMeasureById" };
            sqlOperation.AddIntParam("@p_id", id);
            return sqlOperation;
        }

        public SqlOperation GetUpdateStatement(MeasureDTO measure)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "UpdateMeasure" };

            sqlOperation.AddIntParam("@p_id", measure.Id);
            sqlOperation.AddDecimalParam("@p_weight", measure.Weight);
            sqlOperation.AddDecimalParam("@p_height", measure.Height);
            sqlOperation.AddDecimalParam("@p_bodyFat", measure.BodyFat);
            sqlOperation.AddDateTimeParam("@p_date", measure.Date);
            sqlOperation.AddIntParam("@p_userId", measure.UserId);

            return sqlOperation;
        }
    }
}
