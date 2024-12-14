using Core.Security.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebAPI.Controllers
{

    public class BaseController : ControllerBase
    {
        protected IMediator? Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        private IMediator? _mediator;
        protected string? GetIpAddress()
        {
            if (Request.Headers.ContainsKey("X-Forwarded-For")) return Request.Headers["X-Forwarded-For"];
            return HttpContext.Connection.RemoteIpAddress?.MapToIPv4().ToString();
        }


        protected int GetUserId()
        {
            var identity = new ClaimsIdentity("Custom");
            int id = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);
            return (int)id;
        }

        protected List<string>? GetUserRoles()
        {
            List<string>? roleClaims = HttpContext.User.ClaimRoles();
            return roleClaims;
        }
    }
}
