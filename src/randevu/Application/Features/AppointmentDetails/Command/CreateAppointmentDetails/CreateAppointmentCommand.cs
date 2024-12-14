using Application.Features.AppointmentDetails.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.AppointmentDetails.Command.CreateAppointmentDetail
{
    public class CreateAppointmentDetailCommand : IRequest<AppointmentDetailDto>
    {
        public int AppointmentId { get; set; }
        public int ServiceId { get; set; }
        public int EmployeeId { get; set; }
        public decimal Price { get; set; }
        public int Duration { get; set; }
        public class CreateAppointmentDetailCommandHandler : IRequestHandler<CreateAppointmentDetailCommand, AppointmentDetailDto>
        {
            private readonly IMapper _mapper;
            private readonly IAppointmentDetailRepository _AppointmentDetailRepository;
            public CreateAppointmentDetailCommandHandler(IAppointmentDetailRepository AppointmentDetailRepository, IMapper mapper)
            {
                _mapper = mapper;
                _AppointmentDetailRepository = AppointmentDetailRepository;
            }

            public async Task<AppointmentDetailDto> Handle(CreateAppointmentDetailCommand request, CancellationToken cancellationToken)
            {
                AppointmentDetail mappedAppointmentDetail = _mapper.Map<AppointmentDetail>(request);

                AppointmentDetail addedAppointmentDetail = await _AppointmentDetailRepository.AddAsync(mappedAppointmentDetail);

                AppointmentDetailDto createdAppointmentDetailDto = _mapper.Map<AppointmentDetailDto>(addedAppointmentDetail);

                return createdAppointmentDetailDto;
            }
        }
    }
}
