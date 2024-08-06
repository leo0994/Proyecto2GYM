using DTOs;
using DAO.Crud;
using System.Collections.Generic;

namespace BL.Managers
{
    public class PaymentManager
    {
        private readonly PaymentCrudFactory _crudFactory;

        public PaymentManager()
        {
            _crudFactory = new PaymentCrudFactory();
        }

        public string Create(PaymentDTO payment) // Modificado por maria se ingreso una nueva funcion
        {
            return _crudFactory.CreatePaymentReturnID(payment); // se cambio create por create CreatePaymentReturnID
        }
 

        public PaymentDTO Update(PaymentDTO payment)
        {
            return _crudFactory.Update(payment);
        }

        public PaymentDTO Delete(PaymentDTO payment)
        {
            return _crudFactory.Delete(payment);
        }

        public List<PaymentDTO> RetrieveAll()
        {
            return _crudFactory.RetrieveAll();
        }

        public PaymentDTO RetrieveById(int id)
        {
            return _crudFactory.RetrieveById(id);
        }
    }
}
