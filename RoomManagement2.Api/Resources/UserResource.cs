namespace RoomManagement2.Api.Resources
{
    public class UserResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public CompanyResource Company { get; set; }
        
    }
}
