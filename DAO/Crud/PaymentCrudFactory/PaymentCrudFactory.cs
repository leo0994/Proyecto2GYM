using DTOs;
using DAO.Mapper;
using System.Collections.Generic;

namespace DAO.Crud
{
    public class PaymentCrudFactory : CrudFactory<PaymentDTO>
    {
        private readonly PaymentMapper _paymentMapper; // Renombrado para evitar ambigüedad

        public PaymentCrudFactory()
        {
            dao = SqlDAO.GetInstance();
            _paymentMapper = new PaymentMapper();
        }

        public override PaymentDTO Create(PaymentDTO payment)
        {
            var sqlOperation = _paymentMapper.GetCreateStatement(payment);
            dao.ExecuteProcedure(sqlOperation);
            return payment;
        }

        public override PaymentDTO Delete(PaymentDTO payment)
        {
            var sqlOperation = _paymentMapper.GetDeleteStatement(payment.Id);
            dao.ExecuteProcedure(sqlOperation);
            return payment;
        }

        public override List<PaymentDTO> RetrieveAll()
        {
            var sqlOperation = _paymentMapper.GetRetrieveAllStatement();
            var result = dao.ExecuteQueryProcedure(sqlOperation);
            return _paymentMapper.BuildObjects(result);
        }

        public override PaymentDTO RetrieveById(int id)
        {
            var sqlOperation = _paymentMapper.GetRetrieveByIdStatement(id);
            var result = dao.ExecuteQueryProcedure(sqlOperation);
            if (result.Count > 0)
            {
                return _paymentMapper.BuildObject(result[0]);
            }
            return null;
        }

        public override PaymentDTO Update(PaymentDTO payment)
        {
            var sqlOperation = _paymentMapper.GetUpdateStatement(payment);
            dao.ExecuteProcedure(sqlOperation);
            return payment;
        }
    }
}
