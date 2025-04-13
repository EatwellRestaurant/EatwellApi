using AutoMapper;
using Business.Abstract;
using Business.Constants.Messages;
using Business.Constants.Messages.Entity;
using Business.Security;
using Business.ValidationRules.FluentValidation.User;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Abstract;
using Core.Exceptions.General;
using Core.Exceptions.User;
using Core.ResponseModels;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.User;
using Microsoft.EntityFrameworkCore;
using Service.Concrete;

namespace Business.Concrete
{
    public class UserManager : Manager<User>, IUserService
    {
        readonly IUserDal _userDal;
        readonly IOperationClaimService _operationClaimService;
        readonly ITokenHelper _tokenHelper;
        readonly IMapper _mapper;
        readonly IUnitOfWork _unitOfWork;

        public UserManager(
            IUserDal userDal,
            ITokenHelper tokenHelper,
            IOperationClaimService operationClaimService,
            IMapper mapper,
            IUnitOfWork unitOfWork)
            : base(userDal)
        {
            _userDal = userDal;
            _tokenHelper = tokenHelper;
            _operationClaimService = operationClaimService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }




        public async Task<DataResponse<AccessToken>> CreateAccessToken(User user)
        {
            DataResponse<List<OperationClaim>> claims = await _operationClaimService.GetClaims(user.Id);


            if (!claims.Data.Any())
                throw new ForbiddenException();


            return new DataResponse<AccessToken>(_tokenHelper.CreateToken(user, claims.Data));
        }



        public async Task<DataResponse<List<UserListDto>>> GetAll() 
            => new DataResponse<List<UserListDto>>(_mapper.Map<List<UserListDto>>
                (await _userDal
                .GetAllQueryable() 
                .OrderByDescending(u => u.CreateDate)
                .ToListAsync()), 
                CommonMessages.EntityListed);



        public async Task<DataResponse<UserDetailDto>> Get(int userId)
        {
            User? user = await _userDal
                .GetAsync(u => u.Id == userId)
                ?? throw new EntityNotFoundException("Kullanıcı");


            return new DataResponse<UserDetailDto>
                (_mapper.Map<UserDetailDto>(user), 
                CommonMessages.EntityFetch);
        }



        [ValidationAspect(typeof(UserUpdateDtoValidator))]
        public async Task<UpdateSuccessResponse> Update(int userId, UserUpdateDto updateDto)
        {
            User user = await GetByIdUser(userId);

            if (!BCrypt.Net.BCrypt.Verify(updateDto.Password, user.Password))
                throw new InvalidPasswordException();

            _mapper.Map(updateDto, user);

            _userDal.Update(user);
            await _unitOfWork.SaveChangesAsync();

            return new UpdateSuccessResponse(CommonMessages.EntityUpdated);
        }


         
        [ValidationAspect(typeof(UserPasswordUpdateDtoValidator))]
        public async Task<UpdateSuccessResponse> UpdatePassword(int userId, UserPasswordUpdateDto updateDto)
        {
            User user = await GetByIdUser(userId);

            if (!BCrypt.Net.BCrypt.Verify(updateDto.OldPassword, user.Password))
                throw new InvalidPasswordException();


            if (updateDto.NewPassword != updateDto.NewPasswordAgain)
                throw new NewPasswordMismatchException();


            user.Password = BCrypt.Net.BCrypt.HashPassword(updateDto.NewPassword);
            user.UpdateDate = DateTime.Now;

            _userDal.Update(user);
            await _unitOfWork.SaveChangesAsync();

            return new UpdateSuccessResponse(CommonMessages.EntityUpdated);
        }


        public async Task<DeleteSuccessResponse> Delete(int userId, UserDeleteDto deleteDto)
        {
            User user = await GetByIdUser(userId);

            if (!BCrypt.Net.BCrypt.Verify(deleteDto.Password, user.Password))
                throw new InvalidPasswordException();

            user.IsDeleted = true;
            user.DeleteDate = DateTime.Now;

            _userDal.Update(user);
            await _unitOfWork.SaveChangesAsync();

            return new DeleteSuccessResponse(CommonMessages.EntityDeleted);
        }



        public async Task CheckIfUserEMail(string email)
        {
            if (await _userDal.AnyAsync(u => u.Email == email && !u.IsDeleted))
                throw new EntityAlreadyExistsException("e-posta");
        }






        #region BusinessRules

        private async Task<User> GetByIdUser(int userId)
        {
            User? user = await _userDal
                .GetAsync(u => u.Id == userId && !u.IsDeleted)
                ?? throw new EntityNotFoundException("Kullanıcı");

            return user;
        }


        #endregion
    }
}
