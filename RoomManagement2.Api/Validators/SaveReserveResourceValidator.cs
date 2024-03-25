using FluentValidation;
using RoomManagement2.Api.Resources;
using RoomManagement2.Core.Services;
using RoomManagement2.Services;

namespace RoomManagement2.Api.Validators
{
    public class SaveReserveResourceValidator : AbstractValidator<SaveReserveResource>
    {
        private readonly IReserveService _reserveService;
        private readonly IUserService _userService;
        private readonly IRoomService _roomService;

        public SaveReserveResourceValidator(IReserveService reserveService, IUserService userService, IRoomService roomService)
        {
            _reserveService = reserveService;
            _userService = userService;
            _roomService = roomService;

            RuleFor(m => m.MeetingDate)
                .NotEmpty()
                .Must(BeAValidDate)
                .WithMessage("Please provide a valid Meeting Date.");

            RuleFor(m => m.StartTime)
                .NotEmpty()
                .Must(BeAValidTime)
                .WithMessage("Please provide a valid Start Time.");

            RuleFor(m => m.EndTime)
                .NotEmpty()
                .Must(BeAValidTime)
                .WithMessage("Please provide a valid End Time.")
                .GreaterThan(m => m.StartTime)
                .WithMessage("End Time must be greater than Start Time.");

            RuleFor(m => m.UserId)
                .NotEmpty()
                .MustAsync((userId, cancellationToken) => UserExists(userId))
                .WithMessage("User with the provided ID does not exist.");

            RuleFor(m => m.RoomId)
                .NotEmpty()
                .MustAsync((roomId, cancellationToken) => RoomExists(roomId))
                .WithMessage("Room with the provided ID does not exist.");

            RuleFor(m => new { m.MeetingDate, m.StartTime, m.EndTime, m.RoomId })
                .MustAsync((resource, cancellationToken) => BeRoomAvailable(resource.MeetingDate, resource.StartTime, resource.EndTime, resource.RoomId))
                .WithMessage("The room is already booked at this time.");
        }

        private async Task<bool> BeRoomAvailable(DateTime meetingDate, TimeSpan startTime, TimeSpan endTime, int roomId)
        {
            var existingReservations = await _reserveService.GetReservationsByRoomId(roomId);

            foreach (var reservation in existingReservations)
            {
                if (meetingDate == reservation.MeetingDate &&
                    startTime < reservation.EndTime &&
                    endTime > reservation.StartTime)
                {
                    return false; // Room is already booked at this time by another user
                }
            }

            return true; // Room is available
        }

        private bool BeAValidDate(DateTime date)
        {
            return date != default(DateTime) && date >= DateTime.Today;
        }

        private bool BeAValidTime(TimeSpan time)
        {
            TimeSpan startTime = new TimeSpan(8, 0, 0); // 8:00 AM
            TimeSpan endTime = new TimeSpan(18, 0, 0);  // 6:00 PM

            return time >= startTime && time <= endTime;
        }

        private async Task<bool> UserExists(int userId)
        {
            var user = await _userService.GetUserById(userId);
            return user != null;
        }

        private async Task<bool> RoomExists(int roomId)
        {
            var room = await _roomService.GetRoomById(roomId);
            return room != null;
        }

        //private async Task<bool> BeRoomAvailable(SaveReserveResource resource)
        //{
        //    var existingReservations = await _reserveService.GetReservationsByRoomId(resource.RoomId);

        //    foreach (var reservation in existingReservations)
        //    {
        //        if (resource.MeetingDate == reservation.MeetingDate &&
        //            resource.StartTime < reservation.EndTime &&
        //            resource.EndTime > reservation.StartTime)
        //        {
        //            return false; // Room is already booked at this time
        //        }
        //    }

        //    return true; // Room is available
        //}

    }
}
