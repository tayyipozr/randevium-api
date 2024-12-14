using Application.Features.Auths.Command.Login;
using Application.Features.Auths.Command.Register;
using Application.Features.Auths.Dtos;
using Application.Features.Auths.Queries;
using Core.Security.Dtos;
using Core.Security.Entities;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        [HttpPost("Register")]

        public async Task<IActionResult> Register([FromBody] UserForRegisterDto userForRegisterDto)
        {
            RegisterCommand registerCommand = new()
            {
                UserForRegisterDto = userForRegisterDto,
                IpAddress = GetIpAddress()
            };

            RegisteredDto result = await Mediator.Send(registerCommand);
            SetRefreshTokenToCookie(result.RefreshToken);
            return Created("", result.AccessToken);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserForLoginDto userForLoginDto)
        {
            LoginCommand loginCommand = new()
            {
                UserForLoginDto = userForLoginDto,
                IpAddress = GetIpAddress()
            };


            LoggedDto result = await Mediator.Send(loginCommand);
            SetRefreshTokenToCookie(result.RefreshToken);
            return Ok(result.AccessToken);
        }

        [Authorize]
        [HttpGet("GetMe")]
        public async Task<IActionResult> GetMe()
        {
            int userId = GetUserId();
            if (userId == 0) return Unauthorized();

            GetMeQuery getMeQuery = new GetMeQuery
            {
                UserId = userId,
            };

            UserDto result = await Mediator.Send(getMeQuery);
            return Ok(result);
        }



        private void SetRefreshTokenToCookie(RefreshToken refreshToken)
        {
            CookieOptions cookieOptions = new() { HttpOnly = true, Expires = DateTime.Now.AddDays(7) };
            Response.Cookies.Append("refreshToken", refreshToken.Token, cookieOptions);
        }
    }
}
