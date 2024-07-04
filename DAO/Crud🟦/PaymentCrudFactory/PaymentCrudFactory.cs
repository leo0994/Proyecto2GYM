using DTOs;
using DAO.Crud;
using System.Collections.Generic;

namespace DAO.Crud
{
    public class PaymentCrudFactory : CrudFactory
    {
        private readonly PaymentMapper _mapper;

        public PaymentCrudFactory()
        {
            _mapper = new PaymentMapper();
            dao = SqlDAO.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var payment = (PaymentDTO)entity;
            var sqlOperation = _mapper.GetCreateStatement(payment);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override void Update(BaseEntity entity)
        {
            var payment = (PaymentDTO)entity;
            var sqlOperation = _mapper.GetUpdateStatement(payment);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override void Delete(BaseEntity entity)
        {
            var payment = (PaymentDTO)entity;
            var sqlOperation = _mapper.GetDeleteStatement(payment.Id);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override T Retrieve<T>(int id)
        {
            var sqlOperation = _mapper.GetRetrieveByIdStatement(id);
            var lstResult = dao.ExecuteQueryProcedure(sqlOperation);
            var dic = new Dictionary<string, object>();

            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
            }

            var payment = _mapper.BuildObject(dic);
            return (T)System.Convert.ChangeType(payment, typeof(T));
        }

        public override List<T> RetrieveAll<T>()
        {
            var sqlOperation = _mapper.GetRetrieveAllStatement();
            var lstResult = dao.ExecuteQueryProcedure(sqlOperation);

            var payments = _mapper.BuildObjects(lstResult);
            var list = new List<T>();

            foreach (var payment in payments)
            {
                list.Add((T)System.Convert.ChangeType(payment, typeof(T)));
            }

            return list;
        }
    }
}
