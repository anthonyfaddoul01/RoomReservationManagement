namespace RoomManagement2.Api.Resources
{
    public class SaveRoomResource
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int Capacity { get; set; }
        public int CompanyId { get; set; }

    }
}
