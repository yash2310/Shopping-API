using Newtonsoft.Json;
using Shopping.Shared.DTO;
using Shopping.Shared.Enum;
using System.Net.Http.Headers;

namespace Shopping.Shared.Utility
{
    public static class LoggingUtility
    {
        public static string CorrelationId { get; set; } = string.Empty;
        public static string Service { get; set; } = string.Empty;
        public static string Username { get; set; } = string.Empty;

        public static void AddLog(LogType logType, string message, string token)
        {
            var log = new LogDTO()
            {
                CorrelationId = CorrelationId,
                ServicePath = Service,
                LogType = logType,
                Message = message,
                Username = Username
            };

            var client = new HttpClient();
            client.BaseAddress = new Uri("");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //client.PostAsync("", new JsonConvert().SerializeObject(log))
        }
    }
}
