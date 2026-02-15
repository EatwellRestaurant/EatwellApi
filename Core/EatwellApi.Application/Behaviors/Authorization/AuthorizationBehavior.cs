using EatwellApi.Application.Abstractions.Security;
using EatwellApi.Application.Wrappers;
using EatwellApi.Domain.Exceptions.User;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace EatwellApi.Application.Behaviors.Authorization
{
    public class AuthorizationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : Response
    {
        readonly IHttpContextAccessor _httpContextAccessor;

        public AuthorizationBehavior(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }


        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var user = _httpContextAccessor.HttpContext?.User;

            if (request is ISecuredRequest securedRequest)
            {
                if (user?.Identity is not { IsAuthenticated: true })
                    throw new UnauthorizedException(); 


                if (!securedRequest.Roles.Any(role => user.IsInRole(role)))
                    throw new ForbiddenException(); 
            }

            return await next();
        }
    }
}
