using DAO.Crud;
using DTOs;

namespace BL.Managers
{
    public class SubscriptionManager
    {
        private readonly SubscriptionCrudFactory _crudFactory;

        public SubscriptionManager()
        {
            _crudFactory = new SubscriptionCrudFactory();
        }

        public List<SubscriptionDTO> RetrieveAll()
        {
            return _crudFactory.RetrieveAll();
        }
    }
}