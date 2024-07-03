using DTOs;
using DAO.Crud;
using System.Collections.Generic;

namespace BL.Managers
{
    public class InvoiceManager
    {
        private readonly InvoiceCrudFactory _crudFactory;

        public InvoiceManager()
        {
            _crudFactory = new InvoiceCrudFactory();
        }

        public void Create(InvoiceDTO invoice)
        {
            _crudFactory.Create(invoice);
        }

        public void Update(InvoiceDTO invoice)
        {
            _crudFactory.Update(invoice);
        }

        public void Delete(int id)
        {
            var invoice = new InvoiceDTO { Id = id };
            _crudFactory.Delete(invoice);
        }

        public InvoiceDTO RetrieveById(int id)
        {
            return _crudFactory.Retrieve<InvoiceDTO>(id);
        }

        public List<InvoiceDTO> RetrieveAll()
        {
            return _crudFactory.RetrieveAll<InvoiceDTO>();
        }
    }
}
