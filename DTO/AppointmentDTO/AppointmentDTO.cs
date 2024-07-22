namespace DTOs
{
    public class AppointmentDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int UserAId { get; set; }
        public int UserBId { get; set; }
        public string UserAName { get; set; }
        public string UserBName { get; set; }
    }
}
