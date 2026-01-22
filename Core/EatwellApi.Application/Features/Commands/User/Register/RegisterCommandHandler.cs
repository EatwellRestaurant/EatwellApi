using EatwellApi.Application.Abstractions.Repositories;
using EatwellApi.Application.Abstractions.Services.EmailService;
using EatwellApi.Application.Abstractions.Services.User;
using EatwellApi.Application.Constants.Messages.Entity;
using EatwellApi.Application.Constants.Verification;
using EatwellApi.Application.Wrappers;
using EatwellApi.Domain.Enums.OperationClaim;
using MediatR;
using System.Security.Cryptography;
using DomainUser = EatwellApi.Domain.Entities.User;

namespace EatwellApi.Application.Features.Commands.User.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommandRequest, CreateSuccessResponse>
    {
        readonly IUserService _userService;
        readonly IUserWriteService _userWriteService;
        readonly IEmailService _emailService;
        readonly IUnitOfWork _unitOfWork;

        public RegisterCommandHandler(IUserService userService, IEmailService emailService, IUnitOfWork unitOfWork, IUserWriteService userWriteService)
        {
            _userService = userService;
            _emailService = emailService;
            _unitOfWork = unitOfWork;
            _userWriteService = userWriteService;
        }



        public async Task<CreateSuccessResponse> Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
        {
            await _userService.CheckIfUserEMailAsync(request.Email);

            DomainUser user = new()
            { 
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Password = BCrypt.Net.BCrypt.HashPassword(request.Password),
                Verification = false,
                VerificationCode = RandomNumberGenerator.GetInt32(10000, 99999).ToString(),
                VerificationCodeDuration = DateTime.Now.AddMinutes(VerificationConstants.CodeDurationMinutes),
                OperationClaimId = (int)OperationClaimEnum.User
            };

            await _userWriteService.AddAsync(user);
            await _unitOfWork.SaveChangesAsync();
            await _emailService.SendEmailAsync(user.Email, user.FirstName, user.VerificationCode);

            return new CreateSuccessResponse(AuthMessages.UserRegistered, user.Id);
        }
    }
}
