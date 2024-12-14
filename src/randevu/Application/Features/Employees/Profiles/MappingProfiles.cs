using Application.Features.Employees.Command.CreateEmployee;
using Application.Features.Employees.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Employees.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<Employee, CreateEmployeeCommand>().ReverseMap();
        }
    }
}
