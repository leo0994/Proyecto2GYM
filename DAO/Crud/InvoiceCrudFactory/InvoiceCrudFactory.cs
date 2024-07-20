using DTOs;
using DAO.Mapper;
using System.Collections.Generic;

namespace DAO.Crud
{
    public class InvoiceCrudFactory : CrudFactory<InvoiceDTO>
    {
        private readonly InvoiceMapper _mapper;

        public InvoiceCrudFactory()
        {
            dao = SqlDAO.GetInstance();
            _mapper = new InvoiceMapper();
        }

        public override InvoiceDTO Create(InvoiceDTO invoice)
        {
            var sqlOperation = _mapper.GetCreateStatement(invoice);
            dao.ExecuteProcedure(sqlOperation);
            return invoice;
        }

        public override InvoiceDTO Delete(InvoiceDTO invoice)
        {
            var sqlOperation = _mapper.GetDeleteStatement(invoice.Id);
            dao.ExecuteProcedure(sqlOperation);
            return invoice;
        }

        public override List<InvoiceDTO> RetrieveAll()
        {
            var sqlOperation = _mapper.GetRetrieveAllStatement();
            var result = dao.ExecuteQueryProcedure(sqlOperation);
            return _mapper.BuildObjects(result);
        }

        public override InvoiceDTO RetrieveById(int id)
        {
            var sqlOperation = _mapper.GetRetrieveByIdStatement(id);
            var result = dao.ExecuteQueryProcedure(sqlOperation);
            if (result.Count > 0)
            {
                return _mapper.BuildObject(result[0]);
            }
            return null;
        }

        public override InvoiceDTO Update(InvoiceDTO invoice)
        {
            var sqlOperation = _mapper.GetUpdateStatement(invoice);
            dao.ExecuteProcedure(sqlOperation);
            return invoice;
        }
    }
}
