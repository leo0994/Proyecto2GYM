using DTOs;
using System.Collections.Generic;

namespace DAO.Mapper
{
    public class HistoryPasswordUserMapper : ISqlStatements, IObjectMapper
    {
        public HistoryPasswordUserDTO BuildObject(Dictionary<string, object> row)
        {
            var historyPasswordUserDTO = new HistoryPasswordUserDTO
            {
                Id = (int)row["id"],
                Date = (DateTime)row["date"],
                UserId = (int)row["userId"],
                PasswordId = (int)row["passwordId"]
            };

            return historyPasswordUserDTO;
        }

        public List<HistoryPasswordUserDTO> BuildObjects(List<Dictionary<string, object>> rowsList)
        {
            var resultsList = new List<HistoryPasswordUserDTO>();
            foreach (var row in rowsList)
            {
                var historyPasswordUserDTO = BuildObject(row);
                resultsList.Add(historyPasswordUserDTO);
            }
            return resultsList;
        }

        public SqlOperation GetCreateStatement(HistoryPasswordUserDTO historyPasswordUser)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "CreateHistoryPasswordUser" };

            sqlOperation.AddDateTimeParam("@p_date", historyPasswordUser.Date);
            sqlOperation.AddIntParam("@p_userId", historyPasswordUser.UserId);
            sqlOperation.AddIntParam("@p_passwordId", historyPasswordUser.PasswordId);

            return sqlOperation;
        }

        public SqlOperation GetDeleteStatement(int id)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "DeleteHistoryPasswordUser" };
            sqlOperation.AddIntParam("@p_id", id);
            return sqlOperation;
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            return new SqlOperation { ProcedureName = "GetAllHistoryPasswordUsers" };
        }

        public SqlOperation GetRetrieveByIdStatement(int id)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "GetHistoryPasswordUserById" };
            sqlOperation.AddIntParam("@p_id", id);
            return sqlOperation;
        }

        public SqlOperation GetUpdateStatement(HistoryPasswordUserDTO historyPasswordUser)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "UpdateHistoryPasswordUser" };

            sqlOperation.AddIntParam("@p_id", historyPasswordUser.Id);
            sqlOperation.AddDateTimeParam("@p_date", historyPasswordUser.Date);
            sqlOperation.AddIntParam("@p_userId", historyPasswordUser.UserId);
            sqlOperation.AddIntParam("@p_passwordId", historyPasswordUser.PasswordId);

            return sqlOperation;
        }
    }
}
