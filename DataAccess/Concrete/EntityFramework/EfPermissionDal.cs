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
    public class EfPermissionDal : EfEntityRepositoryBase<Permission, RestaurantContext>, IPermissionDal
    {
        public EfPermissionDal(RestaurantContext context) : base(context)
        {
        }
    }
}
