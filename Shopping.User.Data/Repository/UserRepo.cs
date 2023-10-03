using Shopping.Shared;

namespace Shopping.User.Data
{
    public class UserRepo : Repository<Entity.UserEntity>, IUserRepo
    {
        public UserRepo(UserDbContext dbContext) : base(dbContext) { }
    }
}
