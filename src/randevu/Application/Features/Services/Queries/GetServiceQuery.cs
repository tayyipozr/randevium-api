using Application.Features.Services.Dtos;
using Application.Features.Services.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;

namespace Application.Features.Services.Queries
{
    public class GetServiceQuery : IRequest<ServiceModel>
    {
      public int CompanyId { get; set; }
      public class GetServiceQueryHandler : IRequestHandler<GetServiceQuery, ServiceModel>
      {
          private readonly IServiceRepository _serviceRepository;
          private readonly IMapper _mapper;

          public GetServiceQueryHandler(IServiceRepository serviceRepository, IMapper mapper)
          {
              _mapper = mapper;
              _serviceRepository = serviceRepository;
          }

          public Task<ServiceModel> Handle(GetServiceQuery request, CancellationToken cancellationToken)
          {
              IPaginate<Service>? service = _serviceRepository.GetList(u => u.CompanyId == request.CompanyId);

              if (service.Items.Count == 0) throw new BusinessException("Service not found");

              ServiceModel serviceDto = _mapper.Map<ServiceModel>(service);

              return Task.FromResult(serviceDto);
          }
      }
    }
}
