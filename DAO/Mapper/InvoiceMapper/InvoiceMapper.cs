using DTOs;
using System.Collections.Generic;

namespace DAO.Mapper
{
    public class InvoiceMapper : ICrudStatements<InvoiceDTO>, IObjectMapper<InvoiceDTO>
    {
        public InvoiceDTO BuildObject(Dictionary<string, object> row)
        {
            var invoice = new InvoiceDTO
            {
                Id = (int)row["id"],
                PaymentId = (int)row["payment_id"],
                PdfFormat = (string)row["PDF_format"],
                XmlFormat = (string)row["XML_format"]
            };

            return invoice;
        }

        public List<InvoiceDTO> BuildObjects(List<Dictionary<string, object>> rowsList)
        {
            var resultsList = new List<InvoiceDTO>();
            foreach (var row in rowsList)
            {
                var invoice = BuildObject(row);
                resultsList.Add(invoice);
            }
            return resultsList;
        }

        public SqlOperation GetCreateStatement(InvoiceDTO invoice)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "RecordPayment" };

            sqlOperation.AddIntParam("@p_payment_id", invoice.PaymentId);
            sqlOperation.AddVarcharParam("@p_PDF_format", invoice.PdfFormat);
            sqlOperation.AddVarcharParam("@p_XML_format", invoice.XmlFormat);

            return sqlOperation;
        }

        public SqlOperation GetDeleteStatement(int id)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "DeleteInvoice" }; // Assuming the existence of this stored procedure
            sqlOperation.AddIntParam("@p_id", id);
            return sqlOperation;
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            return new SqlOperation { ProcedureName = "GetAllInvoices" }; // Assuming the existence of this stored procedure
        }

        public SqlOperation GetRetrieveByIdStatement(int id)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "GetInvoiceByPaymentId" };
            sqlOperation.AddIntParam("@p_payment_id", id);
            return sqlOperation;
        }

        public SqlOperation GetUpdateStatement(InvoiceDTO invoice)
        {
            var sqlOperation = new SqlOperation { ProcedureName = "UpdateInvoice" }; // Assuming the existence of this stored procedure

            sqlOperation.AddIntParam("@p_id", invoice.Id);
            sqlOperation.AddIntParam("@p_payment_id", invoice.PaymentId);
            sqlOperation.AddVarcharParam("@p_PDF_format", invoice.PdfFormat);
            sqlOperation.AddVarcharParam("@p_XML_format", invoice.XmlFormat);

            return sqlOperation;
        }
    }
}
