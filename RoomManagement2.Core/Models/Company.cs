using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomManagement2.Core.Models
{
    public class Company
    {
        public Company()
        {
            Users = new Collection<User>();
            Rooms = new Collection<Room>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<Room> Rooms { get; set; }
    }
}
