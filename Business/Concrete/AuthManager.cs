using Business.Abstract;
using Business.Constants.Messages.Entity;
using Business.Security;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Exceptions.User;
using Core.ResponseModels;
using Entities.Concrete;
using Entities.Dtos.User;
using Microsoft.EntityFrameworkCore;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        readonly IUserService _userService;
        readonly IUnitOfWork _unitOfWork;

        public AuthManager(IUserService userService, IUnitOfWork unitOfWork)
        {
            _userService = userService;
            _unitOfWork = unitOfWork;
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
            };

            user.UserOperationClaims.Add(new UserOperationClaim { OperationClaimId = 2 });

            await _userService.Add(user);
            await _unitOfWork.SaveChangesAsync();

            return new CreateSuccessResponse(AuthMessages.UserRegistered);
        }



        [ValidationAspect(typeof(UserForLoginDtoValidator))]
        public async Task<DataResponse<AccessToken>> Login(UserForLoginDto dto)
        {
            User? user = await _userService
                .Where(u => u.Email == dto.Email && !u.IsDeleted)
                .SingleOrDefaultAsync();


            if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.Password))
                throw new InvalidCredentialsException();


            DataResponse<AccessToken> dataResponse = await _userService.CreateAccessToken(user);


            return new DataResponse<AccessToken>(dataResponse.Data, AuthMessages.SuccessfulLogin);
        }


        
    }
}
