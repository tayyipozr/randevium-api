using Application.Features.AppointmentDetails.Dtos;
using Application.Features.Appointments.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.AppointmentDetails.Queries
{
    public class GetUserAppointmentDetailsQuery : IRequest<AppointmentDetailDto>
    {
        public int AppointmentId { get; set; }
        public class GetUserAppointmentDetailsQueryHandler : IRequestHandler<GetUserAppointmentDetailsQuery, AppointmentDetailDto>
        {
            private readonly IAppointmentDetailRepository _appointmentDetailRepository;
            private readonly IMapper _mapper;

            public GetUserAppointmentDetailsQueryHandler(IAppointmentDetailRepository appointmentDetailRepository, IMapper mapper)
            {
                _mapper = mapper;
                _appointmentDetailRepository = appointmentDetailRepository;
            }

            public Task<AppointmentDetailDto> Handle(GetUserAppointmentDetailsQuery request, CancellationToken cancellationToken)
            {
                AppointmentDetail? appointmentDetail = _appointmentDetailRepository.Query()
                    .Include(t => t.Appointment).Include(t => t.Employee).Include(t => t.Service)
                    .Where(t => t.AppointmentId == request.AppointmentId).FirstOrDefault();

                if (appointmentDetail == null) throw new BusinessException("Appointment details not found for appointment");

                AppointmentDetailDto appointmentDetailDto = _mapper.Map<AppointmentDetailDto>(appointmentDetail);

                return Task.FromResult(appointmentDetailDto);
            }
        }
    }
}
