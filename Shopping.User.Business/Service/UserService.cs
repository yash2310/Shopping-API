using Shopping.Shared;
using Shopping.User.Data;

namespace Shopping.User.Business.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepo userRepo;

        public UserService(IUserRepo userRepo)
        {
            this.userRepo = userRepo;
        }

        public List<UserDTO> GetAll()
        {
            var userData = new List<UserDTO>();

            var users = userRepo.GetAll();
            foreach (var user in users)
            {
                userData.Add(new UserDTO()
                {
                    Id = user.Id,
                    Name = user.Name,
                    EmailId = user.EmailId,
                    Gender = user.Gender,
                    Age = user.Age,
                });
            }

            return userData;
        }

        public UserDTO GetUser(int id)
        {
            var user = userRepo.GetById(id);

            return new UserDTO
            {
                Id = user.Id,
                Name = user.Name,
                EmailId = user.EmailId,
                Gender = user.Gender,
                Age = user.Age
            };
        }

        public bool AddUser(RegisterDTO register)
        {
            try
            {
                if (userRepo.Any(u => u.EmailId == register.EmailId))
                {
                    return false;
                }
                else
                {
                    userRepo.Add(new Entity.UserEntity
                    {
                        Name = register.Name,
                        EmailId = register.EmailId,
                        Gender = register.Gender,
                        Age = register.Age,
                        Password = register.Password
                    });
                    userRepo.Save();

                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteUser(int id)
        {
            try
            {
                var data = userRepo.GetById(id);

                if (data != null)
                {
                    userRepo.Delete(data);
                    userRepo.Save();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateUser(UserDTO user)
        {
            try
            {
                var data = userRepo.GetById(user.Id);
                data.Age = user.Age;
                data.Gender = user.Gender;
                userRepo.Update(data);
                userRepo.Save();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public UserDTO ValidateUser(LoginDTO login)
        {
            var data = userRepo.Where(u => u.EmailId == login.Username && u.Password == login.Password).FirstOrDefault();

            if (data != null)
            {
                return new UserDTO
                {
                    Id = data.Id,
                    Age = data.Age,
                    EmailId = data.EmailId,
                    Gender = data.Gender,
                    Name = data.Name,
                    Role = data.Role
                };
            }
            else
            {
                return null;
            }
        }

        public string GenerateToken(UserDTO user)
        {
            return "";
        }
    }
}
