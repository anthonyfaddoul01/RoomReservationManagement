namespace RoomManagement2.Api.Resources
{
    public class SaveUserResource
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public string Role { get; set; }
        public int CompanyId { get; set; }
    }
}
