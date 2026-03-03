using EatwellApi.Application.Abstractions.Services;
using EatwellApi.Application.Wrappers;
using EatwellApi.Domain.Exceptions.User;
using MediatR;

namespace EatwellApi.Application.Behaviors.Authorization
{
    public class AuthorizationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : Response
    {
        readonly ICurrentUserService _currentUser;

        public AuthorizationBehavior(ICurrentUserService currentUser)
        {
            _currentUser = currentUser;
        }


        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            // Request sınıfındaki [Secured] attribute'larını buluyoruz.
            var securedAttributes = request.GetType()
                .GetCustomAttributes(typeof(SecuredAttribute), true)
                .Cast<SecuredAttribute>()
                .ToList();


            // Attribute yoksa herkese açık endpoint demektir
            if (!securedAttributes.Any())
                return await next();


            // Token yoksa / giriş yapılmamışsa erişimi engelliyoruz
            if (!_currentUser.IsAuthenticated)
                throw new UnauthorizedException();


            // Gerekli claim'lerden en az biri kullanıcıda var mı?
            var requiredRoles = securedAttributes.SelectMany(a => a.Roles).ToList();

            var hasPermission = requiredRoles.Any(role => _currentUser.HasClaim(role));

            
            if (!hasPermission)
                throw new ForbiddenException();

            
            return await next();
        }
    }
}
