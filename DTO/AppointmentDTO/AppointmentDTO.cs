namespace DTOs
{
    public class AppointmentDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int UserAId { get; set; }
        public int UserBId { get; set; }
    }
}
