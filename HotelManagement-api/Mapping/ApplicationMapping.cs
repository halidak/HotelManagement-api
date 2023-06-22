using AutoMapper;
using HotelManagement.Data.Models;
using HotelManagement_api.DTOs;
using HotelManagement_api.Mediator.AccommodationUnits;
using HotelManagement_data.Models;

namespace HotelManagement_api.Mapping
{
    public class ApplicationMapping : Profile
    {
        public ApplicationMapping()
        {
            CreateMap<RegisterDto, User>();
            CreateMap<AccommodationUnit, UnitDto>();
            CreateMap<UnitDto, AccommodationUnit>();
        }
    }
}
