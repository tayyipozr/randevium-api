using Application.Features.AppointmentDetails.Command.CreateAppointmentDetail;
using Application.Features.AppointmentDetails.Dtos;
using Application.Features.Appointments.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.AppointmentDetails.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<AppointmentDetail, AppointmentDetailDto>().ReverseMap();
            CreateMap<AppointmentDetail, CreateAppointmentDetailCommand>().ReverseMap();
            CreateMap<IPaginate<AppointmentDetail>, AppointmentDetailModel>().ReverseMap();
        }
    }
}
