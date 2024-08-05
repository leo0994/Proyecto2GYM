using DTOs;

namespace DAO.Mapper
{
    public class SubscriptionMapper : ICrudStatements<SubscriptionDTO>, IObjectMapper<SubscriptionDTO>
    {
        public SubscriptionDTO BuildObject(Dictionary<string, object> row)
        {
            var subscription = new SubscriptionDTO
            {
                Name = (string)row["Name"],
                Email = (string)row["Contact"],
                Date = (DateTime)row["Date"],
                Status = (string)row["Status"]
            };

            return subscription;
        }

        public List<SubscriptionDTO> BuildObjects(List<Dictionary<string, object>> rowsList)
        {
            var resultsList = new List<SubscriptionDTO>();
            foreach (var row in rowsList)
            {
                var subscription = BuildObject(row);
                resultsList.Add(subscription);
            }
            return resultsList;
        }

        // NO
        public SqlOperation GetCreateStatement(SubscriptionDTO subscription)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "" };
            return sqlOperation;
        }

        // NO
        public SqlOperation GetDeleteStatement(int id)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "" };
            return sqlOperation;
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            return new SqlOperation { ProcedureName = "GetAllSubscriptions" };
        }

        // NO
        public SqlOperation GetRetrieveByIdStatement(int id)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "dbo.GetSubscriptionById" };
            sqlOperation.AddIntParam("@id", id);
            return sqlOperation;
        }

        // NO
        public SqlOperation GetUpdateStatement(SubscriptionDTO routine)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "dbo.UpdateRoutine" };

            sqlOperation.AddVarcharParam("@status", routine.Status);

            return sqlOperation;
        }
    }
}