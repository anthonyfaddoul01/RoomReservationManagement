using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomManagement2.Core.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Location { get; set; }
        public int Capacity { get; set; }
        public string? Description { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
