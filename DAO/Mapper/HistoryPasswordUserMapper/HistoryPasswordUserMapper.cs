using DTOs;
using System.Collections.Generic;

namespace DAO.Mapper
{
    public class HistoryPasswordUserMapper : ICrudStatements<HistoryPasswordUserDTO>, IObjectMapper<HistoryPasswordUserDTO>
    {
        public HistoryPasswordUserDTO BuildObject(Dictionary<string, object> row)
        {
            var historyPasswordUser = new HistoryPasswordUserDTO
            {
                Id = (int)row["id"],
                Date = (DateTime)row["date"],
                UserId = (int)row["user_id"],
                PasswordId = (int)row["password_id"]
            };

            return historyPasswordUser;
        }

        public List<HistoryPasswordUserDTO> BuildObjects(List<Dictionary<string, object>> rowsList)
        {
            var resultsList = new List<HistoryPasswordUserDTO>();
            foreach (var row in rowsList)
            {
                var historyPasswordUser = BuildObject(row);
                resultsList.Add(historyPasswordUser);
            }
            return resultsList;
        }

        public SqlOperation GetCreateStatement(HistoryPasswordUserDTO historyPasswordUser)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "UpdateUserPassword" };

            sqlOperation.AddIntParam("@user_id", historyPasswordUser.UserId);
            sqlOperation.AddIntParam("@password_id", historyPasswordUser.PasswordId);
            sqlOperation.AddDateTimeParam("@date", historyPasswordUser.Date);

            return sqlOperation;
        }

        public SqlOperation GetDeleteStatement(int id)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "DeleteHistoryPasswordUser" }; // Assuming the existence of this stored procedure
            sqlOperation.AddIntParam("@id", id);
            return sqlOperation;
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            return new SqlOperation { ProcedureName = "GetAllHistoryPasswordUsers" }; // Assuming the existence of this stored procedure
        }

        public SqlOperation GetRetrieveByIdStatement(int id)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "GetHistoryPasswordUserById" }; // Assuming the existence of this stored procedure
            sqlOperation.AddIntParam("@id", id);
            return sqlOperation;
        }

        public SqlOperation GetUpdateStatement(HistoryPasswordUserDTO historyPasswordUser)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "UpdateHistoryPasswordUser" }; // Assuming the existence of this stored procedure

            sqlOperation.AddIntParam("@id", historyPasswordUser.Id);
            sqlOperation.AddDateTimeParam("@date", historyPasswordUser.Date);
            sqlOperation.AddIntParam("@user_id", historyPasswordUser.UserId);
            sqlOperation.AddIntParam("@password_id", historyPasswordUser.PasswordId);

            return sqlOperation;
        }
    }
}
