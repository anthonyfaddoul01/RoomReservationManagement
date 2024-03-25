using RoomManagement2.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomManagement2.Core.Repositories
{
    public interface IReserveRepository : IRepository<Reservation>
    {
        Task<IEnumerable<Reservation>> GetAllWithReservationAsync();
        Task<Reservation> GetWithReservationByIdAsync(int Id);
        Task<IEnumerable<Reservation>> GetAllWithUserByUserIdAsync(int userId);
        Task<IEnumerable<Reservation>> GetAllWithRoomByRoomIdAsync(int roomId);
        Task<Reservation> GetReservationByReservationIdAndDateAsync(int reservationId, DateTime reservationDate);
    }
}
