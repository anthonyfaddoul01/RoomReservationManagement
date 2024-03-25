using RoomManagement2.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomManagement2.Core.Services
{
    public interface IRoomService
    {
        Task<IEnumerable<Room>> GetAllWithCompany();
        Task<Room> GetRoomById(int id);
        Task<IEnumerable<Room>> GetRoomsByCompanyId(int companyId);
        Task<Room> CreateRoom(Room newRoom);
        Task UpdateRoom(Room roomToBeUpdated, Room room);
        Task DeleteRoom(Room room);
        Task<int> GetRoomIdByNameAsync(string roomName);
    }
}
