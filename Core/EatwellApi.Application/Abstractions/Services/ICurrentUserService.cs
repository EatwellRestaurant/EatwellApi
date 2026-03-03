namespace EatwellApi.Application.Abstractions.Services
{
    public interface ICurrentUserService
    {
        int? UserId { get; }

        string? Email { get; }
        
        bool IsAuthenticated { get; }
        
        IEnumerable<string> OperationClaims { get; }
        
        bool HasClaim(string operationClaim);
    }
}
