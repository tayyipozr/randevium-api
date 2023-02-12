using Application.Features.Auths.Command.Login;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auths.Validators
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(u => u.UserForLoginDto.PhoneNumber).NotEmpty();
            RuleFor(u => u.UserForLoginDto.PhoneNumber).NotNull();

            RuleFor(u => u.UserForLoginDto.Password).NotEmpty();
            RuleFor(u => u.UserForLoginDto.Password).NotNull();
        }
    }
}
