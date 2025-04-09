using Business.Abstract;
using Core.DataAccess;
using DataAccess.Abstract;
using Entities.Concrete;
using Service.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserOperationClaimManager : Manager<UserOperationClaim>, IUserOperationClaimService
    {
        public UserOperationClaimManager(IUserOperationClaimDal repository) : base(repository)
        {
        }
    }
}
