namespace RoomManagement2.Api.Resources
{
    public class RoomResource
    {
            public int Id { get; set; }
            public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int Capacity { get; set; }
        public CompanyResource Company { get; set; }
        
    }
}
