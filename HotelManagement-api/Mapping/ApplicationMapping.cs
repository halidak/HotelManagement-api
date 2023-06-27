using AutoMapper;
using HotelManagement.Data.Models;
using HotelManagement_api.DTOs;
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
            CreateMap<Item, ItemDto>();
            CreateMap<ItemDto, Item>();
            CreateMap<Minibar_Item, Minibar_ItemDto>();
            CreateMap<Minibar_ItemDto, Minibar_Item>();
            CreateMap<Minibar, MinibarDto>();
            CreateMap<MinibarDto, Minibar>();
            CreateMap<Reservation, ReservationDto>();
            CreateMap<ReservationDto, Reservation>()
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => false));
            CreateMap<Characteristics, CharacteristicDto>();
            CreateMap<CharacteristicDto, Characteristics>();
        }
    }
}
