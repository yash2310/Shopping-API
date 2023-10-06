namespace Shopping.Shared
{
    public class TokenDTO
    {
        public string Token { get; set; } = string.Empty;
        public UserDTO User { get; set; } = new UserDTO();
    }
}
