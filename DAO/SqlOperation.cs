using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace DAO
{
    public class SqlOperation
    {
        public string ProcedureName { get; set; }
        public List<SqlParameter> Parameters { get; set; }

        public SqlOperation()
        {
            Parameters = new List<SqlParameter>();
        }

        public void AddVarcharParam(string paramName, string paramValue)
        {
            Parameters.Add(new SqlParameter(paramName, paramValue));
        }

        public void AddIntParam(string paramName, int paramValue)
        {
            Parameters.Add(new SqlParameter(paramName, paramValue));
        }

        public void AddNullableIntParam(string paramName, int? paramValue)
        {
            if (paramValue.HasValue)
            {
                Parameters.Add(new SqlParameter(paramName, paramValue.Value));
            }
            else
            {
                Parameters.Add(new SqlParameter(paramName, DBNull.Value));
            }
        }

        public void AddDateTimeParam(string paramName, DateTime paramValue)
        {
            Parameters.Add(new SqlParameter(paramName, paramValue));
        }

        public void AddDateOnlyParam(string paramName, DateOnly paramValue)
        {
            Parameters.Add(new SqlParameter(paramName, paramValue));
        }

        public void AddFloatParam(string paramName, float paramValue)
        {
            Parameters.Add(new SqlParameter(paramName, paramValue));
        }

        public void AddDecimalParam(string paramName, decimal paramValue)
        {
            Parameters.Add(new SqlParameter(paramName, paramValue));
        }

        public void AddBoolParam(string paramName, bool paramValue)
        {
            Parameters.Add(new SqlParameter(paramName, paramValue));
        }
    }
}
