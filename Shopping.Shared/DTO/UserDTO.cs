namespace Shopping.Shared
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string EmailId { get; set; } = string.Empty;
        public Gender Gender { get; set; }
        public int Age { get; set; }
        public UserRole Role { get; set; }
    }
}
