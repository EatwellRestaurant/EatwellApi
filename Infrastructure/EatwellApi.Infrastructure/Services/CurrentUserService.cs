using EatwellApi.Application.Abstractions.Services;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace EatwellApi.Infrastructure.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        private ClaimsPrincipal? User => _httpContextAccessor.HttpContext?.User;

        public int? UserId
        {
            get
            {
                var value = User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                return int.TryParse(value, out var id) ? id : null;
            }
        }

        public string? Email => User?.FindFirst(ClaimTypes.Email)?.Value;

        public bool IsAuthenticated => User?.Identity?.IsAuthenticated ?? false;


        // JWT'deki claim'leri çekiyoruz
        public IEnumerable<string> OperationClaims =>
            User?.Claims
                .Where(c => c.Type == ClaimTypes.Role) 
                .Select(c => c.Value)
            ?? Enumerable.Empty<string>();


        public bool HasClaim(string operationClaim) => OperationClaims.Contains(operationClaim);
    }
}
