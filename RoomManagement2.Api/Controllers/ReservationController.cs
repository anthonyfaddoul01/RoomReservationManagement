using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RoomManagement2.Api.Resources;
using RoomManagement2.Api.Validators;
using RoomManagement2.Core.Models;
using RoomManagement2.Core.Services;
using RoomManagement2.Services;


namespace RoomManagement2.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ReservationController : ControllerBase
    {
        private readonly IReserveService _reserveService;
        private readonly IUserService _userService;
        private readonly IRoomService _roomService;
        private readonly IMapper _mapper;

        public ReservationController(IReserveService reserveService, IUserService userService, IRoomService roomService, IMapper mapper)
        {
            this._mapper = mapper;
            this._reserveService = reserveService;
            this._userService = userService;
            this._roomService = roomService;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<Reservation>>> GetAllReservations()
        {
            var reservations = await _reserveService.GetAllReservationsWithUserAndRoom();
            var reservationResources = _mapper.Map<IEnumerable<Reservation>, IEnumerable<ReserveResource>>(reservations);

            return Ok(reservationResources);
        }

        [HttpGet("{roomId}/{userId}")]
        public async Task<ActionResult<Reservation>> GetReservationById(int Id)
        {
            var reservation = await _reserveService.GetReservationById(Id);
            if (reservation == null)
                return NotFound();

            var reservationResource = _mapper.Map<Reservation, ReserveResource>(reservation);

            return Ok(reservationResource);
        }

        //[HttpGet("{reservationId}/{reservationDate}")]
        //public async Task<ActionResult<Reservation>> GetReservationByIdAndDate(int reservationId, DateTime reservationDate)
        //{
        //    var reservation = await _reserveService.GetReservationByReservationIdAndDate(reservationId, reservationDate);

        //    if (reservation == null)
        //        return NotFound();

        //    var reservationResource = _mapper.Map<Reservation, ReserveResource>(reservation);

        //    return Ok(reservationResource);
        //}

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<Reservation>> GetReservationByUserId(int userId)
        {
            var reservations = await _reserveService.GetReservationsByUserId(userId);

            if (reservations == null)
                return NotFound();

            var reservationResources = _mapper.Map<IEnumerable<Reservation>, IEnumerable<ReserveResource>>(reservations);

            return Ok(reservationResources);
        }

        [HttpGet("room/{roomId}")]
        public async Task<ActionResult<Reservation>> GetReservationByRoomId(int roomId)
        {
            var reservations = await _reserveService.GetReservationsByRoomId(roomId);

            if (reservations == null)
                return NotFound();

            var reservationResources = _mapper.Map<IEnumerable<Reservation>, IEnumerable<ReserveResource>>(reservations);

            return Ok(reservationResources);
        }

        [HttpPost("")]
        public async Task<ActionResult<Reservation>> CreateReservation([FromBody] SaveReserveResource saveReservationResource)
        {
            var validator = new SaveReserveResourceValidator(_reserveService, _userService, _roomService);
            var validationResult = await validator.ValidateAsync(saveReservationResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var reservationToCreate = _mapper.Map<SaveReserveResource, Reservation>(saveReservationResource);

            var newReservation = await _reserveService.CreateReservation(reservationToCreate);

            var reservation = await _reserveService.GetReservationById(newReservation.Id);

            var reservationResource = _mapper.Map<Reservation, ReserveResource>(reservation);

            return Ok(reservationResource);
        }

        [HttpPut("{reservationId}/{reservationDate}")]
        public async Task<ActionResult<Reservation>> UpdateReservation(int reservationId, DateTime reservationDate, [FromBody] SaveReserveResource saveReservationResource)
        {
            var validator = new SaveReserveResourceValidator(_reserveService, _userService, _roomService);
            var validationResult = await validator.ValidateAsync(saveReservationResource);

            var requestIsInvalid = reservationId == 0 || !validationResult.IsValid;

            if (requestIsInvalid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var reservationToBeUpdate = await _reserveService.GetReservationByReservationIdAndDate(reservationId, reservationDate);

            if (reservationToBeUpdate == null)
                return NotFound();

            var reservation = _mapper.Map<SaveReserveResource, Reservation>(saveReservationResource);

            await _reserveService.UpdateReservation(reservationToBeUpdate, reservation);

            var updatedReservation = await _reserveService.GetReservationByReservationIdAndDate(reservationId, reservationDate);
            var updatedReservationResource = _mapper.Map<Reservation, ReserveResource>(updatedReservation);

            return Ok(updatedReservationResource);
        }

        [HttpDelete("{reservationId}")]
        public async Task<IActionResult> DeleteReservation(int reservationId)
        {
            if (reservationId == 0)
                return BadRequest();

            var reservation = await _reserveService.GetReservationById(reservationId);

            if (reservation == null)
                return NotFound();

            await _reserveService.DeleteReservation(reservation);

            return NoContent();
        }
    }
}
