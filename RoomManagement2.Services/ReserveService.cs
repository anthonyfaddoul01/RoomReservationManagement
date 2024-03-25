using Microsoft.EntityFrameworkCore;
using RoomManagement2.Core;
using RoomManagement2.Core.Models;
using RoomManagement2.Core.Repositories;
using RoomManagement2.Core.Services;
using System.Linq;
using RoomManagement2.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RoomManagement2.Services
{
    public class ReserveService : IReserveService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IReserveRepository _reserveRepository;
        private readonly IRoomRepository _roomRepository;

        public ReserveService(IUnitOfWork unitOfWork, IReserveRepository reserveRepository)
        {
            _unitOfWork = unitOfWork;
            _reserveRepository = reserveRepository;
        }

        public async Task<Reservation> CreateReservation(Reservation newReservation)
        {
            await _unitOfWork.Reservations.AddAsync(newReservation);
            await _unitOfWork.CommitAsync();
            return newReservation;
        }

        public async Task DeleteReservation(Reservation reservation)
        {
            _unitOfWork.Reservations.Remove(reservation);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Reservation>> GetAllReservationsWithUserAndRoom()
        {
            return await _unitOfWork.Reservations
                .GetAllWithReservationAsync();
        }

        public async Task<Reservation> GetReservationById(int Id)
        {
            return await _unitOfWork.Reservations
                .GetWithReservationByIdAsync(Id);
        }

        public async Task<Reservation> GetWithReservationByIdAsync(int roomId, int userId)
        {
            return await _unitOfWork.Reservations
                .SingleOrDefaultAsync(r => r.RoomId == roomId && r.UserId == userId);
        }

        public async Task<IEnumerable<Reservation>> GetReservationsByUserId(int userId)
        {
            return await _unitOfWork.Reservations
                .GetAllWithUserByUserIdAsync(userId);
        }

        public async Task<IEnumerable<Reservation>> GetReservationsByRoomId(int roomId)
        {
            return await _unitOfWork.Reservations
                .GetAllWithRoomByRoomIdAsync(roomId);
        }

        public async Task UpdateReservation(Reservation reservationToBeUpdated, Reservation reservation)
        {
            reservationToBeUpdated.MeetingDate = reservation.MeetingDate;
            reservationToBeUpdated.StartTime = reservation.StartTime;
            reservationToBeUpdated.EndTime = reservation.EndTime;
            reservationToBeUpdated.NumberOfAttendees = reservation.NumberOfAttendees;
            reservationToBeUpdated.MeetingStatus = reservation.MeetingStatus;

            await _unitOfWork.CommitAsync();
        }

        public async Task<Reservation> GetReservationByReservationIdAndDate(int reservationId, DateTime reservationDate)
        {
            return await _unitOfWork.Reservations
                .GetReservationByReservationIdAndDateAsync(reservationId, reservationDate);
        }
    }
}

