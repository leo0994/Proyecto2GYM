using DTOs;
using System.Collections.Generic;

namespace DAO.Crud
{
    public class PaymentMethodCrudFactory : CrudFactory
    {
        private readonly PaymentMethodMapper _mapper;

        public PaymentMethodCrudFactory()
        {
            _mapper = new PaymentMethodMapper();
            dao = SqlDAO.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var paymentMethod = (PaymentMethodDTO)entity;
            var sqlOperation = _mapper.GetCreateStatement(paymentMethod);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override void Update(BaseEntity entity)
        {
            var paymentMethod = (PaymentMethodDTO)entity;
            var sqlOperation = _mapper.GetUpdateStatement(paymentMethod);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override void Delete(BaseEntity entity)
        {
            var paymentMethod = (PaymentMethodDTO)entity;
            var sqlOperation = _mapper.GetDeleteStatement(paymentMethod.Id);
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

            var paymentMethod = _mapper.BuildObject(dic);
            return (T)System.Convert.ChangeType(paymentMethod, typeof(T));
        }

        public override List<T> RetrieveAll<T>()
        {
            var sqlOperation = _mapper.GetRetrieveAllStatement();
            var lstResult = dao.ExecuteQueryProcedure(sqlOperation);

            var paymentMethods = _mapper.BuildObjects(lstResult);
            var list = new List<T>();

            foreach (var paymentMethod in paymentMethods)
            {
                list.Add((T)System.Convert.ChangeType(paymentMethod, typeof(T)));
            }

            return list;
        }
    }
}
