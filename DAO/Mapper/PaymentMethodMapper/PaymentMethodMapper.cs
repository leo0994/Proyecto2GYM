using DTOs;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace DAO.Mapper
{
    public class PaymentMethodMapper : ICrudStatements<PaymentMethodDTO>, IObjectMapper<PaymentMethodDTO>
    {
        public PaymentMethodDTO BuildObject(Dictionary<string, object> row)
        {
            return new PaymentMethodDTO
            {
                Id = (int)row["id"],
                Name = (string)row["name"],
                Description = (string)row["description"],
                Active = (bool)row["active"]
            };
        }

        public List<PaymentMethodDTO> BuildObjects(List<Dictionary<string, object>> rows)
        {
            var results = new List<PaymentMethodDTO>();
            foreach (var row in rows)
            {
                results.Add(BuildObject(row));
            }
            return results;
        }

        public SqlOperation GetCreateStatement(PaymentMethodDTO paymentMethod)
        {
            var operation = new SqlOperation { ProcedureName = "CreatePaymentMethod" };
            operation.AddVarcharParam("@name", paymentMethod.Name);
            operation.AddVarcharParam("@description", paymentMethod.Description);
            operation.AddBoolParam("@active", paymentMethod.Active);
            return operation;
        }

        public SqlOperation GetRetrieveByIdStatement(int id)
        {
            var operation = new SqlOperation { ProcedureName = "GetPaymentMethodById" };
            operation.AddIntParam("@id", id);
            return operation;
        }

        public SqlOperation GetUpdateStatement(PaymentMethodDTO paymentMethod)
        {
            var operation = new SqlOperation { ProcedureName = "UpdatePaymentMethod" };
            operation.AddIntParam("@id", paymentMethod.Id);
            operation.AddVarcharParam("@name", paymentMethod.Name);
            operation.AddVarcharParam("@description", paymentMethod.Description);
            operation.AddBoolParam("@active", paymentMethod.Active);
            return operation;
        }

        public SqlOperation GetDeleteStatement(int id)
        {
            var operation = new SqlOperation { ProcedureName = "DeletePaymentMethod" };
            operation.AddIntParam("@id", id);
            return operation;
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            return new SqlOperation { ProcedureName = "GetAllPaymentMethods" };
        }
    }
}
