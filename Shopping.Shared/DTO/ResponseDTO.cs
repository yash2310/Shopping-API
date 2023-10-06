namespace Shopping.Shared
{
    public class ResponseDTO
    {
        public string ErrorMessage { get; set; } = string.Empty;
        public bool IsSuccess { get; set; }
        public object Data { get; set; } = new object();
    }
}
