using DTOs;
using System.Collections.Generic;

namespace DAO.Mapper
{
    public class PaymentMethodMapper : ISqlStatements, IObjectMapper
    {
        public PaymentMethodDTO BuildObject(Dictionary<string, object> row)
        {
            var paymentMethodDTO = new PaymentMethodDTO
            {
                Id = (int)row["id"],
                Name = (string)row["name"],
                Description = (string)row["description"],
                Active = (bool)row["active"]
            };

            return paymentMethodDTO;
        }

        public List<PaymentMethodDTO> BuildObjects(List<Dictionary<string, object>> rowsList)
        {
            var resultsList = new List<PaymentMethodDTO>();
            foreach (var row in rowsList)
            {
                var paymentMethodDTO = BuildObject(row);
                resultsList.Add(paymentMethodDTO);
            }
            return resultsList;
        }

        public SqlOperation GetCreateStatement(PaymentMethodDTO paymentMethod)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "CreatePaymentMethod" };

            sqlOperation.AddVarcharParam("@p_name", paymentMethod.Name);
            sqlOperation.AddVarcharParam("@p_description", paymentMethod.Description);
            sqlOperation.AddBoolParam("@p_active", paymentMethod.Active);

            return sqlOperation;
        }

        public SqlOperation GetDeleteStatement(int id)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "DeletePaymentMethod" };
            sqlOperation.AddIntParam("@p_id", id);
            return sqlOperation;
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            return new SqlOperation { ProcedureName = "GetAllPaymentMethods" };
        }

        public SqlOperation GetRetrieveByIdStatement(int id)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "GetPaymentMethodById" };
            sqlOperation.AddIntParam("@p_id", id);
            return sqlOperation;
        }

        public SqlOperation GetUpdateStatement(PaymentMethodDTO paymentMethod)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "UpdatePaymentMethod" };

            sqlOperation.AddIntParam("@p_id", paymentMethod.Id);
            sqlOperation.AddVarcharParam("@p_name", paymentMethod.Name);
            sqlOperation.AddVarcharParam("@p_description", paymentMethod.Description);
            sqlOperation.AddBoolParam("@p_active", paymentMethod.Active);

            return sqlOperation;
        }
    }
}
