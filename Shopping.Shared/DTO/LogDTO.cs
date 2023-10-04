using Shopping.Shared.Enum;

namespace Shopping.Shared.DTO
{
    public class LogDTO
    {
        public string CorrelationId { get; set; } = string.Empty;
        public string ServicePath { get; set; } = string.Empty;
        public LogType LogType { get; set; }
        public string Message { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
    }
}
