using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfOperationClaimDal : EfEntityRepositoryBase<OperationClaim, RestaurantContext>, IOperationClaimDal
    {
        public EfOperationClaimDal(RestaurantContext context) : base(context)
        {
        }
    }
}
