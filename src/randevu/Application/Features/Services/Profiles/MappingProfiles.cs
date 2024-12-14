using Application.Features.Services.Command.CreateService;
using Application.Features.Services.Dtos;
using Application.Features.Services.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Services.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Service, ServiceDto>().ReverseMap();
            CreateMap<Service, CreateServiceCommand>().ReverseMap();
            CreateMap<Service, ServiceListDto>().ReverseMap();
            CreateMap<IPaginate<Service>, ServiceModel>().ReverseMap();
        }
    }
}
