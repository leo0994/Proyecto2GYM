using DTOs;
using System.Collections.Generic;

namespace DAO.Mapper
{
    public class InvoiceMapper : ISqlStatements, IObjectMapper
    {
        public InvoiceDTO BuildObject(Dictionary<string, object> row)
        {
            var invoiceDTO = new InvoiceDTO
            {
                Id = (int)row["id"],
                PaymentId = (int)row["paymentId"],
                PdfFormat = (string)row["pdfFormat"],
                XmlFormat = (string)row["xmlFormat"]
            };

            return invoiceDTO;
        }

        public List<InvoiceDTO> BuildObjects(List<Dictionary<string, object>> rowsList)
        {
            var resultsList = new List<InvoiceDTO>();
            foreach (var row in rowsList)
            {
                var invoiceDTO = BuildObject(row);
                resultsList.Add(invoiceDTO);
            }
            return resultsList;
        }

        public SqlOperation GetCreateStatement(InvoiceDTO invoice)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "CreateInvoice" };

            sqlOperation.AddIntParam("@p_paymentId", invoice.PaymentId);
            sqlOperation.AddVarcharParam("@p_pdfFormat", invoice.PdfFormat);
            sqlOperation.AddVarcharParam("@p_xmlFormat", invoice.XmlFormat);

            return sqlOperation;
        }

        public SqlOperation GetDeleteStatement(int id)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "DeleteInvoice" };
            sqlOperation.AddIntParam("@p_id", id);
            return sqlOperation;
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            return new SqlOperation { ProcedureName = "GetAllInvoices" };
        }

        public SqlOperation GetRetrieveByIdStatement(int id)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "GetInvoiceById" };
            sqlOperation.AddIntParam("@p_id", id);
            return sqlOperation;
        }

        public SqlOperation GetUpdateStatement(InvoiceDTO invoice)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "UpdateInvoice" };

            sqlOperation.AddIntParam("@p_id", invoice.Id);
            sqlOperation.AddIntParam("@p_paymentId", invoice.PaymentId);
            sqlOperation.AddVarcharParam("@p_pdfFormat", invoice.PdfFormat);
            sqlOperation.AddVarcharParam("@p_xmlFormat", invoice.XmlFormat);

            return sqlOperation;
        }
    }
}
