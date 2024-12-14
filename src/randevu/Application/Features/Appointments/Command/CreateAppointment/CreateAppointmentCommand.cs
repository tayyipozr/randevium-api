using Application.Features.Appointments.Constants;
using Application.Features.Appointments.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Appointments.Command.CreateAppointment
{
    public class CreateAppointmentCommand : IRequest<AppointmentDto>
    {
        public DateTime AppointmentDateTime { get; set; }
        public int CompanyId { get; set; }
        public int UserId { get; set; }
        public class CreateAppointmentCommandHandler : IRequestHandler<CreateAppointmentCommand, AppointmentDto>
        {
            private readonly IMapper _mapper;
            private readonly IAppointmentRepository _appointmentRepository;
            public CreateAppointmentCommandHandler(IAppointmentRepository appointmentRepository, IMapper mapper)
            {
                _mapper = mapper;
                _appointmentRepository = appointmentRepository;
            }

            public async Task<AppointmentDto> Handle(CreateAppointmentCommand request, CancellationToken cancellationToken)
            {
                Appointment mappedAppointment = _mapper.Map<Appointment>(request);

                mappedAppointment.AppointmentStatus = AppointmentStatus.Pending;
                mappedAppointment.CreatedTime = DateTime.UtcNow;
                mappedAppointment.UpdatedTime = DateTime.UtcNow;

                Appointment addedAppointment = await _appointmentRepository.AddAsync(mappedAppointment);

                AppointmentDto createdAppointmentDto = _mapper.Map<AppointmentDto>(addedAppointment);

                return createdAppointmentDto;
            }
        }
    }
}
