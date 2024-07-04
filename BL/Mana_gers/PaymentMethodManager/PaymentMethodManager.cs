using DTOs;
using DAO.Crud;
using System.Collections.Generic;

namespace BL.Managers
{
    public class PaymentMethodManager
    {
        private readonly PaymentMethodCrudFactory _crudFactory;

        public PaymentMethodManager()
        {
            _crudFactory = new PaymentMethodCrudFactory();
        }

        public void Create(PaymentMethodDTO paymentMethod)
        {
            _crudFactory.Create(paymentMethod);
        }

        public void Update(PaymentMethodDTO paymentMethod)
        {
            _crudFactory.Update(paymentMethod);
        }

        public void Delete(int id)
        {
            var paymentMethod = new PaymentMethodDTO { Id = id };
            _crudFactory.Delete(paymentMethod);
        }

        public PaymentMethodDTO RetrieveById(int id)
        {
            return _crudFactory.Retrieve<PaymentMethodDTO>(id);
        }

        public List<PaymentMethodDTO> RetrieveAll()
        {
            return _crudFactory.RetrieveAll<PaymentMethodDTO>();
        }
    }
}
