using Microsoft.EntityFrameworkCore;
using RoomManagement2.Core.Models;
using RoomManagement2.Core.Models.Auth;
using RoomManagement2.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomManagement2.Data.Repositories
{
    public class ReserveRepository : Repository<Reservation>, IReserveRepository
    {
        public ReserveRepository(RoomManagement2DbContext context)
            : base(context)
        { }

        public async Task<IEnumerable<Reservation>> GetAllWithReservationAsync()
        {
            return await RoomManagement2DbContext.Reservations
                .Include(m => m.User)
                .Include(m => m.Room)
                .ToListAsync();
        }

        public async Task<Reservation> GetWithReservationByIdAsync(int roomId, int userId)
        {
            return await RoomManagement2DbContext.Reservations
                .Include(m => m.User)
                .Include(m => m.Room)
                .SingleOrDefaultAsync(r => r.RoomId == roomId && r.UserId == userId);
        }

        public async Task<IEnumerable<Reservation>> GetAllWithUserByUserIdAsync(int userId)
        {
            return await RoomManagement2DbContext.Reservations
                .Include(m => m.User)
                .Include(m => m.Room)
                .Where(r => r.UserId == userId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Reservation>> GetAllWithRoomByRoomIdAsync(int roomId)
        {
            return await RoomManagement2DbContext.Reservations
                .Include(m => m.User)
                .Include(m => m.Room)
                .Where(r => r.RoomId == roomId)
                .ToListAsync();
        }

        public async Task<Reservation> GetWithReservationByIdAsync(int Id)
        {
            return await RoomManagement2DbContext.Reservations
                .Include(m => m.User)
                .Include(m => m.Room)
                .SingleOrDefaultAsync(r => r.Id == Id);
        }
        public async Task<Reservation> GetReservationByReservationIdAndDateAsync(int reservationId, DateTime reservationDate)
        {
            var reservation = await RoomManagement2DbContext.Reservations
                .Include(m => m.User)
                .Include(m => m.Room)
                .FirstOrDefaultAsync(r => r.Id == reservationId && r.MeetingDate == reservationDate);

            return reservation;
        }

        private RoomManagement2DbContext RoomManagement2DbContext
        {
            get { return Context as RoomManagement2DbContext; }
        }
    }
}
