using AutoMapper;
using BigFolk.Api.Models.Domain;
using BigFolk.Api.Models.DTO.Company;
using BigFolk.Api.Models.DTO.Genius;
using BigFolk.Api.Models.DTO.Habit;
using BigFolk.Api.Models.DTO.Portfolio;
using BigFolk.Api.Models.DTO.Skill;
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
            CreateMap<UpdateCompanyRequestDto, Company>().ReverseMap();
            CreateMap<AddCompanyRequestDto, Company>().ReverseMap();

            CreateMap<Habit, HabitDto>().ReverseMap();
            CreateMap<UpdateHabitRequestDto, Habit>().ReverseMap();
            CreateMap<AddHabitRequestDto, Habit>().ReverseMap();

            CreateMap<Portfolio, PortfolioDto>().ReverseMap();
            CreateMap<AddPortfolioRequestDto, Portfolio>().ReverseMap();

            CreateMap<Skill, SkillDto>().ReverseMap();
            CreateMap<AddSkillRequestDto, Skill>().ReverseMap();
            CreateMap<UpdateSkillRequestDto, Skill>().ReverseMap();
        }
    }
}
