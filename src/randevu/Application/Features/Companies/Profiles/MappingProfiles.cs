using Application.Features.Companies.Command.CreateCompany;
using Application.Features.Companies.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Companies.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Company, CompanyDto>().ReverseMap();
            CreateMap<Company, GetCompanyDto>().ReverseMap();
            CreateMap<Company, CreateCompanyCommand>().ReverseMap();
        }
    }
}
