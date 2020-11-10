using System.Security.Claims;
using Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;

namespace WebUI.Services
{
    public class CurrentUserService: ICurrentUserService
    {

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            UserId = httpContextAccessor.HttpContext?.User?.FindFirstValue("id");
        }
        
        public string UserId { get; }
        public bool IsAuthenticated => UserId != null;
    }
}