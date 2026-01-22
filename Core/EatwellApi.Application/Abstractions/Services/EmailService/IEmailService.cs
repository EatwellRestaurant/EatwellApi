namespace EatwellApi.Application.Abstractions.Services.EmailService
{
    public interface IEmailService
    {
        Task<object> SendEmailAsync(string toEmail, string toName, string code);

    }
}
