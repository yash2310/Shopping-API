using Microsoft.EntityFrameworkCore;

namespace Shopping.User.Data
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Entity.UserEntity> Users { get; set; }
        public DbSet<Entity.UserAddressEntity> UserAddress { get; set; }
    }
}
