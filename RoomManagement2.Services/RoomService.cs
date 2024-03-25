using Microsoft.EntityFrameworkCore;
using RoomManagement2.Core;
using RoomManagement2.Core.Models;
using RoomManagement2.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomManagement2.Services
{
    public class RoomService : IRoomService
    {
        private readonly IUnitOfWork _unitOfWork;
        public RoomService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Room> CreateRoom(Room newRoom)
        {
            await _unitOfWork.Rooms.AddAsync(newRoom);
            await _unitOfWork.CommitAsync();
            return newRoom;
        }

        public async Task DeleteRoom(Room room)
        {
            _unitOfWork.Rooms.Remove(room);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Room>> GetAllWithCompany()
        {
            return await _unitOfWork.Rooms
                .GetAllWithCompanyAsync();
        }

        public async Task<Room> GetRoomById(int id)
        {
            return await _unitOfWork.Rooms
                .GetWithCompanyByIdAsync(id);
        }

        public async Task<int> GetRoomIdByNameAsync(string roomName)
        {
            var room = await _unitOfWork.Rooms.SingleOrDefaultAsync(r => r.Name == roomName);
            return room?.Id ?? 0;
        }
        async Task<IEnumerable<Room>> GetRoomsByCompanyId(int companyId)
        {
            return await _unitOfWork.Rooms
                .GetAllWithRoomByCompanyIdAsync(companyId);
        }

        public async Task UpdateRoom(Room roomToBeUpdated, Room room)
        {
            roomToBeUpdated.Name = room.Name;
            roomToBeUpdated.Capacity = room.Capacity;
            roomToBeUpdated.Location = room.Location;
            roomToBeUpdated.Description = room.Description;
            roomToBeUpdated.CompanyId = room.CompanyId;

            await _unitOfWork.CommitAsync();
        }

        Task<IEnumerable<Room>> IRoomService.GetRoomsByCompanyId(int companyId)
        {
            throw new NotImplementedException();
        }
    }
}
