using Business.Security;
using Core.Requests;
using Core.ResponseModels;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos.User;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService : IService<User>
    {
        Task<PaginationResponse<UserListDto>> GetAll(PaginationRequest paginationRequest);

        Task<DataResponse<UserDetailDto>> Get(int userId);

        Task CheckIfUserEMail(string email);

        Task<UpdateSuccessResponse> Update(int userId, UserUpdateDto upsertDto);

        Task<UpdateSuccessResponse> UpdatePassword(int userId, UserPasswordUpdateDto updateDto);

        Task<DeleteSuccessResponse> Delete(int userId, UserDeleteDto deleteDto);

        Task<DataResponse<AccessToken>> CreateAccessToken(User user);
    }
}
