using Application.Features.Appointments.Dtos;
using Application.Features.Appointments.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Appointments.Queries
{
    public class GetAppointmentsQuery : IRequest<AppointmentModel>
    {
      public int UserId { get; set; }
      public class GetAppointmentQueryHandler : IRequestHandler<GetAppointmentsQuery, AppointmentModel>
      {
          private readonly IAppointmentRepository _appointmentRepository;
          private readonly IMapper _mapper;

          public GetAppointmentQueryHandler(IAppointmentRepository appointmentRepository, IMapper mapper)
          {
              _mapper = mapper;
                _appointmentRepository = appointmentRepository;
          }

          public async Task<AppointmentModel> Handle(GetAppointmentsQuery request, CancellationToken cancellationToken)
          {
              IPaginate<Appointment>? appointment = await _appointmentRepository.GetListAsync(u => u.UserId == request.UserId,
                  include: i => i.Include(i => i.Company));

              if (appointment == null) throw new BusinessException("Appointment not found");

              AppointmentModel appointmentModel = _mapper.Map<AppointmentModel>(appointment);

              return appointmentModel;
          }
      }
    }
}
