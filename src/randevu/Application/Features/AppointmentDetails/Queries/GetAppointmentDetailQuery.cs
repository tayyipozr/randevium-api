using Application.Features.AppointmentDetails.Dtos;
using Application.Features.Appointments.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.AppointmentDetails.Queries
{
    public class GetAppointmentDetailQuery : IRequest<AppointmentDetailModel>
    {
      public int AppointmentId { get; set; }
      public class GetAppointmentDetailQueryHandler : IRequestHandler<GetAppointmentDetailQuery, AppointmentDetailModel>
      {
          private readonly IAppointmentDetailRepository _appointmentDetailRepository;
          private readonly IMapper _mapper;

          public GetAppointmentDetailQueryHandler(IAppointmentDetailRepository appointmentDetailRepository, IMapper mapper)
          {
              _mapper = mapper;
              _appointmentDetailRepository = appointmentDetailRepository;
          }

          public Task<AppointmentDetailModel> Handle(GetAppointmentDetailQuery request, CancellationToken cancellationToken)
            {
                IPaginate<AppointmentDetail>? appointmentDetails= _appointmentDetailRepository
                    .GetList(t => t.AppointmentId == request.AppointmentId, 
                    include: t => t.Include(c => c.Service)!.Include(c => c.Employee)!);

                if (appointmentDetails == null) throw new BusinessException("AppointmentDetails not found for the appointment");

              AppointmentDetailModel appointmentDetailModel = _mapper.Map<AppointmentDetailModel>(appointmentDetails);

              return Task.FromResult(appointmentDetailModel);
          }
      }
    }
}
