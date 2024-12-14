using Application.Features.Companies.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Companies.Command.CreateCompany
{
    public class CreateCompanyCommand : IRequest<CompanyDto>
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int UserId { get; set; }
        public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, CompanyDto>
        {
            private readonly IMapper _mapper;
            private readonly ICompanyRepository _companyRepository;
            public CreateCompanyCommandHandler(ICompanyRepository companyRepository, IMapper mapper)
            {
                _mapper = mapper;
                _companyRepository = companyRepository;
            }

            public async Task<CompanyDto> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
            {
                Company mappedCompany = _mapper.Map<Company>(request);

                Company addedCompany = await _companyRepository.AddAsync(mappedCompany);

                CompanyDto createdCompanyDto = _mapper.Map<CompanyDto>(addedCompany);

                return createdCompanyDto;
            }
        }
    }
}
