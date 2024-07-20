using System.Security.Cryptography;

namespace DTOs
{
    public class ExerciseDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int? Reps { get; set; }
        public float? Weight { get; set; }
        public int? Time { get; set; }
        public int? MachineId { get; set; }
        public int ExerciseBaseId { get; set; }
    }
}
