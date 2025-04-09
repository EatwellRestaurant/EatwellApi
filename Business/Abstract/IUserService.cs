using Core.ResponseModels;
using Core.Utilities.Results;
using Core.Utilities.Security;
using Entities.Concrete;
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
        Task Add(User user);

        Task CheckIfUserEMail(string email); 

        Task<User> GetUserByEmail(string email);

        Task<DataResponse<AccessToken>> CreateAccessToken(User user);
    }
}
