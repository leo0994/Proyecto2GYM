namespace DTO.User
{
    public class UserEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int UserType { get; set; }
        public int Phone { get; set; }
        public DateTime Born { get; set; }

        public UserEntity() { }

        public UserEntity(long id, string name, string email, string password, int userType, int Phone, DateTime born)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
            UserType = userType;
            Phone = Phone;
            Born = born;
        }

    }
}