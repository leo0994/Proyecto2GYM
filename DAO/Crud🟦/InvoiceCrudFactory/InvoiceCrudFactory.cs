using DTOs;
using DAO.Mapper;
using System;
using System.Collections.Generic;

namespace DAO.Crud
{
    public class InvoiceCrudFactory : CrudFactory
    {
        private readonly InvoiceMapper _mapper;

        public InvoiceCrudFactory()
        {
            _mapper = new InvoiceMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var invoice = (InvoiceDTO)entity;
            var sqlOperation = _mapper.GetCreateStatement(invoice);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override void Update(BaseEntity entity)
        {
            var invoice = (InvoiceDTO)entity;
            var sqlOperation = _mapper.GetUpdateStatement(invoice);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override void Delete(BaseEntity entity)
        {
            var invoice = (InvoiceDTO)entity;
            var sqlOperation = _mapper.GetDeleteStatement(invoice.Id);
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

            var invoice = _mapper.BuildObject(dic);
            return (T)Convert.ChangeType(invoice, typeof(T));
        }

        public override List<T> RetrieveAll<T>()
        {
            var sqlOperation = _mapper.GetRetrieveAllStatement();
            var lstResult = dao.ExecuteQueryProcedure(sqlOperation);

            var invoices = _mapper.BuildObjects(lstResult);
            var list = new List<T>();

            foreach (var invoice in invoices)
            {
                list.Add((T)Convert.ChangeType(invoice, typeof(T)));
            }

            return list;
        }
    }
}
