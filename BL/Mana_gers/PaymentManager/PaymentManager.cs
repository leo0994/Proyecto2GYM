using DTOs;
using DAO.Crud;
using System.Collections.Generic;

namespace BL.Mana_gers
{
    public class PaymentManager
    {
        private readonly PaymentCrudFactory _crudFactory;

        public PaymentManager()
        {
            _crudFactory = new PaymentCrudFactory();
        }

        public void Create(PaymentDTO payment)
        {
            _crudFactory.Create(payment);
        }

        public void Update(PaymentDTO payment)
        {
            _crudFactory.Update(payment);
        }

        public void Delete(int id)
        {
            var payment = new PaymentDTO { Id = id };
            _crudFactory.Delete(payment);
        }

        public PaymentDTO RetrieveById(int id)
        {
            return _crudFactory.Retrieve<PaymentDTO>(id);
        }

        public List<PaymentDTO> RetrieveAll()
        {
            return _crudFactory.RetrieveAll<PaymentDTO>();
        }
    }
}
