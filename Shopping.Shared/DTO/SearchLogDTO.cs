namespace Shopping.Shared
{
    public class SearchLogDTO: LogDTO
    {
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
    }
}
