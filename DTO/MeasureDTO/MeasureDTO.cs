namespace DTOs
{
    public class MeasureDTO
    {
        public int Id { get; set; }
        public decimal Weight { get; set; }
        public decimal Height { get; set; }
        public decimal BodyFat { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
    }
}
