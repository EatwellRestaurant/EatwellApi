namespace EatwellApi.Application.Abstractions.Security
{
    public interface ISecuredRequest
    {
        string[] Roles { get; }
    }
}
