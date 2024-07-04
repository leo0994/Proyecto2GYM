using DTOs;
using DAO.Mapper;
using System.Collections.Generic;

namespace DAO.Mapper
{
    public class PaymentMapper : ISqlStatements, IObjectMapper
    {
        public PaymentDTO BuildObject(Dictionary<string, object> row)
        {
            var paymentDTO = new PaymentDTO
            {
                Id = (int)row["id"],
                UserId = (int)row["userId"],
                Date = (DateTime)row["date"],
                Amount = (decimal)row["amount"],
                PaymentMethodId = (int)row["paymentMethodId"],
                Status = (string)row["status"]
            };

            return paymentDTO;
        }

        public List<PaymentDTO> BuildObjects(List<Dictionary<string, object>> rowsList)
        {
            var resultsList = new List<PaymentDTO>();
            foreach (var row in rowsList)
            {
                var paymentDTO = BuildObject(row);
                resultsList.Add(paymentDTO);
            }
            return resultsList;
        }

        public SqlOperation GetCreateStatement(PaymentDTO payment)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "CreatePayment" };

            sqlOperation.AddIntParam("@p_userId", payment.UserId);
            sqlOperation.AddDateTimeParam("@p_date", payment.Date);
            sqlOperation.AddDecimalParam("@p_amount", payment.Amount);
            sqlOperation.AddIntParam("@p_paymentMethodId", payment.PaymentMethodId);
            sqlOperation.AddVarcharParam("@p_status", payment.Status);

            return sqlOperation;
        }

        public SqlOperation GetDeleteStatement(int id)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "DeletePayment" };
            sqlOperation.AddIntParam("@p_id", id);
            return sqlOperation;
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            return new SqlOperation { ProcedureName = "GetAllPayments" };
        }

        public SqlOperation GetRetrieveByIdStatement(int id)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "GetPaymentById" };
            sqlOperation.AddIntParam("@p_id", id);
            return sqlOperation;
        }

        public SqlOperation GetUpdateStatement(PaymentDTO payment)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "UpdatePayment" };

            sqlOperation.AddIntParam("@p_id", payment.Id);
            sqlOperation.AddIntParam("@p_userId", payment.UserId);
            sqlOperation.AddDateTimeParam("@p_date", payment.Date);
            sqlOperation.AddDecimalParam("@p_amount", payment.Amount);
            sqlOperation.AddIntParam("@p_paymentMethodId", payment.PaymentMethodId);
            sqlOperation.AddVarcharParam("@p_status", payment.Status);

            return sqlOperation;
        }
    }
}
