using EatwellApi.Application.Abstractions.Repositories;
using EatwellApi.Application.Abstractions.Services.EmailService;
using EatwellApi.Application.Abstractions.Services.User;
using EatwellApi.Application.Constants.Messages.Entity;
using EatwellApi.Application.Wrappers;
using MediatR;
using Microsoft.AspNetCore.Http;
using DomainUser = EatwellApi.Domain.Entities.User;

namespace EatwellApi.Application.Features.Commands.User.ResendEmail
{
    internal class ResendEmailCommandHandler : IRequestHandler<ResendEmailCommandRequest, SuccessResponse>
    {
        readonly IUserService _userService;
        readonly IEmailService _emailService;
        readonly IUnitOfWork _unitOfWork;

        public ResendEmailCommandHandler(IUserService userService, IEmailService emailService, IUnitOfWork unitOfWork)
        {
            _userService = userService;
            _emailService = emailService;
            _unitOfWork = unitOfWork;
        }


        public async Task<SuccessResponse> Handle(ResendEmailCommandRequest request, CancellationToken cancellationToken)
        {
            DomainUser user = await _userService.GetByIdAsync(request.UserId);

            // Türkiye saatini hesapla
            var turkeyTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Turkey Standard Time");
            var turkeyTime = TimeZoneInfo.ConvertTime(DateTime.UtcNow, turkeyTimeZone);

            user.VerificationCode = new Random().Next(10000, 99999).ToString();
            user.VerificationCodeDuration = turkeyTime.AddMinutes(3);

            await _emailService.SendEmailAsync(user.Email, user.FirstName, user.VerificationCode);
            await _unitOfWork.SaveChangesAsync();

            return new SuccessResponse(AuthMessages.SuccessfulSendedVerificationCode, StatusCodes.Status200OK);
        }
    }
}
