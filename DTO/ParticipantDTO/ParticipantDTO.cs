namespace DTOs
{
    public class ParticipantDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ClassActivityId { get; set; }
        public string? UserName { get; set; } // Optional, for displaying user name
        public string? ClassActivityName { get; set; } // Optional, for displaying class activity name
        public DateTime RegistrationDate { get; set; }
    }
}
