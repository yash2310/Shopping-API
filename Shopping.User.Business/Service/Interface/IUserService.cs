using Shopping.Shared;

namespace Shopping.User.Business
{
    public interface IUserService
    {
        UserDTO GetUser(int id);
        List<UserDTO> GetAll();
        bool AddUser(RegisterDTO register);
        bool UpdateUser(UserDTO user);
        bool DeleteUser(int id);
        UserDTO ValidateUser(LoginDTO login);
        string GenerateToken(UserDTO user);
    }
}
