using Business.Security;
using Core.ResponseModels;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthService
    {
        Task<CreateSuccessResponse> Register(UserForRegisterDto userForRegisterDto);

        Task<DataResponse<AccessToken>> Login(UserForLoginDto userForLoginDto);

        Task<SuccessResponse> VerifyEmailOfUser(int userId, string verificationCode);
    }
}
