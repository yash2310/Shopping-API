using Shopping.Shared;

namespace Shopping.Entity
{
    public class UserEntity : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string EmailId { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public Gender Gender { get; set; }
        public int Age { get; set; }
        public IList<UserAddressEntity> Address { get; set; } = new List<UserAddressEntity>();
        public UserRole Role { get; set; }
    }
}
