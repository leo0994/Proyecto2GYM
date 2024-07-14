
using System;

namespace DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int TypeUserId { get; set; }
        public string Number { get; set; }
        public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
