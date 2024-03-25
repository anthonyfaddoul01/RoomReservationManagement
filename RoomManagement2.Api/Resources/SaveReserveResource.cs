namespace RoomManagement2.Api.Resources
{
    public class SaveReserveResource
    {
        public int UserId { get; set; }
        public int RoomId { get; set; }
        public DateTime MeetingDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

    }
}
