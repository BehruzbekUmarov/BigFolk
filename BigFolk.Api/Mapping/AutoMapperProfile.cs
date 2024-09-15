using AutoMapper;
using BigFolk.Api.Models.Domain;
using BigFolk.Api.Models.DTO.Company;
using BigFolk.Api.Models.DTO.Genius;
using BigFolk.Api.Models.DTO.SmartHouse;

namespace BigFolk.Api.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Genius, GeniusDto>().ReverseMap();
            CreateMap<AddGeniusRequestDto, Genius>().ReverseMap();
            CreateMap<UpdateGeniusRequestDto, Genius>().ReverseMap();

            CreateMap<SmartHouse, SmartHouseDto>().ReverseMap();
            CreateMap<UpdateSmartHouseRequestDto, Genius>().ReverseMap();
            CreateMap<AddSmartHouseRequestDto, Genius>().ReverseMap();

            CreateMap<Company, CompanyDto>().ReverseMap();
            CreateMap<UpdateCompanyRequestDto, Genius>().ReverseMap();
            CreateMap<AddCompanyRequestDto, Genius>().ReverseMap();
        }
    }
}
