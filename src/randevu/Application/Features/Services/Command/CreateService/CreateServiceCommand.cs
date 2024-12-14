using Application.Features.Services.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Services.Command.CreateService
{
    public class CreateServiceCommand : IRequest<ServiceDto>
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Cost { get; set; }
        public int CompanyId { get; set; }
        public class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand, ServiceDto>
        {
            private readonly IMapper _mapper;
            private readonly IServiceRepository _ServiceRepository;
            public CreateServiceCommandHandler(IServiceRepository ServiceRepository, IMapper mapper)
            {
                _mapper = mapper;
                _ServiceRepository = ServiceRepository;
            }

            public async Task<ServiceDto> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
            {
                Service mappedService = _mapper.Map<Service>(request);

                Service addedService = await _ServiceRepository.AddAsync(mappedService);

                ServiceDto createdServiceDto = _mapper.Map<ServiceDto>(addedService);

                return createdServiceDto;
            }
        }
    }
}
