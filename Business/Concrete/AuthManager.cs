using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants.Messages.Entity;
using Business.Security;
using Business.ValidationRules.FluentValidation.User;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Abstract;
using Core.Exceptions.General;
using Core.Exceptions.User;
using Core.ResponseModels;
using Core.Utilities.Email;
using Entities.Concrete;
using Entities.Dtos.User;
using Entities.Enums;
using Entities.Enums.OperationClaim;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        readonly IUserService _userService;
        readonly IUnitOfWork _unitOfWork;
        readonly IEmailService _emailService;

        public AuthManager(IUserService userService, IUnitOfWork unitOfWork, IEmailService emailService)
        {
            _userService = userService;
            _unitOfWork = unitOfWork;
            _emailService = emailService;
        }



        [ValidationAspect(typeof(UserForRegisterDtoValidator))]
        public async Task<CreateSuccessResponse> Register(UserForRegisterDto dto)
        {
            await _userService.CheckIfUserEMail(dto.Email);

            User user = new()
            { 
                Email = dto.Email,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Password = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                Verification = false,
                VerificationCode = new Random().Next(10000, 99999).ToString(),
                VerificationCodeDuration = DateTime.Now.AddMinutes(3),
                OperationClaimId = (int)OperationClaimEnum.User
            };

            await _userService.AddAsync(user);
            await _emailService.SendEmailAsync(user.Email, user.FirstName, user.VerificationCode);
            await _unitOfWork.SaveChangesAsync();

            return new CreateSuccessResponse(AuthMessages.UserRegistered, user.Id);
        }



        [ValidationAspect(typeof(UserForLoginDtoValidator))]
        public async Task<DataResponse<AccessToken>> Login(UserForLoginDto dto)
        {
            User? user = await _userService
                .Where(u => u.Email == dto.Email && !u.IsDeleted)
                .SingleOrDefaultAsync();


            if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.Password))
                throw new InvalidCredentialsException();


            if (!user.Verification == true)
                throw new EmailNotVerifiedException();


            DataResponse<AccessToken> dataResponse = await _userService.CreateAccessToken(user);
            user.LastLoginDate = DateTime.Now;

            await _unitOfWork.SaveChangesAsync();
            return new DataResponse<AccessToken>(dataResponse.Data, AuthMessages.SuccessfulLogin);
        }



        public async Task<SuccessResponse> VerifyEmailOfUser(int userId, VerificationCodeDto codeDto)
        {
            User? user = await _userService
                .Where(u => u.Id == userId && !u.IsDeleted)
                .SingleOrDefaultAsync();


            if (user == null)
                throw new EntityNotFoundException("Kullanıcı");


            if (user.VerificationCode != codeDto.VerificationCode || DateTime.Now > user.VerificationCodeDuration)
                throw new InvalidVerificationCodeException();

            user.Verification = true;

            _userService.Update(user);
            await _unitOfWork.SaveChangesAsync();

            return new SuccessResponse(AuthMessages.VerificationSuccessful, StatusCodes.Status200OK);
        }


        public async Task<SuccessResponse> SendEmailAsync(int userId)
        {
            User user = await _userService
                .GetAsync(u => u.Id == userId && !u.IsDeleted)
                ?? throw new EntityNotFoundException("Kullanıcı");


            user.VerificationCode = new Random().Next(10000, 99999).ToString();
            user.VerificationCodeDuration = DateTime.Now.AddMinutes(3);

            _userService.Update(user);
            await _emailService.SendEmailAsync(user.Email, user.FirstName, user.VerificationCode);
            await _unitOfWork.SaveChangesAsync();

            return new SuccessResponse(AuthMessages.SuccessfulSendedVerificationCode, StatusCodes.Status200OK);
        }
    }
}
