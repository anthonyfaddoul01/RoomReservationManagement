using RoomManagement2.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomManagement2.Core.Repositories
{
    public interface IRoomRepository : IRepository<Room>
    {
        //Task<IEnumerable<Room>> GetAllWithCompanyAsync();
        Task<Room> GetWithCompanyByIdAsync(int id);
        Task<IEnumerable<Room>> GetAllWithRoomByCompanyIdAsync(int companyId);
        Task<IEnumerable<Room>> GetRoomsByRoomNameAsync(string roomName);
        Task<IEnumerable<Room>> GetAllWithCompanyAsync();
    }
}
