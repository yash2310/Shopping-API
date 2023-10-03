using Shopping.Shared;

namespace Shopping.Entity
{
    public class UserAddressEntity : BaseEntity
    {
        public AddressType AddressType { get; set; }
        public string HouseNumber { get; set; } = string.Empty;
        public string Locality { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public UserEntity User { get; set; } = new UserEntity();
    }
}
