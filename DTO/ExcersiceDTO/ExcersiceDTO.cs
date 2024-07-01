namespace DTOs
{
    public class ExerciseDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int? MachineId { get; set; }
        public int ExerciseBaseId { get; set; }
        public int RoutineId { get; set; }
    }
}
