using AutoMapper;
using RoomManagement2.Api.Resources;
using RoomManagement2.Core.Models;
using RoomManagement2.Core.Models.Auth;

namespace RoomManagement2.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Resource
            CreateMap<User, UserResource>();
            CreateMap<Company, CompanyResource>();
            CreateMap<Room, RoomResource>();
            CreateMap<Reservation, ReserveResource>();

            // Resource to Domain
            CreateMap<UserResource, User>();
            CreateMap<CompanyResource, Company>();
            CreateMap<RoomResource, Room>();
            CreateMap<ReserveResource, Reservation>();

            CreateMap<SaveUserResource, User>();
            CreateMap<SaveCompanyResource, Company>();
            CreateMap<SaveRoomResource, Room>();
            CreateMap<SaveReserveResource, Reservation>();

            CreateMap<UserXSignUpResource, UserX>()
                .ForMember(u => u.UserName, opt => opt.MapFrom(ur => ur.Email));
        }
    }
}
