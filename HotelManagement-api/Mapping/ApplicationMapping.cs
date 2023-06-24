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
            CreateMap<UserDto, User>();
            CreateMap<PriceDto, Price>();
            CreateMap<Price, PriceDto>();
            CreateMap<PutUnitDto, AccommodationUnit>();
            CreateMap<AccommodationUnit, PutUnitDto>();
            CreateMap<ServiceDto, Service>();   
            CreateMap<Service, ServiceDto>();
        }
    }
}
