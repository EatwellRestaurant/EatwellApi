﻿using Business.Abstract;
using Business.Constants.Messages.Entity;
using Core.Exceptions.General;
using Core.Exceptions.User;
using Core.ResponseModels;
using Core.Utilities.Results;
using Core.Utilities.Security;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Service.Concrete;

namespace Business.Concrete
{
    public class UserManager : Manager<User>, IUserService
    {
        readonly IUserDal _userDal;
        readonly IOperationClaimService _operationClaimService;
        readonly ITokenHelper _tokenHelper;

        public UserManager(IUserDal userDal, ITokenHelper tokenHelper, IOperationClaimService operationClaimService) : base(userDal)
        {
            _userDal = userDal;
            _tokenHelper = tokenHelper;
            _operationClaimService = operationClaimService;
        }


        public async Task<DataResponse<AccessToken>> CreateAccessToken(User user)
        {
            DataResponse<List<OperationClaim>> claims = await _operationClaimService.GetClaims(user.Id);


            if (!claims.Data.Any())
                throw new ForbiddenException();


            return new DataResponse<AccessToken>(_tokenHelper.CreateToken(user, claims.Data));
        }




        public async Task Add(User user)
        {
            await _userDal.AddAsync(user);
        }



        public async Task CheckIfUserEMail(string email)
        {
            if (await _userDal.AnyAsync(u => u.Email == email && !u.IsDeleted))
                throw new EntityAlreadyExistsException("e-posta");
        }



        public async Task<User> GetUserByEmail(string email)
        {
            User? user = await _userDal.Where(u => u.Email == email && !u.IsDeleted)
                .Select(u => new User
                {
                    Password = u.Password
                })
                .SingleOrDefaultAsync();


            if (user == null)
                throw new InvalidCredentialsException();


            return user;
        }





        #region BusinessRules

        
        #endregion
    }
}
