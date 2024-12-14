using Application.Features.AppointmentDetails.Dtos;
using Application.Features.Appointments.Command.CreateAppointment;
using Application.Features.Appointments.Dtos;
using Application.Features.Appointments.Models;
using Application.Features.Services.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Appointments.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Appointment, AppointmentDto>().ReverseMap();
            CreateMap<Appointment, CreateAppointmentCommand>().ReverseMap();
            CreateMap<Appointment, CreateAppointmentDto>().ReverseMap();
            CreateMap<IPaginate<Appointment>, AppointmentModel>().ReverseMap();
        }
    }
}
