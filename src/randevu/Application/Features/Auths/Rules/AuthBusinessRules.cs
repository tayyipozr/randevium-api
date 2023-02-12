using Application.Features.Auths.Constants;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Core.Security.Hashing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auths.Rules
{
    public class AuthBusinessRules
    {
        private readonly IUserRepository _userRepository;

        public AuthBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task EmailCanNotBeDuplicatedWhenRegistered(string email)
        {
            User? _user = await _userRepository.GetAsync(u => u.Email == email);

            if (_user != null) throw new BusinessException("Mail already exists");
        }

        public void UserShouldRegisteredBeforeLogged(User? user)
        {
            if (user == null) throw new BusinessException(AuthMessages.UserDoesNotExist);
            return;
        }

        public void UserPasswordShouldMatch(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            bool result = HashingHelper.VerifyPasswordHash(password, passwordHash, passwordSalt);
            if (!result)
                throw new BusinessException(AuthMessages.PasswordDoesNotMatch);

        }
    }
}
