using RoomManagement2.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomManagement2.Core.Services
{
    public interface IReserveService
    {
        Task<IEnumerable<Reservation>> GetAllReservationsWithUserAndRoom();
        Task<Reservation> GetReservationById(int Id);
        Task<IEnumerable<Reservation>> GetReservationsByRoomId(int roomId);
        Task<IEnumerable<Reservation>> GetReservationsByUserId(int userId);
        Task<Reservation> CreateReservation(Reservation newReservation);
        Task UpdateReservation(Reservation reservationToBeUpdated, Reservation reservation);
        Task DeleteReservation(Reservation reservation);
        Task<Reservation> GetReservationByReservationIdAndDate(int reservationId, DateTime reservationDate);
    }
}
