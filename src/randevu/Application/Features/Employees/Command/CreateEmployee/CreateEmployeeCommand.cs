using Application.Features.Companies.Dtos;
using Application.Features.Employees.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Employees.Command.CreateEmployee
{
    public class CreateEmployeeCommand : IRequest<EmployeeDto>
    {
        public int CompanyId { get; set; }
        public string? Description { get; set; }
        public int UserId { get; set; }
        public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, EmployeeDto>
        {
            private readonly IMapper _mapper;
            private readonly IEmployeeRepository _employeeRepository;
            public CreateEmployeeCommandHandler(IEmployeeRepository companyRepository, IMapper mapper)
            {
                _mapper = mapper;
                _employeeRepository = companyRepository;
            }

            public async Task<EmployeeDto> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
            {
                Employee mappedEmployee = _mapper.Map<Employee>(request);

                Employee addedEmployee = await _employeeRepository.AddAsync(mappedEmployee);

                EmployeeDto createdEmployeeDto = _mapper.Map<EmployeeDto>(addedEmployee);

                return createdEmployeeDto;
            }
        }
    }
}
