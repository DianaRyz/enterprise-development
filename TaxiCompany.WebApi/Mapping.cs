using AutoMapper;
using TaxiCompany.Domain;
using TaxiCompany.WebApi.Dto;

namespace TaxiCompany.WebApi;
/// <summary>
/// Настройка маппинга между моделями и DTO
/// </summary>
public class Mapping : Profile
{
    public Mapping()
    {
        CreateMap<Car, CarDtoPost>().ReverseMap();
        CreateMap<Driver, DriverDtoPost>().ReverseMap();
        CreateMap<Trip, TripDtoPost>().ReverseMap();
        CreateMap<User, UserDtoPost>().ReverseMap();
        CreateMap<Car, CarDtoGet>().ReverseMap();
        CreateMap<Driver, DriverDtoGet>().ReverseMap();
        CreateMap<Trip, TripDtoGet>().ReverseMap();
        CreateMap<User, UserDtoGet>().ReverseMap();
    }
        
}
