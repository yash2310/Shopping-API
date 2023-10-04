namespace Shopping.Entity
{
    public class CommonEntity
    {
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public string UpdatedBy { get; set; } = string.Empty;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
    }
}
