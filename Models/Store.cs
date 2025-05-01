namespace hive_admin_web.Models
{
    public class Store
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string AccessToken { get; set; }
        public long WorkspaceId { get; set; }
        public long DaysToPayout { get; set; }
        public decimal PayoutPercentage { get; set; }
        public string TrackingUrl { get; set; }
    }
}
