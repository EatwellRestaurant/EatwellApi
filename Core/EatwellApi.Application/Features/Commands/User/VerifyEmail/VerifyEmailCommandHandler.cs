using EatwellApi.Application.Abstractions.Repositories;
using EatwellApi.Application.Abstractions.Services.User;
using EatwellApi.Application.Constants.Messages.Entity;
using EatwellApi.Application.Wrappers;
using EatwellApi.Domain.Exceptions.User;
using MediatR;
using Microsoft.AspNetCore.Http;
using DomainUser = EatwellApi.Domain.Entities.User;

namespace EatwellApi.Application.Features.Commands.User.VerifyEmail
{
    public class VerifyEmailCommandHandler : IRequestHandler<VerifyEmailCommandRequest, SuccessResponse>
    {
        readonly IUserService _userService;
        readonly IUnitOfWork _unitOfWork;

        public VerifyEmailCommandHandler(IUserService userService, IUnitOfWork unitOfWork)
        {
            _userService = userService;
            _unitOfWork = unitOfWork;
        }


        public async Task<SuccessResponse> Handle(VerifyEmailCommandRequest request, CancellationToken cancellationToken)
        {
            DomainUser user = await _userService.GetByIdAsync(request.UserId);

            // Türkiye saatini hesapla
            var turkeyTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Turkey Standard Time");
            var turkeyTime = TimeZoneInfo.ConvertTime(DateTime.UtcNow, turkeyTimeZone);

            if (user.VerificationCode != request.Code || turkeyTime > user.VerificationCodeDuration)
                throw new InvalidVerificationCodeException();


            user.Verification = true;
            user.LastLoginDate = turkeyTime;
            await _unitOfWork.SaveChangesAsync();

            return new SuccessResponse(AuthMessages.VerificationSuccessful, StatusCodes.Status200OK);
        }
    }
}
