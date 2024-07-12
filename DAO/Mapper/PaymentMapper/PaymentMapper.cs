using DTOs;
using System.Collections.Generic;

namespace DAO.Mapper
{
    public class PaymentMapper : ICrudStatements<PaymentDTO>, IObjectMapper<PaymentDTO>
    {
        public PaymentDTO BuildObject(Dictionary<string, object> row)
        {
            var payment = new PaymentDTO
            {
                Id = (int)row["id"],
                UserId = (int)row["user_id"],
                Date = (DateTime)row["date"],
                Amount = (decimal)row["amount"],
                PaymentMethodId = (int)row["payment_method_id"],
                Status = (string)row["status"]
            };

            return payment;
        }

        public List<PaymentDTO> BuildObjects(List<Dictionary<string, object>> rowsList)
        {
            var resultsList = new List<PaymentDTO>();
            foreach (var row in rowsList)
            {
                var payment = BuildObject(row);
                resultsList.Add(payment);
            }
            return resultsList;
        }

        public SqlOperation GetCreateStatement(PaymentDTO payment)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "RecordPayment" };

            sqlOperation.AddIntParam("@p_user_id", payment.UserId);
            sqlOperation.AddDateTimeParam("@p_date", payment.Date);
            sqlOperation.AddFloatParam("@p_amount", (float)payment.Amount);
            sqlOperation.AddIntParam("@p_payment_method_id", payment.PaymentMethodId);
            sqlOperation.AddVarcharParam("@p_status", payment.Status);

            return sqlOperation;
        }

        public SqlOperation GetDeleteStatement(int id)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "DeletePayment" };
            sqlOperation.AddIntParam("@p_payment_id", id);
            return sqlOperation;
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            return new SqlOperation { ProcedureName = "GetAllPayments" };
        }

        public SqlOperation GetRetrieveByIdStatement(int id)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "GetPaymentById" };
            sqlOperation.AddIntParam("@p_payment_id", id);
            return sqlOperation;
        }

        public SqlOperation GetUpdateStatement(PaymentDTO payment)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "UpdatePayment" };

            sqlOperation.AddIntParam("@p_payment_id", payment.Id);
            sqlOperation.AddIntParam("@p_user_id", payment.UserId);
            sqlOperation.AddDateTimeParam("@p_date", payment.Date);
            sqlOperation.AddFloatParam("@p_amount", (float)payment.Amount);
            sqlOperation.AddIntParam("@p_payment_method_id", payment.PaymentMethodId);
            sqlOperation.AddVarcharParam("@p_status", payment.Status);

            return sqlOperation;
        }
    }
}
