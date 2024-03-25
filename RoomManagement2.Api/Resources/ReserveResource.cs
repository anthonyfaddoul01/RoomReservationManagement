namespace RoomManagement2.Api.Resources
{
    public class ReserveResource
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public virtual UserResource User { get; set; }
        public int RoomId { get; set; }
        public virtual RoomResource Room { get; set; }
        public DateTime MeetingDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }


    }
}
