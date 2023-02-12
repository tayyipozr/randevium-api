using Application.Features.Auths.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;
using MediatR;

namespace Application.Features.Auths.Queries
{
    public class GetMeQuery : IRequest<UserDto>
    {
      public int UserId { get; set; }
      public class GetMeQueryHandler : IRequestHandler<GetMeQuery, UserDto>
      {
          private readonly IUserRepository _userRepository;
          private readonly IMapper _mapper;

          public GetMeQueryHandler(IUserRepository userRepository, IMapper mapper)
          {
              _mapper = mapper;
              _userRepository = userRepository;
          }

          public Task<UserDto> Handle(GetMeQuery request, CancellationToken cancellationToken)
          {
              AppUser? user = _userRepository.Get(u => u.Id == request.UserId);

              if (user == null) throw new BusinessException("User not found");

              UserDto userDto = _mapper.Map<UserDto>(user);

              return Task.FromResult(userDto);
          }
      }
    }
}
