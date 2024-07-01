namespace DTOs
{
    public class ParticipantDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public int InstructorId { get; set; }
        public int ClassId { get; set; }
        public int Max { get; set; }
    }
}
