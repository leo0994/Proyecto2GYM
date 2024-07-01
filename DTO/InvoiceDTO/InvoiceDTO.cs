namespace DTOs
{
    public class InvoiceDTO
    {
        public int Id { get; set; }
        public int PaymentId { get; set; }
        public string PdfFormat { get; set; }
        public string XmlFormat { get; set; }
    }
}
