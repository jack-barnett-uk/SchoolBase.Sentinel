namespace SchoolBase.Sentinel.Models
{
    public class EventDetails
    {
        public int EventId { get; set; }
        public string EventName { get; set; }
        public string Details { get; set; }
        public string Note { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string EventType { get; set; }
        public string Owner { get; set; }
        public string Leader { get; set; }
        public string Venue { get; set; }
        public int EventTypeId { get; set; }
        public int OwnerId { get; set; }
        public int LeaderId { get; set; }
        public string OwnerTitle { get; set; }
        public string OwnerFirstName { get; set; }
        public string OwnerLastName { get; set; }
        public string LeaderTitle { get; set; }
        public string LeaderFirstName { get; set; }
        public string LeaderLastName { get; set; }
    }
}
