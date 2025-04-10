using Business.Security;
using Core.ResponseModels;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
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
        Task<DataResponse<List<UserListDto>>> GetUsers();

        Task Add(User user);

        Task CheckIfUserEMail(string email); 

        Task<User> GetUserByEmail(string email);

        Task<DataResponse<AccessToken>> CreateAccessToken(User user);
    }
}
