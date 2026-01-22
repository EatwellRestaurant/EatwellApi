namespace EatwellApi.Application.Abstractions.Services.User
{
    public interface IUserService
    {
        Task CheckIfUserEMailAsync(string email);
    }
}
