using AutoMapper;
using BigFolk.Api.Models.Domain;
using BigFolk.Api.Models.DTO.Genius;

namespace BigFolk.Api.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Genius, GeniusDto>().ReverseMap();
            CreateMap<AddGeniusRequestDto, Genius>().ReverseMap();
            CreateMap<UpdateGeniusRequestDto, Genius>().ReverseMap();
        }
    }
}
