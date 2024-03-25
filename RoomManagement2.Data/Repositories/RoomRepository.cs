using Microsoft.EntityFrameworkCore;
using RoomManagement2.Core.Models;
using RoomManagement2.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomManagement2.Data.Repositories
{
    public class RoomRepository : Repository<Room>, IRoomRepository
    {
        public RoomRepository(RoomManagement2DbContext context)
            : base(context)
        { }

        //public async Task<IEnumerable<Room>> GetAllWithCompanyAsync()
        //{
        //    return await RoomManagement2DbContext.Rooms
        //        .ToListAsync();
        //}

        public async Task<Room> GetWithRoomByIdAsync(int id)
        {
            return await RoomManagement2DbContext.Rooms
                .SingleOrDefaultAsync(r => r.Id == id);
        }
        public async Task<IEnumerable<Room>> GetAllWithCompanyAsync()
        {
            return await RoomManagement2DbContext.Rooms
                .Include(m => m.Company)
                .ToListAsync();
        }

        public async Task<IEnumerable<Room>> GetAllWithRoomByCompanyIdAsync(int companyId)
        {
            return await RoomManagement2DbContext.Rooms
                .Where(r => r.CompanyId == companyId).ToListAsync();
        }
        public async Task<IEnumerable<Room>> GetRoomsByRoomNameAsync(string roomName)
        {
            return await RoomManagement2DbContext.Rooms
                .Where(r => r.Name == roomName)
                .ToListAsync();
        }

        public async Task<Room> GetWithCompanyByIdAsync(int id)
        {
            return await RoomManagement2DbContext.Rooms
                .Include(m => m.Company)
                .SingleOrDefaultAsync(m => m.Id == id);
        }

        private RoomManagement2DbContext RoomManagement2DbContext
        {
            get { return Context as RoomManagement2DbContext; }
        }
    }
}
