using DTOs;
using DAO.Mapper;

namespace DAO.Crud
{
    public class SubscriptionCrudFactory : CrudFactory<SubscriptionDTO>
    {
        private readonly SubscriptionMapper _mapper;

        public SubscriptionCrudFactory()
        {
            dao = SqlDAO.GetInstance();
            _mapper = new SubscriptionMapper();
        }

        public override SubscriptionDTO Create(SubscriptionDTO subscription)
        {
            var sqlOperation = _mapper.GetCreateStatement(subscription);
            dao.ExecuteProcedure(sqlOperation);
            return subscription;
        }

        public override SubscriptionDTO Delete(SubscriptionDTO subscription)
        {
            return null;
        }

        public override List<SubscriptionDTO> RetrieveAll()
        {
            var sqlOperation = _mapper.GetRetrieveAllStatement();
            var result = dao.ExecuteQueryProcedure(sqlOperation);
            return _mapper.BuildObjects(result);
        }

        public override SubscriptionDTO RetrieveById(int id)
        {
            var sqlOperation = _mapper.GetRetrieveByIdStatement(id);
            var result = dao.ExecuteQueryProcedure(sqlOperation); 
            if (result.Count > 0)
            {
                return _mapper.BuildObject(result[0]);
            }
            return null;
        }

        public override SubscriptionDTO Update(SubscriptionDTO subscription)
        {
            var sqlOperation = _mapper.GetUpdateStatement(subscription);
            dao.ExecuteProcedure(sqlOperation);
            return subscription;
        }
    }
}
