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

        public InvoiceDTO Create(InvoiceDTO invoice)
        {
            return _crudFactory.Create(invoice);
        }

        public InvoiceDTO Update(InvoiceDTO invoice)
        {
            return _crudFactory.Update(invoice);
        }

        public InvoiceDTO Delete(InvoiceDTO invoice)
        {
            return _crudFactory.Delete(invoice);
        }

        public List<InvoiceDTO> RetrieveAll()
        {
            return _crudFactory.RetrieveAll();
        }

        public InvoiceDTO RetrieveById(int id)
        {
            return _crudFactory.RetrieveById(id);
        }
    }
}
