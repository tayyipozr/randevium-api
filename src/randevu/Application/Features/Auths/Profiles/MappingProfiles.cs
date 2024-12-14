using Application.Features.Auths.Dtos;
using Application.Features.Companies.Command.CreateCompany;
using Application.Features.Companies.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Auths.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<AppUser, UserDto>().ReverseMap();
        }
    }
}
