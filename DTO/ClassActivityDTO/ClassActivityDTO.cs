using Microsoft.AspNetCore.Http;
namespace DTOs
{
    public class ClassActivityRequest
    {
        public int? Id { get; set; } = 0; // Optional, default to 0
        public string Name { get; set; } // Required
        public string Description { get; set; } // Required
        public int Capacity { get; set; }
        public int Coach { get; set; }
        public string Day { get; set; } // Required
        public TimeSpan Hour { get; set; } // Required
        public IFormFile? Image { get; set; }
        public String? Image_url { get; set; }

    }

    public class ClassActivityDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public String Image_url { get; set; }
        public int Instructor { get; set; }
        public string? NameInstructor { get; set; }
        public string DayOfWeek { get; set; } // Day of the week, e.g., "Monday", "Tuesday"
        public TimeSpan Hour { get; set; } // Required
        public int? Capacity { get; set; }
    }
}
